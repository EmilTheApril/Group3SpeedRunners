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
    bool canTrigger = false;

    public void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("CanTrigger", 0.25f);
    }

    public void CanTrigger()
    {
        canTrigger = true;
    }

    //Method to detect collision. On collision, this object is destroyed and smoke animation plays.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the object colliding with this one, has the tag "Player"
        if (canTrigger)
        {
            if (collision.tag == _playerTag)
            {
                //Instantiates the _smokeEffect gameobject at the position of the prefab
                GameObject _smoke = Instantiate(_smokeEffect, transform.position, transform.rotation);
                //Destroys the object this script is attached to
                if (collision.transform.GetComponent<Movement>() != null)
                {
                    collision.GetComponent<Movement>().DisableMove(1);
                    collision.GetComponent<Movement>().DisableJump(1);
                }
                Destroy(this.gameObject);
                Destroy(_smoke, 2f);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
