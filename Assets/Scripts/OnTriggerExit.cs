using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Movement>()._inputNum == "1")
                MatchStats.instance.AddPointPlayer2();
            else MatchStats.instance.AddPointPlayer1();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
        
}
