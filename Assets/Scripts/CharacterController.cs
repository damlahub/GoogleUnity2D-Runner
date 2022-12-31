using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded;
    private bool _started;
    private bool _jumping;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        _animator=GetComponent<Animator>();
        //_started = true;
        _isGrounded=true;
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(_started && _isGrounded)
            {
                _animator.SetTrigger("jump");
                _isGrounded=false;
                _jumping=true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                _started=true;
            }
        }
        
            _animator.SetBool("grounded", _isGrounded);
        
    }
    private void FixedUpdate()
    {
        if (_started)
        {
            _rigidbody.velocity=new Vector2(speed, _rigidbody.velocity.y);
        }
        if(_jumping)
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce));
            _jumping=false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _isGrounded=true;
        }
    }
}
