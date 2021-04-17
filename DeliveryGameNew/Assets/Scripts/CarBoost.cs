using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBoost : MonoBehaviour
{
    public float boostAmount;
    public float boostAmountMax = 100f;
    public float accFactorBoost = 100f;
    public float maxSpeedBoost = 40f;
    public float accFactorStart;
    public float maxSpeedStart;

    // Start is called before the first frame update
    void Start()
    {
        boostAmount = boostAmountMax;

        accFactorStart = GetComponent<CarController>().accFactor;
        maxSpeedStart = GetComponent<CarController>().maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<CarController>().accFactor = accFactorBoost;
            GetComponent<CarController>().maxSpeed = maxSpeedBoost;
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
}
