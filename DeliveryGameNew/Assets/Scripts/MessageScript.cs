using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageScript : MonoBehaviour
{
    public float lowerTime = 0.25f;
    public float raiseTime = 2f;

    RectTransform rt;

    public TextMeshProUGUI text;
    string[] openings = new string[] { "Ay my man, ", "Yo yo, ", "Ay listen up, " };
    string[] collects = new string[] { "come pick up this ", "come grab this ", "come collect this " };
    string[] orders = new string[] { "large peperone.", "tripple cheese pie.", "this vegan stuff." };
    string[] affirmatives = new string[] { "Alright, ", "Good job, now ", "Magnifico, " };
    string[] locations = new string[] { "on alban street! ", "downtown! ", "on main street! ", "on old garden boulevard! " };
    string[] endings = new string[] { "Don't screw this up!", "Capeesh? ", "Get a move on!", "On the double!" };

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void PrintPickUp()
    {
        MessageLower();
        GeneratePickUp();
    }

    public void PrintDropOff()
    {
        MessageLower();
        GenerateDropOff();
    }

    public void MessageLower()
    {
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y - rt.rect.height, 0), lowerTime).setOnComplete(() => MessageRaise());
    }

    public void MessageRaise()
    {
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + rt.rect.height, 0), raiseTime);
    }

    public void GeneratePickUp()
    {
        text.text = openings[Random.Range(0, openings.Length)];
        text.text += collects[Random.Range(0, collects.Length)];
        text.text += orders[Random.Range(0, orders.Length)];
    }

    public void GenerateDropOff()
    {
        text.text = affirmatives[Random.Range(0, affirmatives.Length)];
        text.text += "deliver this to number " + Random.Range(0, 100) + " ";
        text.text += locations[Random.Range(0, locations.Length)];
        text.text += endings[Random.Range(0, endings.Length)];
    }
}
