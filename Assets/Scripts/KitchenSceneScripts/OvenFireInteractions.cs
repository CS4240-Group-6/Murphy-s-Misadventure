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

    [SerializeField] private KitchenInteractions kitchenInteractions;
 
    public float extinguisherDurationThreshold; // Duration threshold for extinguisher
    public float waterThreshold; // Duration threshold for water over fire
    public float ovenDurationThreshold; // Duration threshold for offing oven

    private float timer = 0f;
    private float waterTimer = 0f;
    private float ovenTimer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalState.GetLevel() == 4)
        {
            if (!kitchenInteractions.GetOvenState())
            {
                ovenTimer += Time.deltaTime;
                if (ovenTimer > ovenDurationThreshold)
                {
                    StopFireParticles();
                    KitchenSceneState.SetOvenTurnedOff(true);
                }
                else
                {
                    KitchenSceneState.SetOvenTurnedOff(false);
                }
            }
            else if (kitchenInteractions.GetOvenState())
            {
                ovenTimer = 0;
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (GlobalState.GetLevel() == 4)
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

    public void StartOvenExplosion()
    {
        GameObject parentOfOvenExplosionParticles = ovenExplosionParticles.transform.parent.gameObject;

        parentOfOvenExplosionParticles.SetActive(true);

        ovenExplosionParticles.Play();
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

    void StopFireParticles()
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
