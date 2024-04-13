using System.Collections;
using System.Collections.Generic;
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
