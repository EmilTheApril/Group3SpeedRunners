using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMisileShoot : MonoBehaviour
{
    public GameObject HomingMisilePrefab;
    public bool canUse = false;


    void Update()
    {
        int dir = 0;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            dir = -1;
        }
        else dir = 1;

        if (Input.GetKeyDown($"joystick {GetComponent<Movement>()._inputNum} button " + 2) && (canUse == true))
            Shoot(dir);
    }


    public void Shoot(int dir)
    {
        SoundManager.PlaySound(SoundManager.Sound.Blast);
        Vector2 spawnPos = new Vector2(transform.position.x + (dir * 4f), (transform.position.y + 1));
        GameObject missile = Instantiate(HomingMisilePrefab, spawnPos, Quaternion.identity);
        if (GetComponent<Movement>()._inputNum == "2")
        {
            missile.GetComponent<HomingMisile>().player = GameObject.Find("Player 1");
        } else missile.GetComponent<HomingMisile>().player = GameObject.Find("Player 2");

        canUse = false;
    }
}
