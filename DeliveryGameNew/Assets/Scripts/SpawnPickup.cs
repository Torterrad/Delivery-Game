using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    public Transform[] pickUpLocationSP;
    public Transform[] dropOffLocationsSP;
    public GameObject pickUpObject;
    public GameObject dropOffLocation;

    public bool needAJob;
    public bool needToDropOff = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (needAJob)
        {
            SpawnPickUp();
            needAJob = false;
        }
        if (needToDropOff)
        {
            SpawnDropOff();
            needToDropOff = false;
        }
    }

    public void SpawnPickUp()
    {
        Transform sp = pickUpLocationSP[Random.Range(0, pickUpLocationSP.Length)];

        Instantiate(pickUpObject, sp.position, sp.rotation);
    }
    public void SpawnDropOff()
    {
        Transform sp = dropOffLocationsSP[Random.Range(0, pickUpLocationSP.Length)];

        Instantiate(dropOffLocation, sp.position, sp.rotation);
    }
}
