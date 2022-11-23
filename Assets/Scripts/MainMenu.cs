using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Making it possible to use Unity's own scene management.

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
