using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomEmergencies : MonoBehaviour
{
    // Sound Script
    public SoundManager soundManager;

    // WET EXTENSION CORD
    public GameObject ExtensionSmoke;
    public GameObject CeilingLight1;
    public GameObject CeilingLight2;
    public GameObject CeilingLight3;
    public GameObject CeilingLight4;
    public GameObject CeilingLight5;
    public float flickerIntervalShort;
    public float flickerIntervalLong;
    private bool isFlicker = false;

    // Start is called before the first frame update
    void Start()
    {
        ExtensionSmoke.SetActive(false);

        StartLightFuseScene();
        // StartIntruderScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Scene starts
        5s later -> smoke in extension cord starts
        15s later -> lights flicker
        10s later -> power cut off and dim emergency light on
    */
    public void StartLightFuseScene()
    {
        Invoke("StartVoiceOver1", 1.0f);
        Invoke("StartSmokeEffect", 5.0f);
        Invoke("StartVoiceOver2", 7.0f);
        Invoke("LightsFlickerEffect", 20.0f);
        Invoke("PowerOutageEffect", 30.0f);
        Invoke("StartVoiceOver3", 33.0f);
    }

    void StartVoiceOver1()
    {
        soundManager.PlayAnotherLongDay();
    }

    void StartVoiceOver2()
    {
        soundManager.PlayWhatsThatSound();
    }

    void StartVoiceOver3()
    {
        soundManager.PlayLightWentOut();
    }

    void StartSmokeEffect()
    {
        // Add spark animation code logic here
        ExtensionSmoke.SetActive(true);
        Transform childTransform = ExtensionSmoke.transform.Find("ExtensionSmokeEffect");
        if (childTransform != null)
        {
            ParticleSystem ExtensionSmokeEffect = childTransform.gameObject.GetComponent<ParticleSystem>();
            ExtensionSmokeEffect.Play();
            soundManager.PlayWireSparkSound();
        }
    }

    void LightsFlickerEffect()
    {
        isFlicker = true;
        StartCoroutine(ToggleLights());
    }

    void PowerOutageEffect()
    {
        // Add animation logic here
        isFlicker = false;
        StopCoroutine(ToggleLights());
        CeilingLight1.SetActive(false);
        CeilingLight2.SetActive(false);
        CeilingLight3.SetActive(false);
        CeilingLight4.SetActive(false);
        CeilingLight5.SetActive(false);
        soundManager.PlayLightsOffSound();
    }

    IEnumerator ToggleLights()
    {
        while (isFlicker)
        {
            CeilingLight1.SetActive(false);
            CeilingLight2.SetActive(false);
            CeilingLight3.SetActive(false);
            CeilingLight4.SetActive(false);
            CeilingLight5.SetActive(false);
            soundManager.PlayLightsOffSound();
            yield return new WaitForSeconds(flickerIntervalShort);
            CeilingLight1.SetActive(true);
            CeilingLight2.SetActive(true);
            CeilingLight3.SetActive(true);
            CeilingLight4.SetActive(true);
            CeilingLight5.SetActive(true);
            yield return new WaitForSeconds(flickerIntervalLong);
            CeilingLight1.SetActive(false);
            CeilingLight2.SetActive(false);
            CeilingLight3.SetActive(false);
            CeilingLight4.SetActive(false);
            CeilingLight5.SetActive(false);
            soundManager.PlayLightsOffSound();
            yield return new WaitForSeconds(flickerIntervalLong);
            CeilingLight1.SetActive(true);
            CeilingLight2.SetActive(true);
            CeilingLight3.SetActive(true);
            CeilingLight4.SetActive(true);
            CeilingLight5.SetActive(true);
            yield return new WaitForSeconds(flickerIntervalShort);
            CeilingLight1.SetActive(false);
            CeilingLight2.SetActive(false);
            CeilingLight3.SetActive(false);
            CeilingLight4.SetActive(false);
            CeilingLight5.SetActive(false);
            soundManager.PlayLightsOffSound();
            yield return new WaitForSeconds(flickerIntervalShort);
        }
    }

    /**
        Scene starts
        5s later -> door knocking
        25s later -> knocking stops and lockpicking starts
        35s later -> door is unlocked
    */
    public void StartIntruderScene()
    {
        Invoke("StartKnockingSound", 5.0f);
        Invoke("StartVoiceOver6", 10.0f);
    }

    void StartVoiceOver4()
    {
        soundManager.PlayIDidntOrderDelivery();
    }

    void StartVoiceOver5()
    {
        soundManager.PlayLeaveOrICallPolice();
    }

    void StartVoiceOver6()
    {
        soundManager.PlayIntruderDialogue();
    }

    void StartKnockingSound()
    {
        soundManager.PlayDoorKnockSound();
    }

    void OpenDoor()
    {
        //  Add animation logic here
    }

}
