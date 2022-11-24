using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is for the "BananaPeel" prefab.
//It will register a collision with any gameObject with the tag "Player", spawn an animation and then destroy the prefab.
//
public class BananaPeel : MonoBehaviour
{        
    public GameObject _smokeEffect;
    [SerializeField] private string _playerTag = "Player";

    
    //Method to detect collision. On collision, this object is destroyed and smoke animation plays.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the object colliding with this one, has the tag "Player"
        if(collision.collider.tag == _playerTag)
        {
            //Instantiates the _smokeEffect gameobject at the position of the prefab
            Instantiate(_smokeEffect, transform.position, transform.rotation);
            //Destroys the object this script is attached to
            Destroy(this.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
