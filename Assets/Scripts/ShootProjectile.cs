using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour

{
    public GameObject ProjectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 spawnPos = new Vector2(transform.position.x + 1, transform.position.y);
            GameObject Bullet = Instantiate(ProjectilePrefab, spawnPos, Quaternion.identity);
            Bullet.transform.Rotate(0,0,-60);
        }    }
}
