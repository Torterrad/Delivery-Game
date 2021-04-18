using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPed : MonoBehaviour
{
    GameObject manager;
    GameObject player;
    void Start()
    {
        manager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&& player.GetComponent<CarController>().speed>=10)
        {
            manager.GetComponent<SpawnPickup>().needToDropOff = true;
            manager.GetComponent<Timer>().timeAmount -= 10;
            Destroy(gameObject);
        }
    }
}
