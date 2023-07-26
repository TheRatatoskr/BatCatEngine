using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerControls;
[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/InputReader")]

public class InputReader : ScriptableObject, IInBattleActions
{
    private PlayerControls _controls;

    public event Action<bool> PrimaryFireEvent;
    public event Action<Vector2> MoveEvent;

    public Vector2 AimPosition { get; private set; }

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new PlayerControls();
            _controls.InBattle.SetCallbacks(this);
        }
        _controls.InBattle.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PrimaryFireEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            PrimaryFireEvent?.Invoke(false);
        }
        
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        AimPosition = context.ReadValue<Vector2>();
    }
}
