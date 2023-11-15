using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private Button _attackButton;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private bool _isAttack = true;

    [SerializeField] private float _cooldown;

    private void Awake()
    {
        _attackButton.onClick.AddListener(Attack);
    }

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

        if(_joystick.Direction.x > 0 || _joystick.Direction.x < 0)
        {
            _animator.SetFloat("LastHorizon", _joystick.Direction.x);
        }
    }

    private void Attack()
    {
        if (_isAttack)
        {
            _animator.SetTrigger("Attack");
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        _isAttack = false;

        yield return new WaitForSeconds(_cooldown);

        _isAttack = true;
    }

}
