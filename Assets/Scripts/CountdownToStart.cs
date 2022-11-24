using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownToStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        countdownText.text = "3";
        SoundManager.PlaySound(SoundManager.Sound.Countdown);
        FindObjectsOfType<Movement>()[0].DisableMove(3);
        FindObjectsOfType<Movement>()[1].DisableMove(3);
        FindObjectsOfType<Movement>()[0].DisableJump(3);
        FindObjectsOfType<Movement>()[1].DisableJump(3);
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GOOOO";
        yield return new WaitForSeconds(1f);
        countdownText.text = "";

    }
}
