using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    public void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public Vector3 FindCameraPosition()
    {
        Vector3 pos = new Vector3(0, 0, -10);

        foreach (GameObject player in players)
        {
            pos.x += player.transform.position.x;
            pos.y += player.transform.position.y;
        }

        return new Vector3(pos.x/players.Length, pos.y/players.Length, pos.z);
    }
}
