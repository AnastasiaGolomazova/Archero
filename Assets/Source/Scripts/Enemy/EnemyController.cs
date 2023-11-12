using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 4;

    private Rigidbody2D _rigidbody;

    private GameObject _player;

    private Animator _animator;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_player.transform.position - this.transform.position).normalized;

        _rigidbody.MovePosition((Vector2)this.transform.position + direction * _speed * Time.deltaTime);

        _animator.SetBool("IsMoving", true);
    }
}
