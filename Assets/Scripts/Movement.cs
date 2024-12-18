using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //SerializeField does so you can edit an private variable in the inspector.
    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;
    [SerializeField] private float _boostTimer;
    [SerializeField] private float _boostWillLast;
    [SerializeField] private int _maxJumps;
    [SerializeField] private bool _canJump;
    [SerializeField] private bool _boosting;
    public bool _canMove = true;
    [SerializeField] private LayerMask _groundLayer;
    public string _inputNum;
    private Animator anim;
    private bool _canDetectJump;

    private int _jumps;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumps = _maxJumps;
    }

    void Start()
    {
        _boosting = false;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        Jump();

        if (_rb.velocity.y > 0.1f)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isAirborne", true);
        }
        else if (_rb.velocity.x == 0 && _rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isAirborne", false);
        }

        if (_jumps != _maxJumps && _canDetectJump && CheckIfGrounded())
        {
            _jumps = _maxJumps;
            _canJump = true;
        }
    }

    void FixedUpdate()
    {
        if (Move())
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isAirborne", false);
        } else
        {
            anim.SetBool("isRunning", false);
        }


        if(_boosting)
        {
            _boostTimer += Time.deltaTime;
            if(_boostTimer >= _boostWillLast)
            {
                _speed = 500;
                _boostTimer = 0;
                _boosting = false;
            }
        }
    }

    public bool Move()
    {
        //Gets Horizontal input (A, D, Left Arrow, Right Arrow, Joy stick X Axis)
        float Horizontal = Input.GetAxisRaw("Horizontal" + _inputNum);

        if (Horizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Horizontal > 0) GetComponent<SpriteRenderer>().flipX = false;

        //Sets velocity to horizontal axis direction * speed. Horizontal = -1 when A is pressed and 1 when D is pressed.
        if (!_canMove) { return false; }
        _rb.velocity = new Vector2(Horizontal * transform.right.x * _speed * Time.deltaTime, _rb.velocity.y);
        if (Horizontal == 0)
        {
            return false;
        }
        else return true;
    }

    //Makes player jump
    public void Jump()
    {
        //Guard clause. It checks the opposite of all criteria, and returns if one is true.
        if (!_canJump) { return; }
        if (_jumps <= 0) { return; }
        if (!Input.GetKeyDown($"joystick {_inputNum} button " + 1)) { return; }
        SoundManager.PlaySound(SoundManager.Sound.Jump);

        _canDetectJump = false;
        _jumps--;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);

        //Adds a force upwards. ForceMode2D.Impulse, takes mass into the calculations. Mass can be changed in the rigidbody.
        _rb.AddForce(transform.up * _thrust, ForceMode2D.Impulse);
        _canJump = false;

        Invoke("CanDetectJump", 0.1f);

        //Calls EnableJump after 0.2 sec
        Invoke("EnableJumpInJump", 0.2f);
    }

    public void CanDetectJump()
    {
        _canDetectJump = true;
    }

    public void DisableMove(float time)
    {
        _rb.velocity = Vector2.zero;
        _canMove = false;
        Invoke("EnableMove", time);
    }

    public void EnableMove()
    {
        _canMove = true;
    }

    public void DisableJump(float time)
    {
        _jumps = 0;
        _canJump = false;
        Invoke("EnableJump", time);
    }

    public void EnableJumpInJump()
    {
        _canJump = true;
    }

    public void EnableJump()
    {
        _jumps = _maxJumps;
        _canJump = true;
    }

    public bool CheckIfGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.55f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider != null)
        {
            anim.SetBool("isAirborne", false);
            return true;
        }

        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       
        //If player touches ground, reset jump variables
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("isAirborne", false);
            _jumps = _maxJumps;
            _canJump = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Speedboost")
        {
            _boosting = true;
            _speed = 700;
        }
    }
}
