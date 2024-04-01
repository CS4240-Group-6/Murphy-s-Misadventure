using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingSodaInteraction : MonoBehaviour
{
    public ParticleSystem sodaParticles; // Reference to the fire particle system
    [SerializeField] private ParticleSystem yellowFireSteamParticles;
    [SerializeField] private ParticleSystem blueFireSteamParticles;
    [SerializeField] private ParticleSystem greenFireSteamParticles;
    [SerializeField] private ParticleSystem yellowFireParticles;
    [SerializeField] private ParticleSystem blueFireParticles;
    [SerializeField] private ParticleSystem greenFireParticles;
    [SerializeField] private AudioSource extinguishFlameAudio;
    public float durationThreshold = 5f; // Duration threshold for triggering the effect

    private float timer = 0f;
    private bool isBakingSodaOnFire = false;
    private bool wasBakingSodaOnFire = false;
    private string colourOfFire = "";


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle collision enter");
        if (other.CompareTag("Yellow_Fire")) // Assuming you've tagged the baking soda particles appropriately
        {
            isBakingSodaOnFire = true;
            colourOfFire = "yellow";
        } 
        if (other.CompareTag("Blue_Fire")) // Assuming you've tagged the baking soda particles appropriately
        {
            isBakingSodaOnFire = true;
            colourOfFire = "blue";
        } 
        if (other.CompareTag("Green_Fire")) // Assuming you've tagged the baking soda particles appropriately
        {
            isBakingSodaOnFire = true;
            colourOfFire = "green";
        } 
        if (other.CompareTag("Floor")) // Assuming you've tagged the baking soda particles appropriately
        {
            Debug.Log("Collide with floor");
            isBakingSodaOnFire = false;
        } 
    }

    private void Update()
    {
        if (isBakingSodaOnFire)
        {
            extinguishFlameAudio.loop = true;
            if (!extinguishFlameAudio.isPlaying) {
                extinguishFlameAudio.Play();
            }
            timer += Time.deltaTime;
            if (timer >= durationThreshold)
            {
                StopFireParticles(colourOfFire);
            }
        }
        else if (wasBakingSodaOnFire)
        {
            if (extinguishFlameAudio.isPlaying) {
                extinguishFlameAudio.Stop();
            }
            // Baking soda particles have exited, reset timer
            timer = 0f;
            wasBakingSodaOnFire = false;
        }
        else {
            if (extinguishFlameAudio.isPlaying) {
                extinguishFlameAudio.Stop();
            }
            // Baking soda particles have exited, reset timer
            timer = 0f;
            wasBakingSodaOnFire = false;
        }

        wasBakingSodaOnFire = isBakingSodaOnFire;
        isBakingSodaOnFire = false;
    }

    // private void LateUpdate()
    // {
    //     Debug.Log("in late update");
    //     wasBakingSodaOnFire = isBakingSodaOnFire;
    //     isBakingSodaOnFire = false;
    // }

    private void StopFireParticles(string colourOfFire)
    {
        GameObject parentOfYellowFire = yellowFireParticles.transform.parent.gameObject;
        GameObject parentOfBlueFire = blueFireParticles.transform.parent.gameObject;
        GameObject parentOfGreenFire = greenFireParticles.transform.parent.gameObject;

        isBakingSodaOnFire = false;
        switch (colourOfFire) {
            case "yellow":
                yellowFireParticles.Stop();
                parentOfYellowFire.SetActive(false);
                yellowFireSteamParticles.Play();
                BedroomSceneState.SetExtinguishYellowFlames(true);
                break;
            case "blue":
                blueFireParticles.Stop();
                parentOfBlueFire.SetActive(false);
                blueFireSteamParticles.Play();
                BedroomSceneState.SetExtinguishBlueFlames(true);
                break;
            case "green":
                greenFireParticles.Stop();
                parentOfGreenFire.SetActive(false);
                greenFireSteamParticles.Play();
                BedroomSceneState.SetExtinguishGreenFlames(true);
                break;
        }
    }
}
