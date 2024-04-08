using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonController : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference secondaryActionButton; // Reference to the secondary action button

    private HideUnderTableInteraction hideUnderTableInteraction; // Reference to the HideUnderTableInteraction script   

    // [SerializeField]
    // private GameObject testText;

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
            // fireExtinguisherInteraction.EjectParticles(); // Call the EjectParticles method from the FireExtinguisherInteraction script
            if (GlobalState.GetLevel() == 5) {
                // hideUnderTableInteraction.SetPlayerUnderTable(); // Call the SetPlayerUnderTable method from the HideUnderTableInteraction script
            }
            if (GlobalState.GetLevel() == 6) {
                hideUnderTableInteraction.SetPlayerUnderSturdyTable(); // Call the SetPlayerUnderSturdyTable method from the HideUnderTableInteraction script   
            }       
            // Toggle the visibility of the testText GameObject
            // testText.SetActive(!testText.activeSelf); 
        }
    }
}
