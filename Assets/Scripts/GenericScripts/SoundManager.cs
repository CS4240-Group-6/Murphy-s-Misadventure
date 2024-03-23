using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Action Sound
    public AudioSource grabSound;
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

    public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    private AudioSource audioSource; // Reference to the Audio Source component

    // Audio source component for sound effects
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    public void PlayGrabSound()
    {
        grabSound.Play();
    }
    
    public void PlayWalkSound()
    {
        // Play a random footstep sound from the array when player teleports
        AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(footstepSound);
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
