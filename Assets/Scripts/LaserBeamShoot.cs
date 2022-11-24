using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamShoot : MonoBehaviour
{
    public GameObject LaserBeamPrefab;
    public bool canUse = false;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && (canUse == true)) 
            Shoot(1);
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && (canUse == true)) 
            Shoot(-1);
    }

    
    public void Shoot(int dir)
    {
        
            Vector2 spawnPos = new Vector2(transform.position.x + (dir * 4f), (transform.position.y+1));
            GameObject Laser = Instantiate(LaserBeamPrefab, spawnPos, Quaternion.identity);
            Laser.GetComponent<LaserBeam>().dir = dir;
            canUse = false;
    }




}

