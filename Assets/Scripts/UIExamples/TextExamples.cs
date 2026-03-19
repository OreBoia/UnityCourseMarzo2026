using TMPro;
using UnityEngine;

public class TextExamples : MonoBehaviour
{
    public TextMeshProUGUI MyText;

    void Start()
    {
        MyText = GetComponent<TextMeshProUGUI>();
        MyText.text = "ciao";
        MyText.alignment = TextAlignmentOptions.Center;
        MyText.color = Random.ColorHSV(0f, 1f);
        MyText.fontSize = 100f;
        MyText.characterSpacing = 50f;
    }
}