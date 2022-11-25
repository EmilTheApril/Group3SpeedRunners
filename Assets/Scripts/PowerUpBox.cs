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
    private int _randomNumber;
    public ImageUIPowerup imgScript;
    public string uiName;
    public GameObject BoxExpAni;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Removes gameObject temporarily
            gameObject.SetActive(false);
            GameObject BoxExpAni = Instantiate(this.BoxExpAni, transform.position, transform.rotation);
            Destroy(BoxExpAni, BoxExpAni.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
            // Respawner
            Invoke("Respawn", 3f);

            // If a player enters the collider pickup the object
            Pickup();
        }
    }

    void Pickup ()
    {
        Debug.Log("Powerup picked up");

    }
    // Respawn object
    public void Respawn()
    {
        gameObject.SetActive(true);
    }
   
}
