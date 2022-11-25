using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HomingMisile : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed = 1.5f;

    public GameObject[] waypoints;

    public GameObject freezeEffect;
    public float force;
    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveMissile();
    }

    public void MoveMissile()
    {
        // Will make the misile chase player1.
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position + new Vector3(0, 1f, 0), speed * Time.deltaTime);
        
        // Will make the misile change its rotation to always face the target. 
        transform.up = player.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
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
    


}
