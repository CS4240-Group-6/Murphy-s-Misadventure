using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Action Sound
    public AudioSource grabSound;
    public AudioSource teleportSound;
    public AudioSource pushDoorSound;
    public AudioSource pushWindowSound;
    public AudioSource hoverSound;

    // Player Audio
    // public AudioSource ;

    // Bedroom Scene
    public AudioSource earthquakeSound;
    public AudioSource objectFallSound;
    public AudioSource wireSparkSound;

    // Kitchen Scene
    public AudioSource fireBurningSound;

    public AudioSource fireExplosionSound;

    // Living Room Scene
    public AudioSource doorKnockSound;

    public AudioSource lightsOffSound;

    public void PlayGrabSound()
    {
        grabSound.Play();
    }
    
    public void PlayTeleportSound()
    {
        teleportSound.Play();
    }
    
    public void PlayPushDoorSound()
    {
        pushDoorSound.Play();
    }

    public void PlayPushWindowSound()
    {
        pushWindowSound.Play();
    }

    public void PlayHoverSound()
    {
        hoverSound.Play();
    }

    public void PlayEarthquakeSound()
    {
        earthquakeSound.Play();
    }

    public void PlayObjectFallSound()
    {
        objectFallSound.Play();
    }

    public void PlayWireSparkSound()
    {
        wireSparkSound.Play();
    }

    public void PlayFireBurningSound()
    {
        fireBurningSound.Play();
    }

    public void PlayFireExplosionSound()
    {
        fireExplosionSound.Play();
    }

    public void PlayDoorKnockSound()
    {
        doorKnockSound.Play();
    }

    public void PlayLightsOffSound()
    {
        lightsOffSound.Play();
    }
}
