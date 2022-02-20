using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTouchpad : MonoBehaviour
{

    public Transform RotatableH;
    public Transform RotatableV;
    public float RotationSpeed = .1f;
    public bool InvertedV = true;
    public bool ClampedV = true;
    [SerializeField] Joystick _joystick;

    Vector2 _currentMousePosition;
    Vector2 _mouseDeltaPosition;
    Vector2 _lastMousePosition;

    [HideInInspector]
    public bool IsTouchPadActive;

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


            _mouseDeltaPosition = _currentMousePosition - _lastMousePosition;

            if (RotatableH != null)
                RotateH();
            if (RotatableV != null)
            {
                RotateV();
            }

            _lastMousePosition = _currentMousePosition;
        }
    }

    void RotateH()
    {
        RotatableH.transform.Rotate(0f, _mouseDeltaPosition.x * RotationSpeed, 0f);
    }

    void RotateV()
    {
        if (InvertedV)
        {
            RotatableV.transform.Rotate(Mathf.Clamp(_mouseDeltaPosition.y * (RotationSpeed * -1), -3, 3), 0f, 0f);
        }

        else
        {
            RotatableV.transform.Rotate(Mathf.Clamp(_mouseDeltaPosition.y * RotationSpeed, -3, 3), 0f, 0f);
        }


        if (ClampedV)
        {
            float limitedXRot = RotatableV.transform.localEulerAngles.x;
            if (limitedXRot > 45f && limitedXRot < 320f)
            {
                if (limitedXRot < 180f)
                    limitedXRot = 45f;
                else
                    limitedXRot = 320f;

            }
            RotatableV.transform.localEulerAngles = new Vector3(limitedXRot, RotatableV.transform.localEulerAngles.y, RotatableV.transform.localEulerAngles.z);
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