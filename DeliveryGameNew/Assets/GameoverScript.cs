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
        Background.SetActive(true);
        GameOverMessage.SetActive(true);
        HUD.SetActive(false);
        Invoke("results", 1.0f);
    }

    public void Results()
    {
        //Grab Scores() 

        //Disable Gameover message
        GameOverMessage.SetActive(false);
        //Enable Results screen
        Result.SetActive(true);

    }

    public void GrabScores()
    {
        //Grab scores 
        //Grab prev 

        //apply to text objects
    }


}
