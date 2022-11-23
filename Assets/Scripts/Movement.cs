using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //SerializeField does so you can edit an private variable in the inspector.
    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;
    [SerializeField] private int _maxJumps;
    [SerializeField] private string _inputNum;
    [SerializeField] private bool _canJump;

    private int _jumps;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumps = _maxJumps;
    }

    public void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        //Gets Horizontal input (A, D, Left Arrow, Right Arrow, Joy stick X Axis)
        float Horizontal = Input.GetAxisRaw("Horizontal" + _inputNum);

        //Sets velocity to horizontal axis direction * speed. Horizontal = -1 when A is pressed and 1 when D is pressed.
        _rb.velocity = new Vector2(Horizontal * transform.right.x * _speed * Time.deltaTime, _rb.velocity.y);
    }

    //Makes player jump
    public void Jump()
    {
        //Guard clause. It checks the opposite of all criteria, and returns if one is true.
        if (_jumps <= 0 || Input.GetAxisRaw("Vertical" + _inputNum) <= 0 || !_canJump) { return; }

        _jumps--;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);

        //Adds a force upwards. ForceMode2D.Impulse, takes mass into the calculations. Mass can be changed in the rigidbody.
        _rb.AddForce(transform.up * _thrust, ForceMode2D.Impulse);
        _canJump = false;

        //Calls EnableJump after 0.2 sec
        Invoke("EnableJump", 0.2f);
    }

    public void EnableJump()
    {
        _canJump = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //If player touches ground, reset jump variables
        if (other.CompareTag("Ground"))
        {
            _jumps = _maxJumps;
            _canJump = true;
        }
    }
}
