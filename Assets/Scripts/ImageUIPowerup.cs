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
    public Sprite missile;
    public Sprite questionMark;
 
    public int imgNumberCount;
   
    public void ChangeImage()
    {
        switch (imgNumberCount)
        {

            case 0:
                SoundManager.PlaySound(SoundManager.Sound.Appeal);
                GetComponent<Image>().sprite = banana;
                break;
            case 1:
                SoundManager.PlaySound(SoundManager.Sound.Grenade);
                GetComponent<Image>().sprite = grenade;
                break;
            case 2:
                SoundManager.PlaySound(SoundManager.Sound.Laser);
                GetComponent<Image>().sprite = laser;
                break;
            case 3:
                SoundManager.PlaySound(SoundManager.Sound.Missile);
                GetComponent<Image>().sprite = missile;
                break;
            case 4:
                GetComponent<Image>().sprite = questionMark;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
