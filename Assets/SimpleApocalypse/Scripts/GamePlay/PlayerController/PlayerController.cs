using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform _rotatableH;
    [SerializeField] Transform _rotatableV;
    public float RotationSpeed = .1f;
    public float speed;
    private Rigidbody _rb;
    Joystick _joystick;
    bool _checkMove = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetPlayerJoystick(Joystick joyStick)
    {
        _joystick = joyStick;
        _checkMove = true;
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
}