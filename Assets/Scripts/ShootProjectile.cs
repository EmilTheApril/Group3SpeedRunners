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
        int dir = 0;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            dir = -1;
        }
        else dir = 1;

        if (Input.GetKeyDown(KeyCode.Space) && dir == 1 && (canUse == true))
            Fire(dir, -60);
        if (Input.GetKeyDown(KeyCode.Space) && dir == -1 && (canUse == true))
            Fire(dir, 60);
    }


    // Update is called once per frame
    public void Fire(int dir, int angle)
    {
        Vector2 spawnPos = new Vector2(transform.position.x + (dir * 1), transform.position.y+1);
        GameObject Bullet = Instantiate(ProjectilePrefab, spawnPos, Quaternion.identity);
        Bullet.GetComponent<Projectile>().dir = dir;
        Bullet.transform.Rotate(0,0,angle);
        canUse = false;
    }
}
