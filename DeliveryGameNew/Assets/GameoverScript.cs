using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverScript : MonoBehaviour
{
    //Score Components
    int score;
    float TimeinSeconds;

    int PrevScore;
    float PrevTime;

    float HighTime;
    int HighScore;

    //Text Components
    string tempTime;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI PscoreText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI PTimeText;

    //UI Components
    public GameObject Background;
    public GameObject GameOverMessage;
    public GameObject HUD;
    public GameObject Result;

    public GameObject HiScore;
    public GameObject HiTime;
    public GameObject HiPScore;
    public GameObject HiPTime;

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
        PscoreText.text = PrevScore.ToString();
        Result.SetActive(true);
    }

    void GrabScores()
    {
        //Grab scores 
        score = GameHandler.GetComponent<Timer>().ordersCompleted;
        //PrevScore = PlayerPrefs.GetInt("Score");

        //Calculate time
        CalculateTime(TimeinSeconds);
        Debug.Log("tempTime");
        TimeText.text = tempTime;

        CalculateTime(PrevTime);
        Debug.Log("tempTime");
        PTimeText.text = tempTime;

        //Set PlayerPrefs
        //PrevScore = PlayerPrefs.SetInt("PrevScore", score);
        //PrevTime
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

    //Bugged
    /*void HighScores()
    {
        if (PrevScore > HighScore)
        {
            PrevScore = HighScore;
            HiPScore.SetActive(true);
        }
        else if (score > HighScore)
        {
            score = HighScore;
            HiScore.SetActive(true);
        }
        if (PrevTime > HighTime)
        {
            PrevTime = HighTime;
            HiPTime.SetActive(true);
        }
        else if (TimeinSeconds > HighTime)
        {
            TimeinSeconds = HighTime;
        }
    }
    */
}
