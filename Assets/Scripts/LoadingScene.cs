using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private int index;

    void Start()
    {
        Invoke("NextScene", 10f);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(index);
    }
}
