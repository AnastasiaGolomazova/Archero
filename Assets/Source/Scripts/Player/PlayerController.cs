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

    private Vector2 _movementInput;

    private float _horizont;

    private float _vertical;

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

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void RotaitionMove()
    {
        _animator.SetFloat("Horizon", _movementInput.x);
        _animator.SetFloat("Speed", _movementInput.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            _animator.SetFloat("LastHorizon", _movementInput.x);
        }
    }

}
