using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats")]

public class MatchStats : ScriptableObject
{
    public int player1;
    public int player2;

    public void AddPointPlayer1()
    {
        player1++;
    }

    public void AddPointPlayer2()
    {
        player2++;
    }
}
