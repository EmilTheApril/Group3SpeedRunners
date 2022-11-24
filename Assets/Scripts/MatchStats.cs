using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats")]

public class MatchStats : ScriptableObject
{
    public static MatchStats instance;

    public int player1;
    public int player2;

    private int player1start = 0;
    private int player2start = 0;

    private void OnEnable()
    {
        instance = this;
        player1 = player1start;
        player2 = player2start;
    }

    public void AddPointPlayer1()
    {
        player1++;
    }

    public void AddPointPlayer2()
    {
        player2++;
    }
}
