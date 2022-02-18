using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] EntityBlock _block;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;
    [SerializeField] InputActionReference _blockButton;

    Coroutine MovementTracking { get; set; }

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;
        _blockButton.action.started += BlockInput;
        _blockButton.action.canceled += BlockInputCancel;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;
    }

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;
        _blockButton.action.started -= BlockInput;
        _blockButton.action.canceled -= BlockInputCancel;

        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        if(fire==1 && _fire.CanFire)
        {
            _fire.FireBullet(2);
        }
    }

    private void BlockInput(InputAction.CallbackContext obj) {
        float block = obj.ReadValue<float>();
        if (block == 1) {
            _block.Block();
            _fire.CanFire = false;
        }
    }
    private void BlockInputCancel(InputAction.CallbackContext obj) {
        float block = obj.ReadValue<float>();
        if (block == 0) {
            _block.UnBlock();
            _fire.CanFire = true;
        }
    }

}
