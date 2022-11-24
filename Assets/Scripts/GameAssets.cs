using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable] // to make it show up in the editor
    public class SoundAudioClip // to store both an audio clip and a sound
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
