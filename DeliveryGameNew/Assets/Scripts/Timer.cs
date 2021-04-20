using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeAmount;
    public float amountOfTimeAdded = 5f;
    public float amountOfTimeRemoved = 1f;
    public float amountOfTimeAddedLock = 2f;

    public int ordersCompleted;
    public TextMeshProUGUI text;

    public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        if(timeAmount > 0)
        {
            timeAmount -= Time.deltaTime;
        }
        else if (timeAmount == 0)
        {
            timeAmount = -1;
            gameOver.GetComponent<GameoverScript>().Gameover();
        }
        DisplayTime(timeAmount);
    }

    void DisplayTime(float display)
    {
        if(display < 0)
        {
            display = 0;
        }
        else if (display > 0)
        {
            display += 1;
        }

        float mins = Mathf.FloorToInt(display / 60);
        float secs = Mathf.FloorToInt(display % 60);

        text.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
}
