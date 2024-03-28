using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomEmergencies : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;
    public float Timer;

    // Tooltip
    [Header("Tooltips")]
    [SerializeField] private GameObject tooltipForCircuitBreaker;
    [SerializeField] private GameObject tooltipForMainDoor;
    [SerializeField] private GameObject tooltipForKitchenDoor;
    [SerializeField] private GameObject tooltipForBedroomDoor;
    [SerializeField] private GameObject tooltipForFireExtinguisher;
    [SerializeField] private GameObject tooltipForWetExtensionCord;
    [SerializeField] private GameObject tooltipForLightSwitch;

    // Sound Script
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);

        StartLightFuseScene();
        // StartIntruderScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Scene starts
        5s later -> sparks in extension cord starts
        20s later -> power cut off and dim emergency light on
    */
    public void StartLightFuseScene()
    {
        Invoke("StartVoiceOver1", 1.0f);
        Invoke("StartSparkEffect", 5.0f);
        Invoke("StartVoiceOver2", 7.0f);
        Invoke("PowerOutageEffect", 20.0f);
        Invoke("StartVoiceOver3", 22.0f);
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

    void StartSparkEffect()
    {
        soundManager.PlayWireSparkSound();
        // Add spark animation code logic here
    }


    void PowerOutageEffect()
    {
        soundManager.PlayLightsOffSound();
        // Add animation logic here
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

    public void hoverOnCircuitBreakerForToolTip()
    {
        tooltipForCircuitBreaker.SetActive(true);
    }
    public void hoverOffCircuitBreakerForToolTip()
    {
        tooltipForCircuitBreaker.SetActive(false);
    }

    public void HoverOnMainDoorToolTip() {
        tooltipForMainDoor.SetActive(true);
    }
    public void HoverOffMainDoorToolTip() {
        tooltipForMainDoor.SetActive(false);
    }

    public void HoverOnKitchenDoorToolTip() {
        tooltipForKitchenDoor.SetActive(true);
    }
    public void HoverOffKitchenDoorToolTip() {
        tooltipForKitchenDoor.SetActive(false);
    }
    
    public void HoverOnBedroomDoorToolTip() {
        tooltipForBedroomDoor.SetActive(true);
    }
    public void HoverOffBedroomDoorToolTip() {
        tooltipForBedroomDoor.SetActive(false);
    }

    public void HoverOnFireExtinguisherToolTip() {
        tooltipForFireExtinguisher.SetActive(true);
    }
    public void HoverOffFireExtinguisherToolTip() {
        tooltipForFireExtinguisher.SetActive(false);
    }

    public void HoverOnWetExtensionCordTip() {
        tooltipForWetExtensionCord.SetActive(true);
    }
    public void HoverOffWetExtensionCordToolTip() {
        tooltipForWetExtensionCord.SetActive(false);
    }

    public void HoverOnLightSwitchToolTip() {
        tooltipForLightSwitch.SetActive(true);
    }
    public void HoverOffLightSwitchToolTip() {
        tooltipForLightSwitch.SetActive(false);
    }
}
