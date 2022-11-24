using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour

{
    public GameObject ProjectilePrefab;
    public bool canUse = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D)) 
            Fire(1,-60);
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A)) 
            Fire(-1,60);
    }


    // Update is called once per frame
    public void Fire(int dir, int angle)
    {
        Vector2 spawnPos = new Vector2(transform.position.x + (dir * 1), transform.position.y);
        GameObject Bullet = Instantiate(ProjectilePrefab, spawnPos, Quaternion.identity);
        Bullet.GetComponent<Projectile>().dir = dir;
        Bullet.transform.Rotate(0,0,angle);
    }
}
