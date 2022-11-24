using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamShoot : MonoBehaviour
{
    public GameObject LaserBeamPrefab;
    

    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.D)) 
            Shoot(1);
        if (Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.A)) 
            Shoot(-1);

    }

    
    public void Shoot(int dir)
    {
            
            Vector2 spawnPos = new Vector2(transform.position.x + (dir * 2.5f), transform.position.y);
            GameObject Laser = Instantiate(LaserBeamPrefab, spawnPos, Quaternion.identity);
            Laser.GetComponent<LaserBeam>().dir = dir;
    }




}

