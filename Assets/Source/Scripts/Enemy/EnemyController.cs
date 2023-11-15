using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    [SerializeField] private float _stopRange = 0.3f;

    private Rigidbody2D _rigidbody;

    private GameObject _player;

    private Animator _animator;

    private float _lastSpeed;


    private void Awake()
    {
        _lastSpeed = _speed;
        _player = GameObject.FindWithTag("Player");
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(_player.transform.position, _rigidbody.transform.position) <= _stopRange)
        {
            _speed = 0;
            _animator.SetBool("IsMoving", false);
        }
        else
        {
            _speed = _lastSpeed;
            Vector2 direction = (_player.transform.position - this.transform.position).normalized;

            _rigidbody.MovePosition((Vector2)this.transform.position + direction * _speed * Time.deltaTime);

            _animator.SetBool("IsMoving", true);
        }
    }
}
