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
        SoundManager.PlaySound(SoundManager.Sound.Electricity);
        GameObject freeze = Instantiate(freezeEffect, transform.position, transform.rotation);
        if (col.transform.GetComponent<Movement>() != null)
        {
            col.transform.GetComponent<Movement>().DisableMove(1);
            col.transform.GetComponent<Movement>().DisableJump(1);
        }
        Destroy(freeze, 1f);
        
        Destroy(gameObject);
    } 
}


