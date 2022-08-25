using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;

    [SerializeField] private float _jumpForce = 200f;

    [SerializeField] private int _maxJump = 2;

    [SerializeField] private float _fallMultiplier = 3f;

    [Header("Related GameObjects")]
    [SerializeField] private GameObject _graphics; //to retrieve the graphics gameobject with our animations on it
    
    
    private Rigidbody2D _rb2d;
    private Vector2 _direction;
    private bool _isJumping = false;
    private int _nbJump = 0;

    private Animator _animator;


    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = _graphics.GetComponent<Animator>();

        
    }


    void Start()
    {
        
    }

    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        //triggering Jump ability when pressing Spacebar
        if(Input.GetButtonDown("Jump") && _nbJump < _maxJump)
        {
            _isJumping = true;
        }

        _animator.SetFloat("MoveSpeedX", Mathf.Abs( _direction.x));
    }

    private void FixedUpdate()
    {
        _direction.y = _rb2d.velocity.y;

        if(_isJumping)
        {
            _direction.y = _jumpForce * Time.fixedDeltaTime;
            _isJumping = false; // to prevent spamming jump action
            _nbJump++; // to keep count of number of jumps
        }
        //implementing gravity: the player will fall faster when in the air
        if (_rb2d.velocity.y < 0)
        {
            _rb2d.gravityScale = _fallMultiplier;
        }

        else
        {
            _rb2d.gravityScale = 1f;
        }
        
        _rb2d.velocity = _direction;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            _nbJump = 0;
        }
    }
}
