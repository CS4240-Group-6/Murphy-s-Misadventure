using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenEmergencies : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;
    public float Timer;

    // OIL FIRE
    public GameObject OilFireStart;
    public GameObject OilFireSpread;

    // OVEN FIRE
    public GameObject OvenSmoke;
    public GameObject OvenExplosion;

    // Start is called before the first frame update
    void Start()
    {
        OilFireStart.SetActive(false);
        OilFireSpread.SetActive(false);

        OvenSmoke.SetActive(false);
        OvenExplosion.SetActive(false);

        Timer = Random.Range(MinTime, MaxTime);
        StartOilFireScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Scene starts
        5s later -> pan catches on fire
        5s later -> pan fire strenghtens
        10s later -> fire spreads to whole stove if unattended
        5s later -> stove fire strengthens
    */
    void StartOilFireScene()
    {
        Invoke("StartOilFireEffect", 5.0f);
        Invoke("StrenghtenOilFireEffect", 10.0f);
        Invoke("StartOilFireSpreadEffect", 20.0f);
        Invoke("StrenghtenOilFireSpreadEffect", 25.0f);
    }

    void StartOilFireEffect()
    {
        OilFireStart.SetActive(true);
        Transform childTransform = OilFireStart.transform.Find("OilFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OilFireStartEffect.Play();
        }
    }

    void StrenghtenOilFireEffect()
    {   
        Transform childTransform = OilFireStart.transform.Find("OilFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            var Emission = OilFireStartEffect.emission;
            Emission.rateOverTime = 30.0f;
        }
    }

    void StartOilFireSpreadEffect()
    {
        OilFireSpread.SetActive(true);
        Transform childTransform = OilFireStart.transform.Find("OilFireSpreadEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireSpreadEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OilFireSpreadEffect.Play();
        }
    }

    void StrenghtenOilFireSpreadEffect()
    {   
        Transform childTransform = OilFireSpread.transform.Find("OilFireSpreadEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireSpreadEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            var Emission = OilFireSpreadEffect.emission;
            Emission.rateOverTime = 45.0f;
        }
    }
}
