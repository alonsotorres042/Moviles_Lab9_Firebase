using UnityEngine;
using UnityEngine.UI;

public class CharacterSlotHUD : MonoBehaviour
{
    [SerializeField] private Image slotCharacter;
    [SerializeField] private RectTransform slotTransform;
    [SerializeField] private CharacterSO slotCharacterData;

    private void Start()
    {
        slotCharacter = GetComponent<Image>();
        slotTransform = GetComponent<RectTransform>();

        slotCharacter.sprite = slotCharacterData.CharacterLogo;
    }

    public CharacterSO GetCharacterSlotData()
    {
        return slotCharacterData;
    }

    public Vector3 GetSlotPosition()
    {
        return slotTransform.position;
    }
}
