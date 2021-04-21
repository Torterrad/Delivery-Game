using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverScript : MonoBehaviour
{
    //Score Components
    int score;
    float TimeinSeconds;

    float HighTime;
    int HighScore;

    //Text Components
    string tempTime;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimeText;

    public TextMeshProUGUI HighscoreText;
    public TextMeshProUGUI HighTimeText;

    //UI Components
    public GameObject Background;
    public GameObject GameOverMessage;
    public GameObject HUD;
    public GameObject Result;

    public GameObject HiScore;
    public GameObject HiTime;

    //Script Components
    public GameObject GameHandler;
    
    public void Gameover()
    {

        TimeinSeconds = Time.timeSinceLevelLoad;
        GrabScores();

        Time.timeScale = 0.1f;
        Background.SetActive(true);
        GameOverMessage.SetActive(true);
        HUD.SetActive(false);
        Invoke("Results", 0.1f);
    }

    void Results()
    {
        GameOverMessage.SetActive(false);
        Time.timeScale = 0f;

        scoreText.text = score.ToString();

        HighScores();
        Result.SetActive(true);

    }

    void GrabScores()
    {
        //Grab scores 
        score = GameHandler.GetComponent<Timer>().ordersCompleted;

        //Calculate time
        CalculateTime(TimeinSeconds);
        TimeText.text = tempTime;

        //Set PlayerPrefs
        //HighTime
        //HighScore
    }

    void CalculateTime(float Seconds)
    {
        float Minutes = Mathf.FloorToInt(Seconds / 60f);

        string mins = "0" + Minutes.ToString();
        string secs = "0" + Seconds.ToString();

        tempTime = string.Format("{0:0}:{1:00}", mins, secs); ; 
    }

    void HighScores()
    {
        if (score > HighScore)
        {
            score = HighScore;
            HiScore.SetActive(true);
        }

        if (TimeinSeconds > HighTime)
        {
            TimeinSeconds = HighTime;
            HiTime.SetActive(true);
        }
    }
}
