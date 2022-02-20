using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GunType
{
    None = 0,
    Rifle = 1,
    HandGun = 2
}

public class PlayerController : MonoBehaviour, IAnimHandleLogic
{
    [SerializeField] Transform _rotatableH;
    [SerializeField] Transform _rotatableV;
    [SerializeField] Transform _rifleArm;
    [SerializeField] Transform _handGunArm;

    public float RotationSpeed = .1f;
    public float speed;
    private Rigidbody _rb;
    Joystick _joystick;
    GunType _currentGun = GunType.HandGun;
    Animator _currentAnimator;
    Transform _currentArm;
    AnimationHandler _animHandler;
    bool _checkMove = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentGun = GunType.HandGun;
        _rotatableV = _handGunArm;
        _currentArm = _handGunArm;
        _currentAnimator = _currentArm.GetComponent<Animator>();
        _animHandler = new AnimationHandler(this);
    }

    public void SetPlayerJoystick(Joystick joyStick)
    {
        _joystick = joyStick;
        _checkMove = true;
    }

    public void PlayCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

    void FixedUpdate()
    {
        if (_checkMove)
            Move();
    }

    void Move()
    {
        gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * (speed * _joystick.Vertical());
        gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * (speed * _joystick.Horizontal());
    }

    public void RotateH(Vector2 mousePosition)
    {
        _rotatableH.transform.Rotate(0f, mousePosition.x * RotationSpeed, 0f);
    }

    public void RotateV(Vector2 mousePosition)
    {
        _rotatableV.transform.Rotate(Mathf.Clamp(mousePosition.y * (RotationSpeed * -1), -3, 3), 0f, 0f);


        float limitedXRot = _rotatableV.transform.localEulerAngles.x;
        if (limitedXRot > 45f && limitedXRot < 320f)
        {
            if (limitedXRot < 180f)
                limitedXRot = 45f;
            else
                limitedXRot = 320f;

        }
        _rotatableV.transform.localEulerAngles = new Vector3(limitedXRot, _rotatableV.transform.localEulerAngles.y, _rotatableV.transform.localEulerAngles.z);
    }

    public void Fire()
    {
        _animHandler.Fire(_currentArm);
    }

    public void ChangeGun()
    {
        var previousArm = _currentArm;

        switch (_currentGun)
        {
            case GunType.HandGun:
                _currentGun = GunType.Rifle;
                _rotatableV = _rifleArm;
                _currentArm = _rifleArm;

                break;
            case GunType.Rifle:
                _currentGun = GunType.HandGun;
                _rotatableV = _handGunArm;
                _currentArm = _handGunArm;
                break;
        }

        _animHandler.ChangeGun(previousArm, _currentArm);
        _currentAnimator = _currentArm.GetComponent<Animator>();
    }
}