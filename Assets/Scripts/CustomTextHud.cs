using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

public class CustomTextHud : MonoBehaviour
{
    [Header("Font Data")]
    [SerializeField] private CustomAlphabet alphabet;
    [SerializeField] private Image[] images;

    [Header("Custom Positioning")]
    [SerializeField] private RectTransform pivotPoint;
    [SerializeField] private Vector3 spacing;

    public void SetUp(string customText)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i < customText.Length)
            {
                images[i].gameObject.SetActive(true);
                images[i].sprite = alphabet.GetLetter(customText[i]);
                images[i].rectTransform.position = pivotPoint.position + (new Vector3(pivotPoint.rect.width, pivotPoint.rect.height / 2, 0f) + spacing) * i;
            }
            else
            {
                images[i].gameObject.SetActive(false);
            }
        }
    }
}