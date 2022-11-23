using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;
    [SerializeField] private int _maxJumps;
    private int _jumps;
    private bool _canJump;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumps = _maxJumps;
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(Horizontal * transform.right.x * _speed * Time.deltaTime, _rb.velocity.y);
    }

    public void Jump()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        if (_jumps <= 0 || Vertical <= 0) { return; }

        _jumps--;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(transform.up * _thrust, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _jumps = _maxJumps;
        }
    }
}
