using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    private AudioSource audioSource;

    // Action Sound
    public AudioSource grabSound;
    public AudioSource hoverSound;
    public AudioClip[] footstepSounds;

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
    public AudioSource doorUnlockSound;

    public AudioSource lockPickSound;

    // Voice Audios

    // Bedroom Scene

    // Level 1
    public AudioClip smellBurning;
    public AudioClip fireOnTheAdaptor;
    public AudioClip fireExtinguisherRunOut;

    // Level 2
    public AudioClip roomShaking;
    public AudioClip findASafeSpot;
    
    // Kitchen Scene

    // Level 1
    public AudioClip smellSomethingBurning;
    public AudioClip shouldTurnOffSomethingAndCoverPan;
    public AudioClip fireGotBiggerNeedToPour;

    // Level 2
    public AudioClip isThatSmoke;
    public AudioClip needToExtinguishFireSoon;

    // Living Room Scene
    
    // Level 1
    public AudioClip anotherLongDay;
    public AudioClip whatsThatSound;
    public AudioClip lightsWentOut;
    
    // Level 2
    public AudioClip iDidntOrderDelivery;
    public AudioClip leaveOrICallPolice;
    public AudioClip intruderDialogue;

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

    public void PlayDoorUnlockSound()
    {
        doorUnlockSound.Play();
    }

    public void PlayLockPickingSound()
    {
        lockPickSound.Play();
    }

    public void PlaySmellBurning()
    {
        subtitleText.text = "Murphy: I’m smelling something burning";
        audioSource.PlayOneShot(smellBurning);
    }

    public void PlayFireOnAdaptor()
    {
        subtitleText.text = "Murphy: Oh no there’s fire on the adaptor! I need to find a way to cut the electricity and extinguish the flame";
        audioSource.PlayOneShot(fireOnTheAdaptor);
    }

    public void PlayRoomShaking()
    {
        subtitleText.text = "Murphy: Is the room shaking?";
        audioSource.PlayOneShot(roomShaking);
    }

    public void PlayFindASafeSpot()
    {
        subtitleText.text = "Murphy: Oh god! This is bad. I need to find a safe spot where I wont get hit";
        audioSource.PlayOneShot(findASafeSpot);
    }

    public void PlaySmellSomethingBurning()
    {
        subtitleText.text = "Murphy: I’m smelling something burning";
        audioSource.PlayOneShot(smellSomethingBurning);
    }

    public void PlayShouldTurnOffSomethingAndCoverPan()
    {
        subtitleText.text = "Murphy: Hmm maybe I should turn something off and need to find a way to cover the pan";
        audioSource.PlayOneShot(shouldTurnOffSomethingAndCoverPan);
    }

    public void PlayFireGotBiggerNeedToPour()
    {
        subtitleText.text = "Murphy: Oh no! The fire has gotten bigger now I should turn off something and pour something on top it";
        audioSource.PlayOneShot(fireGotBiggerNeedToPour);
    }

    public void PlayIsThatSmoke()
    {
        subtitleText.text = "Murphy: Is that smoke? I have to find where its coming from and turn it off quick";
        audioSource.PlayOneShot(isThatSmoke);
    }

    public void PlayNeedToExtinguishFireSoon()
    {
        subtitleText.text = "Murphy: Wow! Ok i need to extinguish the fire soon before it explodes"; 
        audioSource.PlayOneShot(needToExtinguishFireSoon);
    }

    public void PlayAnotherLongDay()
    {
        subtitleText.text = "Murphy: Another long day… I’m finally home"; 
        audioSource.PlayOneShot(anotherLongDay);      
    }

    public void PlayWhatsThatSound()
    {
        subtitleText.text = "Murphy: What’s that sound?"; 
        audioSource.PlayOneShot(whatsThatSound);          
    }

    public void PlayLightWentOut()
    {
        subtitleText.text = "Murphy: Ah! The lights went out! I should find a way to turn the lights back on…"; 
        audioSource.PlayOneShot(lightsWentOut);          
    }

    public void PlayIDidntOrderDelivery()
    {
        subtitleText.text = "Murphy: Who’s that.. I didn’t order any delivery…"; 
        audioSource.PlayOneShot(iDidntOrderDelivery);          
    }

    public void PlayLeaveOrICallPolice()
    {
        subtitleText.text = "Murphy: Sorry, I didn’t order anything. Please leave or I’ll call the police"; 
        audioSource.PlayOneShot(leaveOrICallPolice);          
    }
    
    public void PlayIntruderDialogue()
    {
        subtitleText.text = "Intruder: “Hello? Delivery service. Anyone home?";
        audioSource.PlayOneShot(intruderDialogue);
    }

    public void PlayFireExtinguisherRunOut()
    {        
        subtitleText.text = "Murphy: Oh no... It looks like the fire extinguisher has run out. I'll have to find another way to put out the fire";
        audioSource.PlayOneShot(fireExtinguisherRunOut);
    }
}



/**
Kitchen
subtitleText.text = “I’m smelling something burning”
subtitleText.text = “Hmm maybe I should turn something off and need to find a way to cover the pan”
subtitleText.text = “Oh no! The fire has gotten bigger now I should turn off something and pour something on top it”

subtitleText.text = “Is that smoke? I have to find where its coming from and turn it off quick”
subtitleText.text = “Wow! Ok i need to extinguish the fire soon before it explodes”

Bedroom
subtitleText.text = “I’m smelling something burning”
subtitleText.text = “Oh no there’s fire on the adaptor! I need to find a way to cut the electricity and extinguish the flame”

subtitleText.text = “Is the room shaking?”
subtitleText.text = “Oh god! This is bad. I need to find a safe spot where I wont get hit?”

Living Room
subtitleText.text = “Another long day… I’m finally home”
subtitleText.text = “What’s that sound?”
subtitleText.text = “Ah! The lights went out! I should find a way to turn the lights back on…”

subtitleText.text = “Who’s that.. I didn’t order any delivery…”
subtitleText.text = “Sorry, I didn’t order anything. Please leave or I’ll call the police”
**/