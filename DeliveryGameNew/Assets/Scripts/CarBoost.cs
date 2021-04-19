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

    public CarController carController;
    public float accFactorBoost = 100f;
    public float maxSpeedBoost = 40f;
    float accFactorStart;
    float maxSpeedStart;

    // Start is called before the first frame update
    void Start()
    {
        boostAmount = boostAmountMax;
        boostBar.SetMaxBoost(boostAmountMax);

        accFactorStart = carController.accFactor;
        maxSpeedStart = carController.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        carController.accFactor = accFactorStart;
        carController.maxSpeed = maxSpeedStart;

        if (Input.GetKey(KeyCode.Space) && boostAmount >= boostDecrease)
        {
            boostAmount -= boostDecrease;
            boostBar.SetBoost(boostAmount);

            //carController.accInput = 1f;//Car moves forward.
            carController.accFactor = accFactorBoost;
            carController.maxSpeed = maxSpeedBoost;
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
