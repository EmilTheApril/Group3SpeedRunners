using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode useUpgrade = KeyCode.Space;
    public float radius;
    public float explosionForce;
    public GameObject pickupEffect;
    public Rigidbody2D rb;
    public int dir = 0;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Boomba();
        Destroy(gameObject);
       
    }

    public void Boomba()
    {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    if (hit.GetComponent<Movement>() != null)
                    {
                        hit.GetComponent<Movement>().DisableMove(1);
                        hit.GetComponent<Movement>().DisableJump(1);
                    }
                    Vector2 dir = (hit.transform.position - transform.position);
                    dir.Normalize();
                    rb.AddForce(dir * explosionForce, ForceMode2D.Force);
                    // Spawn cool effect
                    GameObject expl = Instantiate(pickupEffect, transform.position, transform.rotation);
                    // Destroy object after 2f
                    Destroy(expl, 2f);
                }

                

            }
    }

}
