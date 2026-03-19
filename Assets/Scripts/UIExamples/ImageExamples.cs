using UnityEngine;
using UnityEngine.UI;

public class ImageExamples : MonoBehaviour
{
    public Image Image;
    public Sprite MySprite;

    void Start()
    {
        Image = GetComponent<Image>();

        Image.color = Random.ColorHSV(0f , 1f);
        Image.sprite = MySprite;

        Image.type = Image.Type.Sliced;

        Image.fillAmount = 0.5f; 
    }
}