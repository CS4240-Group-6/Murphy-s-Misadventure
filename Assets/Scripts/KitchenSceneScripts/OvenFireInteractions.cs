using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenFireInteractions : MonoBehaviour
{
    [SerializeField] private AudioSource putOutFireAudio;
    [SerializeField] private ParticleSystem ovenSmokeParticles;
    [SerializeField] private ParticleSystem ovenFireParticles;
    [SerializeField] private ParticleSystem ovenExplosionParticles;

    [SerializeField] private ParticleSystem ovenSmallExplosionParticles;
    [SerializeField] private ParticleSystem ovenFireBigParticles;
 
    public float extinguisherDurationThreshold; // Duration threshold for extinguisher
    public float waterThreshold; // Duration threshold for water over fire

    private float timer = 0f;
    private float waterTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire_Extinguisher"))
        {
            StartCoroutine(ExtinguisherOverFire());
        }
        else if (other.CompareTag("Water"))
        {
            StartCoroutine(WaterOverFire());
        }
    }

    private IEnumerator ExtinguisherOverFire()
    {
        GameObject parentOfOvenFire = ovenFireParticles.transform.parent.gameObject;
        if (parentOfOvenFire.activeInHierarchy)
        {
            Debug.Log(timer);
            putOutFireAudio.loop = true;
            if (!putOutFireAudio.isPlaying)
            {
                putOutFireAudio.Play();
            }

            timer += Time.deltaTime;
            if (timer >= extinguisherDurationThreshold)
            {
                //Debug.Log("enter stop fire particles");
                StopFireParticles();
                KitchenSceneState.SetFireExtinguisherUsed(true);
            }
        }
        yield return null;
    }

    private IEnumerator WaterOverFire()
    {
        GameObject parentOfOvenSmoke = ovenSmokeParticles.transform.parent.gameObject;
        if (parentOfOvenSmoke.activeInHierarchy)
        {
            waterTimer += Time.deltaTime;
            if (waterTimer > waterThreshold)
            {
                StartFireBigParticles();
                KitchenSceneState.SetWaterAddedToOven(true);
            }
        }
        yield return null;
    }

    void StartFireBigParticles()
    {
        GameObject parentOfOvenFireBigParticles = ovenFireBigParticles.transform.parent.gameObject;
        GameObject parentOfOvenSmallExplosionParticles = ovenSmallExplosionParticles.transform.parent.gameObject;

        parentOfOvenSmallExplosionParticles.SetActive(true);
        ovenSmallExplosionParticles.Play();

        parentOfOvenFireBigParticles.SetActive(true);
        ovenFireBigParticles.Play();
    }

    public void StopFireParticles()
    {
        GameObject parentOfOvenSmoke = ovenSmokeParticles.transform.parent.gameObject;
        GameObject parentOfOvenFire = ovenFireParticles.transform.parent.gameObject;

        if (parentOfOvenSmoke.activeInHierarchy)
        {
            ovenSmokeParticles.Stop();
            parentOfOvenSmoke.SetActive(false);
        }

        if (parentOfOvenFire.activeInHierarchy)
        {
            ovenFireParticles.Stop();
            parentOfOvenFire.SetActive(false);
        }
    }
}
