using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverScript : MonoBehaviour
{

    public int score;
    public float time;

    public int PrevScore;
    public int PrevTime;

    public GameObject Background;
    public GameObject GameOverMessage;
    public GameObject HUD;
    public GameObject Result;

    public GameObject GameHandler;

    public void Gameover()
    {
        Time.timeScale = 0.1f;
        Background.SetActive(true);
        GameOverMessage.SetActive(true);
        HUD.SetActive(false);
        Invoke("Results", 0.1f);
    }

    public void Results()
    {
        GameOverMessage.SetActive(false);
        Time.timeScale = 0f;

        GrabScores();
        
        Result.SetActive(true);

    }

    public void GrabScores()
    {
        //Grab scores 
        //Grab prev 

        //apply to text objects
    }


}
