using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherInteractionForTutorial : MonoBehaviour
{
    public bool isExtinguisherInHand = false;
    private Camera mainCamera;

    [SerializeField] private GameObject fireExtinguisher;
    [SerializeField] private ParticleSystem fireExtinguisherParticleEffect;
    [SerializeField] private AudioSource extinguisherAudio;
    public SoundManager soundManager;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

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
