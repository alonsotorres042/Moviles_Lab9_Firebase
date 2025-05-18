using TMPro;
using UnityEngine;

public class DataMessager : MonoBehaviour
{
    [SerializeField] TMP_InputField NameInput;
    [SerializeField] TMP_InputField LastNameInput;
    [SerializeField] private PlayerData playerData;

    private void Start()
    {
        NameInput.text = playerData.Name;
        LastNameInput.text = playerData.LastName;
    }
    public void UpdateDataSO(PlayerData playerData)
    {
        playerData.UpdateData(NameInput.text, LastNameInput.text);
    }
}