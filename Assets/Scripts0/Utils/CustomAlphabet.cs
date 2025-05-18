using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [CreateAssetMenu(fileName = "Custom Alphabet", menuName = "Utils/SOs/CustomAlphabet")]
    public class CustomAlphabet : ScriptableObject
    {
        [SerializeField] private List<Letter> listAlphabet;

        private Dictionary<char, Sprite> _customAlphabet;

        private void OnEnable()
        {
            SetUp();
        }

        private void OnDisable()
        {
            _customAlphabet.Clear();
        }

        private void SetUp()
        {
            _customAlphabet = listAlphabet.ToDictionary(x => x.letter, x => x.sprite);
        }

        public Sprite GetLetter(char letter)
        {
            letter = char.ToUpper(letter);

            return _customAlphabet[letter];
        }
    }

    [System.Serializable]
    public struct Letter
    {
        public char letter;
        public Sprite sprite;
    }
}