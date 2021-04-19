using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 65f;
        for (int i = 0; i< 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;

            switch (rank)
            {
                default: rankString = rank + "TH"; break;

                case 1: rankString = "1ST "; break;
                case 2: rankString = "2ND "; break;
                case 3: rankString = "3RD "; break;
            }

            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

            int score = Random.Range(0, 20);
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

            string name = "AAA";
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
        }

    }
}
