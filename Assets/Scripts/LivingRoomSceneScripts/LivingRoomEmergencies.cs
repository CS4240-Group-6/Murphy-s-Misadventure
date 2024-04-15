using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    // INTRUDER
    public GameObject Intruder;
    public GameObject MainDoor;

    // Start is called before the first frame update
    void Start()
    {
        ExtensionSmoke.SetActive(false);
        Intruder.SetActive(false);

        // StartLightFuseScene();
        StartIntruderScene();
    }

    // Update is called once per frame
    void Update()
    {
        // if (LivingRoomSceneState.Level1Complete()) {
        //     soundManager.StopAllLvl1Sounds();
        // }
        // if (LivingRoomSceneState.Level2Complete()) {
        //     soundManager.StopAllLvl2Sounds();
        // }
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

    public void StopLightFuseScene()
    {
        CancelInvoke("StartVoiceOver1");
        CancelInvoke("StartSmokeEffect");
        CancelInvoke("StartVoiceOver2");
        CancelInvoke("LightsFlickerEffect");
        CancelInvoke("PowerOutageEffect");
        CancelInvoke("StartVoiceOver3");
    }

    /**
        Scene starts
        5s later -> door knocking
        5s later -> voice at door "delivery"
        5s later -> knocking continues
        10s later -> knocking stops and lockpicking starts
        10s later -> door is unlocked
        5s later -> door swings open
    */
    public void StartIntruderScene()
    {
        Intruder.SetActive(true);
        Invoke("StartKnockingSound", 5.0f);
        Invoke("StartVoiceOver6", 10.0f);
        Invoke("StartVoiceOver4", 15.0f);
        Invoke("StartKnockingSound", 20.0f);
        Invoke("StartLockPickingSound", 25.0f);
        Invoke("StartDoorUnlockingSound", 39.0f);
        Invoke("OpenDoor", 40.0f);
        Invoke("FailLevel", 42.0f);
    }

    public void StopIntruderScene()
    {
        CancelInvoke("StartKnockingSound");
        CancelInvoke("StartVoiceOver6");
        CancelInvoke("StartVoiceOver4");
        CancelInvoke("StartKnockingSound");
        CancelInvoke("StartLockPickingSound");
        CancelInvoke("StartDoorUnlockingSound");
        CancelInvoke("OpenDoor");
        CancelInvoke("FailLevel");
    }

    void StartVoiceOver4()
    {
        soundManager.PlayIDidntOrderDelivery();
    }

    void StartVoiceOver6()
    {
        soundManager.PlayIntruderDialogue();
    }

    void StartKnockingSound()
    {
        soundManager.PlayDoorKnockSound();
    }

    void StartLockPickingSound()
    {
        soundManager.PlayLockPickingSound();
    }

    void StartDoorUnlockingSound()
    {
        soundManager.PlayDoorUnlockSound();
    }

    void OpenDoor()
    {
        //  Add animation logic here
        Animator doorSwingAnimation = MainDoor.gameObject.GetComponent<Animator>();
        doorSwingAnimation.Play("OpenDoor", -1);
    }

    public void FailLevel()
    {
        // Add fail level logic here
        if (!LivingRoomSceneState.Level2Complete()) {
            soundManager.PlayKidnapSound();
            GlobalState.SetGameOver(true);
        } 
    }

    public void LoadKitchenScene() 
    {
        SceneManager.LoadScene("KitchenScene");
        // GlobalState.IncrementLevel();
    }
}
