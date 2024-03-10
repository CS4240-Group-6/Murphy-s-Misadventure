using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalFire : MonoBehaviour
{
    public ParticleSystem sparksFlying;
    public ParticleSystem bigSparks;
    public GameObject plugFire;
    public GameObject smallTableFire;
    public GameObject comTableFire;
    public float MinTime;
    public float MaxTime;
    public float Timer;
    public Light tableLight;
    private bool flickerLight = false;

    // Start is called before the first frame update
    void Start()
    {
        plugFire.SetActive(false);
        smallTableFire.SetActive(false);
        comTableFire.SetActive(false);
        StartScene();
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerLight)
            LightFlickering();
        
    }

    /*
        Scene starts with sparks flying first.
        Player dialogue: what was that?
        10 secs later -> Big electrical ParticleSystem plays
                     -> Lights start flickering
        20s later -> Fire starts
        every 10s -> Something catches fire
        60s limit -> YOU DIED
    */
    void StartScene() {
        sparksFlying.Play();
        Invoke("StartElectricityEffect", 10f);
        Invoke("StartPlugFireEffect", 15f);
        Invoke("LightFlickering", 15f);
        Invoke("StartSmallTableFireEffect", 18f);
        Invoke("StartComTableFireEffect", 21f);
    }

    void StartElectricityEffect() {
        bigSparks.Play();
    }

    void StartPlugFireEffect() {
        plugFire.SetActive(true);
        Transform childTransform = plugFire.transform.Find("Fire_Yellow");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void StartSmallTableFireEffect() {
        smallTableFire.SetActive(true);
        Transform childTransform = smallTableFire.transform.Find("Fire_Green");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void StartComTableFireEffect() {
        comTableFire.SetActive(true);
        Transform childTransform = comTableFire.transform.Find("Fire_Blue");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void LightFlickering() {
        flickerLight = true;
        if (Timer > 0) {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0) {
            tableLight.enabled = !tableLight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
