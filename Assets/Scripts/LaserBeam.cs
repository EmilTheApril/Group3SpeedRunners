using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public GameObject freezeEffect;
    public float force;
    public Rigidbody2D rb;
    public int dir = 0;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.AddForce(dir * Vector2.right * force);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject freeze = Instantiate(freezeEffect, transform.position, transform.rotation);
        Destroy(freeze, 2f);
        Destroy(gameObject);
    } 
}


