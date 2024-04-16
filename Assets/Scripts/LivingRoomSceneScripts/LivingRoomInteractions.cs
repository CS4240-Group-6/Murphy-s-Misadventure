using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LivingRoomInteractions : MonoBehaviour
{
    // Tooltip
    [Header("Tooltips")]
    [SerializeField] private GameObject tooltipForCircuitBreaker;
    [SerializeField] private GameObject tooltipForMainDoor;
    [SerializeField] private GameObject tooltipForKitchenDoor;
    [SerializeField] private GameObject tooltipForBedroomDoor;
    [SerializeField] private GameObject tooltipForFireExtinguisher;
    [SerializeField] private GameObject tooltipForWetExtensionCord;
    [SerializeField] private GameObject tooltipForLightSwitch;
    [SerializeField] private GameObject tooltipForSocket;

    [SerializeField] private SoundManager soundManager;

    // GameObjects
    [SerializeField] private GameObject MainDoor;
    [SerializeField] private GameObject CircuitBreakerDoor;

    // For Action Button
    public bool isHoverKitchen = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (LivingRoomSceneState.Level2Complete()) {
            isHoverKitchen = true;
            tooltipForKitchenDoor.SetActive(true);
        }   
    }
    public void HoverOffKitchenDoorToolTip() {
        if (tooltipForKitchenDoor)
        {
            isHoverKitchen = false;
            tooltipForKitchenDoor.SetActive(false);
        }
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

    // public void HoverOnWetExtensionCordTip() {
    //     tooltipForWetExtensionCord.SetActive(true);
    // }
    // public void HoverOffWetExtensionCordToolTip() {
    //     tooltipForWetExtensionCord.SetActive(false);
    // }

    public void HoverOnLightSwitchToolTip() {
        tooltipForLightSwitch.SetActive(true);
    }
    public void HoverOffLightSwitchToolTip() {
        tooltipForLightSwitch.SetActive(false);
    }

    public void HoverOnSocketToolTip() {
        tooltipForSocket.SetActive(true);
    }
    public void HoverOffSocketToolTip() {
        tooltipForSocket.SetActive(false);
    }

    public void PullOutExtensionCord() {
        if (tooltipForSocket.activeSelf) {
            Debug.Log("Extension cord pulled out");
            
            LivingRoomSceneState.SetExtensionCordPulled();
        }
    }

    public void TurnOnLights() {
        if (tooltipForLightSwitch.activeSelf && !LivingRoomSceneState.IsExtensionCordPulled()) {
            Debug.Log("Extension cord is wet, lights cannot be turned on");

            // Turn on lights for a while then off with a bang
            
        }
        else if(tooltipForLightSwitch.activeSelf && LivingRoomSceneState.IsExtensionCordPulled()) {
            Debug.Log("Lights turned on");
            
            LivingRoomSceneState.SetCircuitBreakerOn();
        }
    }

    public void LockDoor() {
        if (tooltipForMainDoor.activeSelf && !GlobalState.IsGameOver() && !LivingRoomSceneState.Level2Complete()) {
            Debug.Log("Main door locked");
            MainDoor.GetComponent<DoorAnimation>().OnDoorLockGrabbed();
            soundManager.PlayDoorUnlockSound();
            soundManager.PlayLeaveOrICallPolice();
            LivingRoomSceneState.SetDoorLocked();
        }
    }

    public void LoadKitchenScene() 
    {
        SceneManager.LoadScene("KitchenScene");
        // GlobalState.IncrementLevel();
    }
}
