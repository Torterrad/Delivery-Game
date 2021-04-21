using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnims : MonoBehaviour
{
    public float scaleChange = 1.2f;
    public float scaleTime = 1f;

    public int rotateAngle = 360;
    public float rotateTime = 5f;

    void Start()
    {
        LeanTween.scale(gameObject, transform.localScale * scaleChange, scaleTime).setEaseInOutSine().setLoopPingPong();

        LeanTween.rotateAround(gameObject, Vector3.forward, rotateAngle, rotateTime).setLoopClamp();
    }
}
