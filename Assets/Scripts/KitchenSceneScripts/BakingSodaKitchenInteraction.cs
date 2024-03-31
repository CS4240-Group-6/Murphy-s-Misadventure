using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingSodaKitchenInteraction : MonoBehaviour
{
    [SerializeField] private GameObject bakingSoda;
    [SerializeField] private ParticleSystem bakingSodaParticles;
    //[SerializeField] private ParticleSystem yellowFireSteamParticles;
    //[SerializeField] private ParticleSystem blueFireSteamParticles;

    [SerializeField] private ParticleSystem oilFireParticles;
    [SerializeField] private ParticleSystem oilFireSpreadParticles;
    [SerializeField] private AudioSource putOutFireAudio;
    public float durationThreshold; // Duration threshold for triggering the effect

    private bool bakingSodaParticlesActive;

    private float timer = 0f;
    private bool isBakingSodaOnFire = false;
    private bool wasBakingSodaOnFire = false;
    private string fireType = "";


    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Oil_Fire")) // Assuming you've tagged the baking soda particles appropriately
        {
            GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
            if (parentOfOilFire.activeInHierarchy) {
                isBakingSodaOnFire = true;
                fireType = "Oil_Fire";
            }
        } 
        if (other.CompareTag("Oil_Fire_Spread")) // Assuming you've tagged the baking soda particles appropriately
        {
            isBakingSodaOnFire = true;
            fireType = "Oil_Fire_Spread";
        } 
        if (other.CompareTag("Floor")) // Assuming you've tagged the baking soda particles appropriately
        {
            Debug.Log("Collide with floor");
            isBakingSodaOnFire = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the baking soda is tilted more than 90 degrees
        if (Vector3.Angle(bakingSoda.transform.up, Vector3.up) > 90f)
        {
            if (!bakingSodaParticlesActive)
            {
                // Start emitting particles
                bakingSodaParticles.Play();
                bakingSodaParticlesActive = true;
            }
        }
        else
        {
            if (bakingSodaParticlesActive)
            {
                // Stop emitting particles
                bakingSodaParticles.Stop();
                bakingSodaParticlesActive = false;
            }
        }

        if (isBakingSodaOnFire)
        {
            Debug.Log(timer);
            putOutFireAudio.loop = true;
            if (!putOutFireAudio.isPlaying) {
                putOutFireAudio.Play();
            }
            timer += Time.deltaTime;
            if (timer >= durationThreshold)
            {
                StopFireParticles(fireType);
            }
        }
        else if (wasBakingSodaOnFire)
        {
            if (putOutFireAudio.isPlaying) {
                putOutFireAudio.Stop();
            }
            // Baking soda particles have exited, reset timer
            timer = 0f;
            wasBakingSodaOnFire = false;
        }
        else {
            if (putOutFireAudio.isPlaying) {
                putOutFireAudio.Stop();
            }
            // Baking soda particles have exited, reset timer
            timer = 0f;
            wasBakingSodaOnFire = false;
        }

        wasBakingSodaOnFire = isBakingSodaOnFire;
        isBakingSodaOnFire = false;
    }

    private void StopFireParticles(string fireType)
    {
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        GameObject parentOfOilFireSpread = oilFireSpreadParticles.transform.parent.gameObject;

        isBakingSodaOnFire = false;
        switch (fireType) {
            case "Oil_Fire":
                oilFireParticles.Stop();
                parentOfOilFire.SetActive(false);
                //yellowFireSteamParticles.Play();
                break;
            case "Oil_Fire_Spread":
                oilFireSpreadParticles.Stop();
                parentOfOilFireSpread.SetActive(false);
                //blueFireSteamParticles.Play();

                break;

        }
    }
}
