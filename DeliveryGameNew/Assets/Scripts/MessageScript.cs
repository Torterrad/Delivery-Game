using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    public float lowerTime = 0.25f;
    public float raiseTime = 2f;

    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + rt.rect.height, 0), 1f);
        //LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y + rt.rect.height, 0), 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrintJob()
    {
        //Debug.Log("rt.rect.height = " + rt.rect.height);
        MessageLower();
    }

    public void MessageLower()
    {
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y - rt.rect.height, 0), lowerTime).setOnComplete(() => MessageRaise());
    }

    public void MessageRaise()
    {
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + rt.rect.height, 0), raiseTime);
    }
}
