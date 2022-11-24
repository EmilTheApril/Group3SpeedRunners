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
    public Sprite questionMark;
    public PowerUpBox boxScript;
    public int imgNumberCount;

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
            case 3:
                GetComponent<Image>().sprite = grenade;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
