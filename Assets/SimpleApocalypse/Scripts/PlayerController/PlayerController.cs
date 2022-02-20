using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    [SerializeField] Joystick _joystick;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * (speed * _joystick.Vertical());
        gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * (speed * _joystick.Horizontal());
    }
}