using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager // a class that is responsible for playing all of the sounds
{
    public enum Sound //to keep track of all needed sounds
    {
        Countdown,
        Explosion,
        Grapple,
        Jump,
        Blast,
        GameOver,
    }
    public static void PlaySound(Sound sound) //function to play a single sound 
    {
        GameObject soundGameObject = new GameObject("Sound"); // creating a gameobject
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();// adding a component for audio source (that plays the audio)
        audioSource.PlayOneShot(GetAudioClip(sound)); // calling the function, which plays the audio clip
    }

    private static AudioClip GetAudioClip(Sound sound) //finding a correct audio clip that matches the sound
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        }

        Debug.LogError("Sound" + sound + "not found!");
        return null;
    }

    //public static void AddButtonSounds(this Button_UI )
}
