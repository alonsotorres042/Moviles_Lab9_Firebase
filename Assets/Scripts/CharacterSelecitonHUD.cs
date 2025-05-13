using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Assets.Scripts.GameEvents;

public class CharacterSelecitonHUD : MonoBehaviour
{
    [Header("Elements HUD")]
    [SerializeField] private List<CharacterSlotHUD> characterSlots;
    [SerializeField] private RectTransform selectorItem;
    [SerializeField] private int currentPosition;

    private bool _enableControl = false;

    [SerializeField] private GameEvent OnChangeSelector;
    [SerializeField] private GameEvent OnSelectCharacter;

    public static event Action<CharacterSO> OnChangeCharacter;

    private void Start()
    {
        selectorItem.position = characterSlots[currentPosition].GetSlotPosition();

        OnChangeCharacter?.Invoke(characterSlots[currentPosition].GetCharacterSlotData());

        _enableControl = true;
    }

    public void ChangeVertical(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (!context.performed) return;

        int modifier = (int)context.ReadValue<float>();

        int realPosition = currentPosition + modifier * 3;
        int newPosition = Mathf.Clamp(realPosition, 0, characterSlots.Count - 1);

        int difference = realPosition - newPosition;

        if(difference != 0)
        {
            if(difference > 0)
            {
                newPosition = difference % 3;
            }
            else
            {
                newPosition = (characterSlots.Count - 1) + difference % 3;
            }
        }

        currentPosition = newPosition;

        selectorItem.position = characterSlots[currentPosition].GetSlotPosition();

        OnChangeCharacter?.Invoke(characterSlots[currentPosition].GetCharacterSlotData());

        OnChangeSelector.Raise();
    }

    public void ChangeHorizontal(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (!context.performed) return;

        int modifier = (int)context.ReadValue<float>();

        int realPosition = currentPosition + modifier;
        int newPosition = Mathf.Clamp(realPosition, 0, characterSlots.Count - 1);

        int difference = realPosition - newPosition;

        if (difference != 0)
        {
            if (difference > 0)
            {
                newPosition = 0;
            }
            else
            {
                newPosition = (characterSlots.Count - 1);
            }
        }

        currentPosition = newPosition;

        selectorItem.position = characterSlots[currentPosition].GetSlotPosition();

        OnChangeCharacter?.Invoke(characterSlots[currentPosition].GetCharacterSlotData());

        OnChangeSelector.Raise();
    }

    public void SelectCharacter(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (context.performed)
        {
            OnSelectCharacter.Raise();
        }
    }

    public void DisableMovement()
    {
        _enableControl = false;
    }
}
