using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;

    private int _playerInFirstPlace;
    private int _pointsReachedPlayer1 = 0;
    private int _pointsReachedPlayer2 = 0;
    [SerializeField] private float _maxZoom;
    [SerializeField] private GameObject[] _players;

    public void Update()
    {
        transform.position = FindCameraPosition();
        ZoomCamera();
    }

    public Vector3 FindCameraPosition()
    {
        Vector3 Pos = new Vector3(0, 0, -10);

        foreach (GameObject player in _players)
        {
            Pos.x += player.transform.position.x;
            Pos.y += player.transform.position.y;
        }
        int firstPlacePlayer = FindPlayerInFirstPlace();
        Pos.x += _players[firstPlacePlayer].transform.position.x;
        Pos.y += _players[firstPlacePlayer].transform.position.y;

        return new Vector3(Pos.x/(_players.Length + 1), Pos.y/(_players.Length + 1), Pos.z);
    }

    public void ZoomCamera()
    {
        float DistBetweenPlayers = Vector2.Distance(_players[0].transform.position, _players[1].transform.position);
        float zoom = 0;
        if ((0.125f * DistBetweenPlayers) + 10 <= _maxZoom)
        {
            zoom = (0.2f * DistBetweenPlayers) + 10;
            Camera.main.GetComponent<Camera>().orthographicSize = zoom;
        }
    }

    public int FindPlayerInFirstPlace()
    {
        float Player1Dist = Vector2.Distance(_points[_pointsReachedPlayer1].transform.position, _players[0].transform.position);
        float Player2Dist = Vector2.Distance(_points[_pointsReachedPlayer2].transform.position, _players[1].transform.position);

        if (Player1Dist <= 3f)
        {
            if (_pointsReachedPlayer1 < (_points.Length - 1))
            {
                _pointsReachedPlayer1++;
            }
            else _pointsReachedPlayer1 = 0;
        }

        if (Player2Dist <= 3f)
        {
            if (_pointsReachedPlayer2 < (_points.Length - 1))
            {
                _pointsReachedPlayer2++;
            }
            else _pointsReachedPlayer2 = 0;
        }

        //Both at same checkpoint
        if (_pointsReachedPlayer1 == _pointsReachedPlayer2)
        {
            //Player 1 in first
            if (Player1Dist < Player2Dist)
            {
                return 0;
            }
            //Player 2 in first
            else
            {
                return 1;
            }
        }

        //Player 1 is first
        else if(_pointsReachedPlayer1 > _pointsReachedPlayer2)
        {
            return 0;
        }
        //Player 2 is first
        else if (_pointsReachedPlayer1 < _pointsReachedPlayer2)
        {
            return 1;
        }

        return 0;
    }
}
