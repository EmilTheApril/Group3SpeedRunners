using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public LaserBeamShoot laserScript;
    public BananaPeelSpawner bananaScript;
    public ShootProjectile grenadeScript;
    public HomingMisileShoot homingMisileShoot;
    public string uiName;
    public int _randomNumber;
    public Movement movement;
    private bool hasChanged = false;

    private void Update()
    {
        if (Input.GetKeyDown($"joystick {GetComponent<Movement>()._inputNum} button " + 2))
        {
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().imgNumberCount = 3;
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().ChangeImage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerupBox"))
        {

            ChangeImg();
            GiveUpgrade();
        }
    }

    public void GiveUpgrade()
    {
        laserScript.canUse = false;
        bananaScript.canUse = false;
        grenadeScript.canUse = false;
        homingMisileShoot.canUse = false;

        switch(_randomNumber)
        {
        case 0:
                bananaScript.canUse = true;
            break;
        case 1:
                grenadeScript.canUse = true;
            break;
        case 2:
                laserScript.canUse = true;
            break;
        case 3:
            homingMisileShoot.canUse = true;
            break;
        default:
            Debug.Log("Error");
            break;
        }
        
    }

    public void ChangeImg()
    {
        if (!hasChanged)
        {
            int rand = Random.Range(0, 4);
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().imgNumberCount = rand;
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().ChangeImage();
            _randomNumber = rand;
            hasChanged = true;
            Invoke("EnableChange", 0.2f);
        }
    }

    public void EnableChange()
    {
        hasChanged = false;
    }
}

