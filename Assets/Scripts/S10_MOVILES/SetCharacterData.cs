using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;
using TMPro;

namespace Assets.FirebaseScripts
{
    public class SetCharacterData : MonoBehaviour
    {
        [SerializeField] private string _characterPath = "correosInsanos/Alonso";
        //[SerializeField] private TMP_InputField nameField;
        //[SerializeField] private TMP_InputField lastNameField;
        [SerializeField] private PlayerData playerData;

        //[SerializeField] private Button submitButton;

        private void OnEnable()
        {
           // submitButton.onClick.AddListener(ProcessData);
        }

        private void OnDisable()
        {
           // submitButton.onClick.RemoveListener(ProcessData);
        }

        public void ProcessData()
        {
            CharacterData characterData = new CharacterData
            {
                Name = playerData.Name,
                LastName = playerData.LastName,
                LastScore = playerData.lastScore,
            };

            var firestore = FirebaseFirestore.DefaultInstance;

            firestore.Document(_characterPath).SetAsync(characterData);
        }

    }

    [FirestoreData]
    public struct CharacterData
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string LastName { get; set; }

        [FirestoreProperty]
        public int LastScore { get; set; }
    }
}