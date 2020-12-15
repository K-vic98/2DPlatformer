using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _rayDistance;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private RaycastHit2D _checkGroundRay;
    private Vector3 _leftFlip = new Vector3(0, 180, 0);
    private Vector2 _horizontalVelocity;
    private float _horizontalSpeed;
    private float _verticalSpeed;
    private float _signPreviosFrame;
    private float _signCurrentFrame;
    private bool _isGround;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        _verticalSpeed = Input.GetAxis("Vertical");
        StateUpdate();
        Flip();
        Jump();
        Animate();
    }

    private void Move()
    {
        _horizontalVelocity.Set(_horizontalSpeed * _moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = _horizontalVelocity;
    }

    private void Flip()
    {
        _signCurrentFrame = _horizontalSpeed == 0 ? _signPreviosFrame : Mathf.Sign(_horizontalSpeed);
        if (_signCurrentFrame != _signPreviosFrame)
        {
            transform.rotation = Quaternion.Euler(_horizontalSpeed < 0 ? _leftFlip : Vector3.zero);
        }
        _signPreviosFrame = _signCurrentFrame;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void StateUpdate()
    {
        _checkGroundRay = Physics2D.Raycast(transform.position, -Vector2.up, _rayDistance, _groundLayerMask);
        _isGround = _checkGroundRay;
    }

    private void Animate()
    {
        _animator.SetBool("isWalk", _horizontalSpeed != 0 && _isGround ? true : false);
        _animator.SetBool("isJump", !_isGround ? true : false);
    }
}