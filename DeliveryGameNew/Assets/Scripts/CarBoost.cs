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

    // Start is called before the first frame update
    void Start()
    {
        boostAmount = boostAmountMax;
        boostBar.SetMaxBoost(boostAmountMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && boostAmount >= boostDecrease)
        {
            boostAmount -= boostDecrease;
            boostBar.SetBoost(boostAmount);
        }

        if (boostAmount > boostAmountMax)
        {
            boostAmount = boostAmountMax;
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && (boostAmount >= boostDecrease))
        {
            accelerate.ChangePitchUp();
        }
        if ((Input.GetKeyUp(KeyCode.Space)) || boostAmount <= boostDecrease)
        {
            accelerate.ChangePitchDown();

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
