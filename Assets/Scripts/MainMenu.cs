using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Making it possible to use Unity's own scene management.

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown($"joystick {1} button " + 1))
        {
            SceneManager.LoadScene("Level Emil");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level Emil");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
