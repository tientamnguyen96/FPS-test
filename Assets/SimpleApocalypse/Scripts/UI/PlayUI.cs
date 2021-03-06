using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Personal.Common.UI;
using Personal.UI;

public class PlayUI : UIController
{
    [SerializeField] Joystick _joyStick;
    [SerializeField] RotationTouchpad _rotate;
    public System.Action OnJump;
    public System.Action OnChangeGun;
    public System.Action OnFire;
    public System.Action OnFinishFire;

    public void SubscribeRotate(System.Action<Vector2> onRotate)
    {
        _rotate.OnRotate += onRotate;
    }

    public Joystick GetJoystick()
    {
        return _joyStick;
    }

    public void ClickJump()
    {
        OnJump?.Invoke();
    }

    public void ChangeGun()
    {
        OnChangeGun?.Invoke();
    }

    public void Fire()
    {
        OnFire?.Invoke();
    }

    public void FinishFire()
    {
        OnFinishFire?.Invoke();
    }
}
