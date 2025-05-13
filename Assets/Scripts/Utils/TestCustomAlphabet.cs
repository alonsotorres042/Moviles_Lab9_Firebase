using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils
{
    public class TestCustomAlphabet : MonoBehaviour
    {
        [SerializeField] private CustomAlphabet alphabet;
        [SerializeField] private string alphabetString = "abcdefghijklmnopqrstuvwxyz -";
        [SerializeField] private Image[] images;

        private void Start()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].sprite = alphabet.GetLetter(alphabetString[i]);
            }
        }
    }
}