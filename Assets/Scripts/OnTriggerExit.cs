using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExit : MonoBehaviour
{

    public MatchStats stats;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.GetComponent<Movement>()) ;
        }
    }

    
}
