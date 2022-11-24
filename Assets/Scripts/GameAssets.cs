using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    public SoundAudioClip[] soundAudioClipArray;

    public void Awake()
    {
        if (i == null)
        {
            i = this;
        }
    }

    [System.Serializable] // to make it show in the editor
    public class SoundAudioClip // to store both an audio clip and a sound
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
