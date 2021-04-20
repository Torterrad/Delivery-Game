using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsPopUp : MonoBehaviour
{
    TextMeshProUGUI text;
    RectTransform rt;
    Vector3 startScale;



    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
        startScale = rt.localScale;

        text.color = new Color(1f, 1f, 1f, 0f);
    }

    public void PopUp(float points)
    {
        text.text = "+" + points.ToString();

        text.color = new Color(1f, 1f, 1f, 1f);
        LeanTween.value(gameObject, setAlpha, 1f, 0f, 3f).setDelay(2f);

        rt.localScale = startScale * 0.9f;
        LeanTween.scale(rt, startScale * 1.2f, 0.4f).setEaseOutBack().setOnComplete(() => LeanTween.scale(rt, startScale, 1f).setEaseOutBack());
    }

    void setAlpha(float val)
    {
        text.color = new Color(1f, 1f, 1f, val);
    }
}
