using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float JumpSpeed = 3f;
    public float JumpDelay = 2f;

    private bool _canjump;
    private bool _isjumping;
    private Rigidbody _rb;
    private float _countDown;

    // Start is called before the first frame update
    void Start()
    {
        _canjump = true;
        _rb = GetComponent<Rigidbody>();
        _countDown = JumpDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isjumping && _countDown > 0)
            _countDown -= Time.deltaTime;
        else
        {
            _canjump = true;
            _isjumping = false;
            _countDown = JumpDelay;
        }

    }

    public void StartJump()
    {
        if (_canjump)
        {
            _canjump = false;
            _isjumping = true;
            _rb.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
        }
    }

}
