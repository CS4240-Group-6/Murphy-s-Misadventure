using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonController : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference secondaryActionButton; // Reference to the secondary action button

    [SerializeField]
    private HideUnderTableInteraction hideUnderTableInteraction; // Reference to the HideUnderTableInteraction script   

    [SerializeField]
    private FireExtinguisherInteraction fireExtinguisherInteraction; // Reference to the FireExtinguisherInteraction script

    private void Awake()
    {
        hideUnderTableInteraction = GetComponent<HideUnderTableInteraction>(); // Get the HideUnderTableInteraction script
        secondaryActionButton.action.Enable(); // Enable the secondary action button
        // testText.SetActive(false); // Set the testText GameObject to be inactive
    }

    private void OnDestroy()
    {
        secondaryActionButton.action.Disable(); // Disable the secondary action button
    }

    private void Update()
    {
        // Check if the secondary action button is pressed
        if (secondaryActionButton.action.triggered)
        {
            if (GlobalState.GetLevel() == 5) {
                fireExtinguisherInteraction.EjectParticles(); // Call the EjectParticles method from the FireExtinguisherInteraction script
            }
            if (GlobalState.GetLevel() == 6) {
                hideUnderTableInteraction.SetPlayerUnderSturdyTable(); // Call the SetPlayerUnderSturdyTable method from the HideUnderTableInteraction script   
            }       
        }
    }
}
