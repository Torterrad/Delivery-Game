using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Transform focus;
    public bool lookingForPickup = true;
    public bool lookingForDropOff = false;
    public GameObject player;
    private GameObject dropOffPoint;
    private GameObject pickUpPoint;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        if (lookingForPickup)
        {
            pickUpPoint = GameObject.FindGameObjectWithTag("Pick Up");
            focus = pickUpPoint.transform;
        }
        if (lookingForDropOff)
        {
            dropOffPoint = GameObject.FindGameObjectWithTag("Drop Off");
            focus = dropOffPoint.transform;
        }
        Vector3 direction = focus.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        direction.Normalize();
    }
}
