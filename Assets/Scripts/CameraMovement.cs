using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;

    private int _playerInFirstPlace;
    private int _pointsReachedPlayer1 = 0;
    private int _pointsReachedPlayer2 = 0;
    [SerializeField] private GameObject[] _players;

    public void Update()
    {
        transform.position = FindCameraPosition();
    }

    public Vector3 FindCameraPosition()
    {
        Vector3 Pos = new Vector3(0, 0, -10);

        foreach (GameObject player in _players)
        {
            Pos.x += player.transform.position.x;
            Pos.y += player.transform.position.y;
        }

        return new Vector3(Pos.x/_players.Length, Pos.y/_players.Length, Pos.z);
    }

    public void FindPlayerInFirstPlace()
    {
        float Player1Dist = Vector2.Distance(_points[_pointsReachedPlayer1].transform.position, _players[0].transform.position);
        float Player2Dist = Vector2.Distance(_points[_pointsReachedPlayer2].transform.position, _players[1].transform.position);

    }
}
