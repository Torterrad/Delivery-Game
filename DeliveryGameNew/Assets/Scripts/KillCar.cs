using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCar : MonoBehaviour
{
    GameObject manager;
    GameObject player;
    public ParticleSystem explosion;
    public GameObject holder;
    public GameObject rend;
    public Collider2D collider;
    private float maxTimer = 2f;
    private float timer;
    bool dead = false;

    public float penalty = -20f;
    public GameObject lossPointsPopUp;

    void Start()
    {
        manager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        timer = maxTimer;
        //rend = GetComponent<SpriteRenderer>();

        lossPointsPopUp = GameObject.Find("LossPointsPopUp");
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
        if (other.tag == "Player" && player.GetComponent<CarController>().speed >= 12f)
        {
            explosion.Play();
            SoundManager.PlaySound("Explosion");
            //manager.GetComponent<SpawnPickup>().needToDropOff = true;
            manager.GetComponent<Timer>().timeAmount += penalty;
            dead = true;
            rend.SetActive(false);
            //rend.enabled = false;
            collider.enabled = false;

            lossPointsPopUp.GetComponent<LossPointsPopUp>().PopUp(penalty);
        }
        if (other.tag == "Player")
        {
            CinemachineShake.Instance.ShakeCamera(4f, .2f);
        }


    }
}
