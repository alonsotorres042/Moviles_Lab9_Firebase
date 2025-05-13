using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using Assets.Scripts.GameEvents;

public class RivalSelectionHUD : MonoBehaviour
{
    [Header("Rival Data")]
    [SerializeField] private CharacterSO rivalUpData;
    [SerializeField] private RivalHUD rivalUp;
    [SerializeField] private CharacterSO rivalDownData;
    [SerializeField] private RivalHUD rivalDown;

    [SerializeField] private bool upPosition;

    private bool _enableControl = false;

    [SerializeField] private GameEvent OnEnterRivalSelectionHUD;
    [SerializeField] private GameEvent OnConfirmRival;
    [SerializeField] private GameEvent OnChangeSelectorUp;
    [SerializeField] private GameEvent OnChangeSelectorDown;

    public static event Action<CharacterSO> OnSelectRival;

    private void Start()
    {
        _enableControl = true;

        rivalUp.SetUp(rivalUpData);
        rivalDown.SetUp(rivalDownData);

        OnEnterRivalSelectionHUD.Raise();
    }

    public void ChangeVertical(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (!context.performed) return;

        bool _currentChange = (int)context.ReadValue<float>() > 0;

        if(_currentChange != upPosition)
        {
            if (_currentChange)
            {
                OnChangeSelectorUp.Raise();
            }
            else
            {
                OnChangeSelectorDown.Raise();
            }

            upPosition = _currentChange;
        }
    }

    public void SelectRival(InputAction.CallbackContext context)
    {
        if (!_enableControl) return;

        if (context.performed)
        {

            if (upPosition)
            {
                OnSelectRival?.Invoke(rivalUpData);
            }
            else
            {
                OnSelectRival?.Invoke(rivalDownData);
            }

            OnConfirmRival.Raise();
        }
    }

    public void DisableMovement()
    {
        _enableControl = false;
    }
}
