using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public KeyCode usePowerup = KeyCode.Space;
    public LaserBeamShoot laserScript;
    public BananaPeelSpawner bananaScript;
    public ShootProjectile grenadeScript;
    public string uiName;
    public int _randomNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerupBox"))
        {
            if (other.transform.root.GetComponent<Movement>()._inputNum == "1")
            {
                uiName = " Red";
            }
            else uiName = " Blue";

            //ChangeImg();
        }
    }
    public void GiveUpgrade()
    {
        laserScript.canUse = false;
        bananaScript.canUse = false;
        grenadeScript.canUse = false;

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

            break;
        default:
            Debug.Log("Error");
            break;
        }
         
    }

        public void ChangeImg()
        {
            int rand = Random.Range(0, 3);
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().imgNumberCount = rand;
            GameObject.Find("Upgrade icon" + uiName).GetComponent<ImageUIPowerup>().ChangeImage();
            _randomNumber = rand;
        }
    
}

