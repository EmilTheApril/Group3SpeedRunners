using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUIPowerup : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite banana;
    public Sprite grenade;
    public Sprite laser;

    public PowerUpBox boxScript;
    public int imgNumberCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()
    {
        switch (imgNumberCount)
        {

            case 0:
                GetComponent<Image>().sprite = banana;
                break;
            case 1:
                GetComponent<Image>().sprite = grenade;
                break;
            case 2:
                GetComponent<Image>().sprite = laser;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
