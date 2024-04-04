using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherInteraction : MonoBehaviour
{
    private bool isExtinguisherInHand = false;
    private float gasLevel = 10.0f; // Initial gas level in the extinguisher
    private Camera mainCamera;


    [SerializeField] private GameObject fireExtinguisher;
    [SerializeField] private ParticleSystem fireExtinguisherParticleEffect;
    [SerializeField] private AudioSource extinguisherAudio;

    private void Start()
    {
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
                // TODO: KISHOR'S VOICE OVER "Oh no... it looks like the fire extinguisher has run out... I'll have to find another way to put out the fire!
            }
        }
    }
    public void SelectEnterExtinguisher() {
        isExtinguisherInHand = true;
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; // Keep the extinguisher level with the ground
        fireExtinguisher.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
