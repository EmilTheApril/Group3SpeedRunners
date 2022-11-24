using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public void Update()
    {
        DisplayScore();
    }

    void DisplayScore()
    {
        textDisplay.text = $"Player 1: {MatchStats.instance.player1} \nPlayer 2: {MatchStats.instance.player2}";
    }
}
