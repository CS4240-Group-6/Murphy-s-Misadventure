using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Action Sound
    public AudioSource grabSound;
    public AudioSource pushDoorSound;
    public AudioSource pushWindowSound;


    // Game Intro Song
    public AudioSource introSong;

    // Game Ending Song
    public AudioSource endingSong;

    public void PlayIntroSong()
    {
        introSong.Play();
    }
    
    public void PlayEndingSong()
    {
        endingSong.Play();
    }

    public void PlayGrabSound()
    {
        grabSound.Play();
    }
    
    public void PushDoorSound()
    {
        pushDoorSound.Play();
    }

    public void PushWindowSound()
    {
        pushWindowSound.Play();
    }
}
