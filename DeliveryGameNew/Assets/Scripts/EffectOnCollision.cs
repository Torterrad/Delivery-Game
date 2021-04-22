using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnCollision : MonoBehaviour
{
    GameObject Player;
    public float speed;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.GetComponent<CarController>().speed >= 5f&& Player.GetComponent<CarController>().speed < 10f)
            {
                SoundManager.PlaySound("CrashSound");
                CinemachineShake.Instance.ShakeCamera(5f, .2f);
            }
            if (Player.GetComponent<CarController>().speed >= 10f)
            {
                SoundManager.PlaySound("CrashSound");
                CinemachineShake.Instance.ShakeCamera(8f, .5f);
            }

        }
    }
}
