using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour
{
    [SerializeField] private AudioSource putOutFireAudio;
    [SerializeField] private ParticleSystem oilFireParticles;
    [SerializeField] private ParticleSystem oilFireSpreadParticles;
    [SerializeField] private ParticleSystem oilFireExplosionParticles;
    [SerializeField] private ParticleSystem oilFireBigParticles;

    public float durationThreshold; // Duration threshold for triggering the effect
    public float waterThreshold; // Duration threshold for water over fire

    private float timer = 0f;
    private float waterTimer = 0f;
    private bool isOilOverFire = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        isOilOverFire = false;
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("oil particle fire");
        if (other.CompareTag("Oil"))
        {
            //isOilOverFire = true;
            StartCoroutine(OilOverFire());
        }
        if (other.CompareTag("Water"))
        {
            StartCoroutine(WaterOverFire());
        }
        else
        {
            isOilOverFire = false;
        }
    }

    private IEnumerator WaterOverFire()
    {
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        if (parentOfOilFire.activeInHierarchy)
        {
            Debug.Log(waterTimer);
            waterTimer += Time.deltaTime;
            if (waterTimer > waterThreshold)
            {
                StartFireBigParticles();
            }
        }
        yield return null;
    }

    void StartFireBigParticles()
    {
        GameObject parentOfOilFireBigParticles = oilFireBigParticles.transform.parent.gameObject;
        GameObject parentOfOilFireExplosionParticles = oilFireExplosionParticles.transform.parent.gameObject;

        parentOfOilFireExplosionParticles.SetActive(true);
        oilFireExplosionParticles.Play();

        parentOfOilFireBigParticles.SetActive(true);
        oilFireBigParticles.Play();
    }

    private IEnumerator OilOverFire()
    {
        Debug.Log(timer);
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        if (parentOfOilFire.activeInHierarchy)
        {
            putOutFireAudio.loop = true;
            if (!putOutFireAudio.isPlaying)
            {
                putOutFireAudio.Play();
            }

            timer += Time.deltaTime;
            if (timer >= durationThreshold)
            {
                Debug.Log("enter stop fire particles");
                StopFireParticles();
                KitchenSceneState.SetOilAddedToPan(true);
            }
        }

        yield return null;
    }

    void StopFireParticles()
    {
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        GameObject parentOfOilFireSpread = oilFireSpreadParticles.transform.parent.gameObject;

        //isOilOverFire = false;

        if (parentOfOilFire.activeInHierarchy)
        {
            oilFireParticles.Stop();
            parentOfOilFire.SetActive(false);
        }

        if (parentOfOilFireSpread.activeInHierarchy)
        {
            oilFireSpreadParticles.Stop();
            parentOfOilFireSpread.SetActive(false);
        }
    }
}
