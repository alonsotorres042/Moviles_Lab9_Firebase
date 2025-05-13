using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils
{
    public class TestCustomWord : MonoBehaviour
    {
        [SerializeField] private CustomAlphabet alphabet;
        [SerializeField] private string customWord = "abcdefghijklmnopqrstuvwxyz -";
        [SerializeField] private Image[] images;
        [SerializeField] private bool useSimpleLayout = true;

        [Header("Custom Layout")]
        [SerializeField] private RectTransform pivotPoint;
        [SerializeField] private Vector3 spacing;

        private void Update()
        {
            if (useSimpleLayout)
            {
                SimpleLayout();
            }
            else
            {
                CustomLayout();
            }
        }

        private void SimpleLayout()
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i < customWord.Length)
                {
                    images[i].gameObject.SetActive(true);
                    images[i].sprite = alphabet.GetLetter(customWord[i]);
                }
                else
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }

        private void CustomLayout()
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i < customWord.Length)
                {
                    images[i].gameObject.SetActive(true);
                    images[i].sprite = alphabet.GetLetter(customWord[i]);
                    images[i].rectTransform.position = pivotPoint.position + (new Vector3(pivotPoint.rect.width, pivotPoint.rect.height / 2, 0f) + spacing) * i;
                }
                else
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }
}