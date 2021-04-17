using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car")]
    public float accFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.95f;
    public float maxSpeed = 20;


    float accInput = 0;
    float steerInput = 0;

    float rotAngle = 0;

    float VelocityUp = 0;

    Rigidbody2D carRb;

    private void Awake()
    {
        carRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ScreenShakeController.instance.StartShake(.2f, 5f);
    }

    private void FixedUpdate()
    {
        EngineForce();
        DampenMovement();
        Steering();
        if (Input.GetKey(KeyCode.Q))
        {
            ScreenShakeController.instance.StartShake(1f, .1f);
        }
    }

    void EngineForce()
    {
        VelocityUp = Vector2.Dot(transform.up, carRb.velocity);

        if(VelocityUp > maxSpeed && accInput > 0)
        {
            return;
        }
        if(VelocityUp < -maxSpeed * 0.5f && accInput < 0)
        {
            return;
        }

        if(carRb.velocity.sqrMagnitude> maxSpeed * maxSpeed && accInput > 0)
        {
            return;
        }

        if(accInput == 0)
        {
            carRb.drag = Mathf.Lerp(carRb.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRb.drag = 0;
        }

        Vector2 forceVector = transform.up * accInput * accFactor;

        carRb.AddForce(forceVector, ForceMode2D.Force);
    }

    void Steering()
    {
        float minSpeedToTurn = (carRb.velocity.magnitude / 8);
        minSpeedToTurn = Mathf.Clamp01(minSpeedToTurn);

        rotAngle -= steerInput * turnFactor * minSpeedToTurn;

        carRb.MoveRotation(rotAngle);
    }

    public void SetInputVec(Vector2 inputVec)
    {
        steerInput = inputVec.x;
        accInput = inputVec.y;
    }

    void DampenMovement()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRb.velocity, transform.right);

        carRb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

}
