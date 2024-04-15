using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KitchenEmergencies : MonoBehaviour
{    
    // OIL FIRE
    public GameObject OilFireStart;
    public GameObject OilFireSpread;
    public GameObject OilFireExplosion;
    public GameObject OilFireBig;

    // OVEN FIRE
    public GameObject OvenSmoke;
    public GameObject OvenFireStart;
    public GameObject OvenExplosion;
    public GameObject OvenFireBig;
    public GameObject OvenSmallExplosion;

    [SerializeField] private KitchenInteractions kitchenInteractions;

    // Sound Script
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        OilFireStart.SetActive(false);
        OilFireSpread.SetActive(false);

        OvenSmoke.SetActive(false);
        OvenFireStart.SetActive(false);
        OvenExplosion.SetActive(false);

        GlobalState.SetStartLevel(true);

        if (GlobalState.GetLevel() == 3)
        {
            StartOilFireScene();
        }
        else if (GlobalState.GetLevel() == 4)
        {
            StartOvenFireScene();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // if (KitchenSceneState.Level3Complete())
        // {
        //     soundManager.StopAllLvl3Sounds();
        // }

        // if(KitchenSceneState.Level4Complete())
        // {
        //     soundManager.StopAllLvl4Sounds();
        // }
    }

    /**
        ================ OIL FIRE SCENE =================
        Scene starts
        10s later -> pan catches on fire
        50s later -> pan fire strenghtens
        1min later -> fire spreads to whole stove if unattended
        10s later -> stove fire strengthens
    */
    public void StartOilFireScene()
    {
        kitchenInteractions.ToggleOvenOff();

        Invoke("StartOilFireEffect", 10.0f);
        Invoke("StartVoiceOver1", 10.0f);
        Invoke("StartVoiceOver2", 35.0f);
        Invoke("StrenghtenOilFireEffect", 60.0f);
        Invoke("StartVoiceOver3", 60.0f);
        Invoke("StartOilFireSpreadEffect", 120.0f);
        Invoke("StrenghtenOilFireSpreadEffect", 130.0f);
    }

    void StartVoiceOver1()
    {
        soundManager.PlaySmellSomethingBurning();
    }

    void StartVoiceOver2()
    {
        soundManager.PlayShouldTurnOffSomethingAndCoverPan();
    }

    void StartVoiceOver3()
    {
        soundManager.PlayFireGotBiggerNeedToPour();
    }

    void StartOilFireEffect()
    {
        OilFireStart.SetActive(true);
        Transform childTransform = OilFireStart.transform.Find("OilFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OilFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OilFireStartEffect.Play();
            soundManager.PlayFireBurningSound();
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

    public void ExtinguishOilFire()
    {
        OilFireStart.SetActive(false);
        OilFireSpread.SetActive(false);
        OilFireExplosion.SetActive(false);
        OilFireBig.SetActive(false);
    }

    /**
        ================ OVEN FIRE SCENE ==================
        Scene starts
        15s later -> smoke comes out from oven
        45s later -> fire starts
        15s later -> fire strenghtens
    */
    public void StartOvenFireScene()
    {
        kitchenInteractions.ToggleOvenOn();
        Invoke("StartOvenSmokeEffect", 15.0f);
        Invoke("StartVoiceOver4", 15.0f);
        Invoke("StartOvenFireEffect", 45.0f);
        Invoke("StrenghtenOvenFireEffect", 60.0f);
        Invoke("StartVoiceOver5", 60.0f);
    }

    void StartVoiceOver4()
    {
        soundManager.PlayIsThatSmoke();
    }

    void StartVoiceOver5()
    {
        soundManager.PlayNeedToExtinguishFireSoon();
    }

    void StartOvenSmokeEffect()
    {
        OvenSmoke.SetActive(true);
        Transform childTransform = OvenSmoke.transform.Find("OvenSmoketEffect");
        if (childTransform != null)
        {
            ParticleSystem OvenSmoketEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OvenSmoketEffect.Play();
            soundManager.PlayFireBurningSound();
        }
    }

    void StartOvenFireEffect()
    {
        OvenFireStart.SetActive(true);
        Transform childTransform = OvenFireStart.transform.Find("OvenFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OvenFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            OvenFireStartEffect.Play();
            soundManager.PlayFireBurningSound();
        }
    }

    void StrenghtenOvenFireEffect()
    {   
        Transform childTransform = OvenFireStart.transform.Find("OvenFireStartEffect");
        if (childTransform != null)
        {
            ParticleSystem OvenFireStartEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            var Emission = OvenFireStartEffect.emission;
            Emission.rateOverTime = 20.0f;
        }
    }

    public void ExtinguishOvenFire()
    {
        OvenSmoke.SetActive(false);
        OvenFireStart.SetActive(false);
        OvenExplosion.SetActive(false);
        OvenFireBig.SetActive(false);
        OvenSmallExplosion.SetActive(false);
    }

    public void LoadBedroomScene() 
    {
        SceneManager.LoadScene("BedroomScene");
        // GlobalState.IncrementLevel();
    }
}
