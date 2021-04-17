using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBoost : MonoBehaviour
{
    public BoostBar boostBar;

    public float boostAmount;
    public float boostAmountMax = 1000f;
    public float boostDecrease = 1f;
    public float boostIncrease = 200f;

    public float accFactorBoost = 100f;
    public float maxSpeedBoost = 40f;
    public float accFactorStart;
    public float maxSpeedStart;

    // Start is called before the first frame update
    void Start()
    {
        boostAmount = boostAmountMax;
        boostBar.SetMaxBoost(boostAmountMax);

        accFactorStart = GetComponent<CarController>().accFactor;
        maxSpeedStart = GetComponent<CarController>().maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (boostAmount >= boostDecrease)
            {
                boostAmount -= boostDecrease;

                GetComponent<CarController>().accFactor = accFactorBoost;
                GetComponent<CarController>().maxSpeed = maxSpeedBoost;

                boostBar.SetBoost(boostAmount);
            }
        }
        else
        {
            GetComponent<CarController>().accFactor = accFactorStart;
            GetComponent<CarController>().maxSpeed = maxSpeedStart;
        }

        if (boostAmount > boostAmountMax)
        {
            boostAmount = boostAmountMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BoostPack")
        {
            boostAmount += boostIncrease;
            boostBar.SetBoost(boostAmount);

            other.gameObject.SetActive(false);
        }
    }
}
