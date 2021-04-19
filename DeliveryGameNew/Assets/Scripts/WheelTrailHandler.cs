using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailHandler : MonoBehaviour
{
    CarController carController;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        carController = GetComponentInParent<CarController>();

        trailRenderer = GetComponent<TrailRenderer>();

        trailRenderer.emitting = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carController.isCarDrifting(out float lateralVelocity, out bool isBreaking))
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }
}
