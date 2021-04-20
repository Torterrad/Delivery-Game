using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPed : MonoBehaviour
{
    GameObject manager;
    GameObject player;
    public ParticleSystem blood;
    public GameObject holder;
    public SpriteRenderer rend;
    public Collider2D collider;

    private float maxTimer = 2f;
    private float timer;
    bool dead = false;
    void Start()
    {
        manager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        timer = maxTimer;
        rend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (dead)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Destroy(gameObject);
            Destroy(holder);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&& player.GetComponent<CarController>().speed>=5f)
        {
            blood.Play();
            
            manager.GetComponent<SpawnPickup>().needToDropOff = true;
            manager.GetComponent<Timer>().timeAmount -= 10;
            dead = true;
            //gameObject.SetActive(false);
            rend.enabled = false;
            collider.enabled = false;
        }
    }
}
