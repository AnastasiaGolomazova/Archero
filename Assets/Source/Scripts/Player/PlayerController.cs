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
        _rigidbody.velocity = new Vector2(_joystick.Horizontal * _speed, _joystick.Vertical * _speed);
    }

    private void RotaitionMove()
    {
        if (_rigidbody.velocity.x > 0)
        {
            _animator.SetFloat("LastHorizon", 1);
            _animator.SetFloat("Speed", 1);
        }
        else if (_rigidbody.velocity.x < 0)
        {
            _animator.SetFloat("LastHorizon", -1);
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }

}
