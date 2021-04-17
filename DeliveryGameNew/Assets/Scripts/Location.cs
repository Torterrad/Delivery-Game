using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public GameObject manager;
   
    
    void Start()
    {
        manager = GameObject.Find("GameManager");
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "Pick Up" && other.tag == "Player")
        {
            manager.GetComponent<SpawnPickup>().needToDropOff = true;
            Destroy(gameObject);
        }
        if (this.tag == "Drop Off" && other.tag == "Player")
        {

            if(manager.GetComponent<Timer>().amountOfTimeAdded<= manager.GetComponent<Timer>().amountOfTimeAddedLock)
            {
                manager.GetComponent<Timer>().amountOfTimeAdded = manager.GetComponent<Timer>().amountOfTimeAddedLock;
                manager.GetComponent<Timer>().timeAmount += manager.GetComponent<Timer>().amountOfTimeAdded;
            }
            else
            {
                manager.GetComponent<Timer>().timeAmount += manager.GetComponent<Timer>().amountOfTimeAdded;
                manager.GetComponent<Timer>().amountOfTimeAdded -= manager.GetComponent<Timer>().amountOfTimeRemoved;
            }
            manager.GetComponent<SpawnPickup>().needAJob = true;
            Destroy(gameObject);
        }
    }
}
