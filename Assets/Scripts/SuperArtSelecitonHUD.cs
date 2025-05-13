using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using Assets.Scripts.GameEvents;

public class SuperArtSelecitonHUD : MonoBehaviour
{
    [Header("Selection Data")]
    [SerializeField] private CharacterSO currentCharacterData;
    [SerializeField] private int currentPosition = 0;

    private bool _enableControl = false;

    [SerializeField] private GameEvent OnSelectSuperArt;

    [SerializeField] private GameEvent OnChangeSelectorUp;
    [SerializeField] private GameEvent OnChangeSelectorDown;

    public static event Action<SuperArt> OnChangeArt;

    private void Start()
    {
        OnChangeArt?.Invoke(currentCharacterData.GetArt(currentPosition));
        _enableControl = true;
    }

    public void ChangeVertical(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (!context.performed) return;

        int modifier = (int)context.ReadValue<float>();

        if(modifier < 0)
        {
            currentPosition = (currentPosition - modifier) % 3;

            OnChangeSelectorDown.Raise();
        }
        else
        {
            currentPosition = currentPosition - modifier < 0 ? 2 : currentPosition - modifier;

            OnChangeSelectorUp.Raise();
        }

        OnChangeArt?.Invoke(currentCharacterData.GetArt(currentPosition));
    }

    public void SelectArt(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (context.performed)
        {
            OnSelectSuperArt.Raise();
        }
    }

    public void DisableMovement()
    {
        _enableControl = false;
    }
}