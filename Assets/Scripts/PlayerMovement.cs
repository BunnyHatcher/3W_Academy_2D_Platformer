using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;

    [SerializeField] private float _jumpForce = 200f;

    [SerializeField] private byte _maxJump = 2;

    [SerializeField] private float _fallMultiplier = 3f;

    [Header("Related GameObjects")]
    [SerializeField] private GameObject _graphics; //to retrieve the graphics gameobject with our animations on it

    [Header("Floor Detection")]
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private float _detectorRadius = 1.2f;
    [SerializeField] private Vector2 _detectorPosition;
    
    
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
        //Horizontal movement
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        // character rotates by 180 degrees if he walks to the left (= less than zero velocity on the x axis)
        if (_direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        // character rotates back if he walks towards the right 
        else if (_direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }


        //triggering Jump ability when pressing Spacebar
        if(Input.GetButtonDown("Jump") && _nbJump < _maxJump)
        {
            _isJumping = true;
            _animator.SetBool("isJumping", true);
        }


        _animator.SetFloat("MoveSpeedX", Mathf.Abs( _direction.x));//use Mathf.Abs to use negative direction values for movement
        _animator.SetFloat("MoveSpeedY", _rb2d.velocity.y);

        // new method to detect if player touched floor

        Vector2 finalPosition = new Vector2 (_detectorPosition.x + transform.position.x, _detectorPosition.y + transform.position.y);
        
        Collider2D floorCollider = Physics2D.OverlapCircle(finalPosition, _detectorRadius, _floorMask);

        if(floorCollider != null)
        {
            Debug.Log(floorCollider.tag);
            Debug.Log("Touched the floor");
            _nbJump = 0;

        }
        else
        {
            Debug.Log("Didn't touch the floor");
        }

    }

    private void FixedUpdate()
    {
        //Jumping physics
        _direction.y = _rb2d.velocity.y;

        if(_isJumping)
        {
            _direction.y = _jumpForce * Time.fixedDeltaTime;
            _isJumping = false; // to prevent spamming jump action
            _nbJump++; // increments number of jumps
        }
        //implementing gravity: the player will fall faster when in the air
        if (_rb2d.velocity.y < 0)
        {
            _rb2d.gravityScale = _fallMultiplier;
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", true);
        }

        else
        {
            _rb2d.gravityScale = 1f;
            _animator.SetBool("isFalling", false);
        }
        
        // Horizontal movement
        _rb2d.velocity = _direction;

    }

    //Gizmo to visualize OverlapCircle
    private void OnDrawGizmos()
    {
        Vector2 finalPosition = new Vector2(_detectorPosition.x + transform.position.x, _detectorPosition.y + transform.position.y);
        Gizmos.DrawWireSphere(finalPosition, _detectorRadius);
    }

    /*    
    //old method to detect if player touched the floor --> if the case, set _nbJump (=number of jumps) to zero
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            _nbJump = 0;
        }
    }
    */


}
