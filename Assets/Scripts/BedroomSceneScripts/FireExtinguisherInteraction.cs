using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherInteraction : MonoBehaviour
{
    public bool isExtinguisherInHand = false;
    private float gasLevel = 2.0f; // Initial gas level in the extinguisher
    private Camera mainCamera;

    [SerializeField] private GameObject fireExtinguisher;
    [SerializeField] private ParticleSystem fireExtinguisherParticleEffect;
    [SerializeField] private AudioSource extinguisherAudio;
    
    private bool hasSoundPlayed = false; // Flag to check if the sound has been played
    // Sound Manager
    public SoundManager soundManager;

    private void Start()
    {
        hasSoundPlayed = false;
        // Find the main camera in the scene
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (fireExtinguisherParticleEffect.isPlaying)
        {
            gasLevel -=  Time.deltaTime;
            if (gasLevel <= 0f)
            {
                StopExtinguisher();
                if (!hasSoundPlayed)
                {
                    soundManager.PlayFireExtinguisherRunOut();
                    hasSoundPlayed = true; // Set the flag so it doesn't play again
                }
            }
        }
    }
    public void SelectEnterExtinguisher() {
        isExtinguisherInHand = true;
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; // Keep the extinguisher level with the ground
        fireExtinguisher.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void SelectExitExtinguisher() {
        isExtinguisherInHand = false;
        if (fireExtinguisherParticleEffect.isPlaying) {
            StopExtinguisher();
        }
    }


    public void EjectParticles() {
        if (isExtinguisherInHand) {
            if (!fireExtinguisherParticleEffect.isPlaying) {
                fireExtinguisherParticleEffect.Play();
                extinguisherAudio.Play();
            } else {
                fireExtinguisherParticleEffect.Stop();
                extinguisherAudio.Stop();
            }
        }
    }

    void StopExtinguisher() {
        fireExtinguisherParticleEffect.Stop();
        extinguisherAudio.Stop();
    }
}
