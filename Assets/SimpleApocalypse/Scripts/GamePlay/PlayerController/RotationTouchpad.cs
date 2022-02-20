using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTouchpad : MonoBehaviour
{
    public bool InvertedV = true;
    [SerializeField] Joystick _joystick;

    Vector2 _currentMousePosition;
    Vector2 _mouseDeltaPosition;
    Vector2 _lastMousePosition;

    [HideInInspector]
    public bool IsTouchPadActive;
    public System.Action<Vector2> OnRotate;

    private void Start()
    {
        ResetMousePosition();
    }

    public void ResetMousePosition()
    {
        if (Input.touchCount == 1)
        {
            if (!_joystick.started)
            {
                _currentMousePosition = Input.GetTouch(0).position;
            }
        }
        else if (Input.touchCount == 2)
        {

            if (!_joystick.started)
            {
                _currentMousePosition = Input.GetTouch(1).position;
            }
            else
            {
                _currentMousePosition = Input.GetTouch(0).position;
            }
        }
        else
        {
            _currentMousePosition = Input.mousePosition;
        }

        _lastMousePosition = _currentMousePosition;
        _mouseDeltaPosition = _currentMousePosition - _lastMousePosition;
    }

    void LateUpdate()
    {
        if (IsTouchPadActive)
        {
            if (Input.touchCount == 1)
            {
                if (!!_joystick.started)
                {
                    _currentMousePosition = Input.GetTouch(0).position;
                }
            }
            else if (Input.touchCount == 2)
            {

                if (!_joystick.started)
                {
                    _currentMousePosition = Input.GetTouch(1).position;
                }
                else
                {
                    _currentMousePosition = Input.GetTouch(0).position;
                }
            }
            else
            {
                _currentMousePosition = Input.mousePosition;
            }


            OnRotate?.Invoke(_mouseDeltaPosition);

            _mouseDeltaPosition = _currentMousePosition - _lastMousePosition;
            _lastMousePosition = _currentMousePosition;
        }
    }

    public void ActivateTouchpad()
    {
        ResetMousePosition();
        IsTouchPadActive = true;
    }

    public void DeactivateTouchpad()
    {
        IsTouchPadActive = false;
    }
}