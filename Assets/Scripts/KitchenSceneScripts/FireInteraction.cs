using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour
{
    [SerializeField] private AudioSource putOutFireAudio;
    [SerializeField] private ParticleSystem oilFireParticles;
    [SerializeField] private ParticleSystem oilFireSpreadParticles;

    public float durationThreshold; // Duration threshold for triggering the effect

    private float timer = 0f;
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
        else
        {
            isOilOverFire = false;
        }
    }

    private IEnumerator OilOverFire()
    {
        Debug.Log(timer);
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        if (parentOfOilFire.activeInHierarchy)
        {
            //Debug.Log("putting out fire");
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
