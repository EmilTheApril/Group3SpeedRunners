using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This script is used to handle what happens when a power up box is picked up
 * The box will disapear for a few seconds, and a random powerup will be given
 * to the player who picked it up
 * Jeppe */
public class PowerUpBox : MonoBehaviour
{
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Removes gameObject temporarily
        gameObject.SetActive(false);
        // Respawner
        Invoke("Respawn", 3f);

        // If a player enters the collider pickup the object
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup ()
    {
        Debug.Log("Powerup picked up");

        // Spawn cool effect
        GameObject expl = Instantiate(pickupEffect, transform.position, transform.rotation);
        // Destroy object after 2f
        Destroy(expl, 2f);

        // Apply random upgrade to player
        // INSERT UPGRADES HERE

    }
    // Respawn object
    public void Respawn()
    {
        gameObject.SetActive(true);
    }
}
