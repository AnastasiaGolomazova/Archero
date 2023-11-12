using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    [SerializeField] private FixedJoystick _joystick;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RotaitionMove();
        _rigidbody.MovePosition(_rigidbody.position + _joystick.Direction * _speed * Time.deltaTime);
    }

    private void RotaitionMove()
    {
        _animator.SetFloat("Horizon", _joystick.Direction.x);
        _animator.SetFloat("Speed", _joystick.Direction.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            _animator.SetFloat("LastHorizon", Input.GetAxisRaw("Horizontal"));
        }
    }

}
