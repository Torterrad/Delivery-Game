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

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("highScore");
        HighTime = PlayerPrefs.GetFloat("highTime");
    }
    
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

        Result.SetActive(true);
    }

    void GrabScores()
    {
        //Grab scores 
        score = GameHandler.GetComponent<Timer>().ordersCompleted;

        HighScores();
        //Calculate time
        CalculateTime(TimeinSeconds);
        TimeText.text = tempTime;

        scoreText.text = score.ToString();
        HighscoreText.text = HighScore.ToString();

        CalculateTime(HighTime);
        HighTimeText.text = tempTime;
    }

    void CalculateTime(float Seconds)
    {
        float Minutes = Mathf.FloorToInt(Seconds / 60f);
        Seconds = Mathf.FloorToInt(Seconds - Minutes * 60);

        tempTime = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }

    void HighScores()
    {
        if (score>HighScore)
        {
            HighScore = score;
            HiScore.SetActive(true);
            PlayerPrefs.SetInt("highScore", HighScore);

        }

        if (TimeinSeconds>HighTime)
        {
            HighTime = TimeinSeconds;
            HiTime.SetActive(true);
            PlayerPrefs.SetFloat("highTime", HighTime);
        }
    }
}
