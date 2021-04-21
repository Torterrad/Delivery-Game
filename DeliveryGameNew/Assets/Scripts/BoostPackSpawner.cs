using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPackSpawner : MonoBehaviour
{
    public GameObject boostPack;
    bool noPack = true;
    public float timer;
    public float maxTimer = 5f;
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (noPack)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = maxTimer;
            SpawnPack();
            noPack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            noPack = true;
        }
        
    }

    void SpawnPack()
    {
        Instantiate(boostPack, this.transform.position, this.transform.rotation);
    }
}
