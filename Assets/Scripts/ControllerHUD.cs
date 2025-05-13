using UnityEngine;
using UnityEngine.UI;

public class ControllerHUD : MonoBehaviour
{
    [SerializeField] private Image characterName;
    [SerializeField] private Image characterPortrait;

    [SerializeField] private CharacterSO currentCharacterData;

    private void OnEnable()
    {
        CharacterSelecitonHUD.OnChangeCharacter += ChangeCharacter;
    }

    private void OnDisable()
    {
        CharacterSelecitonHUD.OnChangeCharacter -= ChangeCharacter;
    }

    public void ChangeCharacter(CharacterSO newData)
    {
        currentCharacterData.UpdateValues(newData);

        characterName.sprite = currentCharacterData.CharacterName;
        characterPortrait.sprite = currentCharacterData.CharacterSprite;
    }
}
