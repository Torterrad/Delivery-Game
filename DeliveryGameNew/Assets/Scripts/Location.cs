using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public GameObject manager;
    public GameObject arrow;
    public GameObject pointsPopUp;

    void Start()
    {
        manager = GameObject.Find("GameManager");
        arrow = GameObject.Find("Arrow");
        pointsPopUp = GameObject.Find("PointsPopUp");

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "Pick Up" && other.tag == "Player")
        {
            SoundManager.PlaySound("CollectSound");
            manager.GetComponent<SpawnPickup>().needToDropOff = true;

            arrow.GetComponent<ArrowController>().lookingForPickup = false;
            arrow.GetComponent<ArrowController>().lookingForDropOff = true;
            Destroy(gameObject);
        }
        if (this.tag == "Drop Off" && other.tag == "Player")
        {
            SoundManager.PlaySound("CollectSound");
            arrow.GetComponent<ArrowController>().lookingForDropOff = false;
            arrow.GetComponent<ArrowController>().lookingForPickup = true;
            if (manager.GetComponent<Timer>().amountOfTimeAdded <= manager.GetComponent<Timer>().amountOfTimeAddedLock)
            {
                manager.GetComponent<Timer>().amountOfTimeAdded = manager.GetComponent<Timer>().amountOfTimeAddedLock;
                manager.GetComponent<Timer>().timeAmount += manager.GetComponent<Timer>().amountOfTimeAdded;

                pointsPopUp.GetComponent<PointsPopUp>().PopUp(manager.GetComponent<Timer>().amountOfTimeAdded);
            }
            else
            {
                manager.GetComponent<Timer>().timeAmount += manager.GetComponent<Timer>().amountOfTimeAdded;

                pointsPopUp.GetComponent<PointsPopUp>().PopUp(manager.GetComponent<Timer>().amountOfTimeAdded);

                manager.GetComponent<Timer>().amountOfTimeAdded -= manager.GetComponent<Timer>().amountOfTimeRemoved;
            }
            manager.GetComponent<Timer>().ordersCompleted += 1;
            manager.GetComponent<SpawnPickup>().needAJob = true;
            Destroy(gameObject);
        }
    }
}
