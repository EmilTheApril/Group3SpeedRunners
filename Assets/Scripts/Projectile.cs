using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
