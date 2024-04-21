using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonControllerKitchen : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference secondaryActionButton; // Reference to the secondary action button

    [SerializeField]
    private FireExtinguisherInteraction fireExtinguisherInteraction;

    [SerializeField]
    KitchenInteractions kitchenInteractions;

    private void Awake()
    {
        secondaryActionButton.action.Enable(); // Enable the secondary action button
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
            if (fireExtinguisherInteraction.isExtinguisherInHand)
            {
                fireExtinguisherInteraction.EjectParticles();
            }
            if (kitchenInteractions.isHoverLeft1)
            {
                kitchenInteractions.RotateStoveKnobLeft1();
            }
            if (kitchenInteractions.isHoverLeft2)
            {
                kitchenInteractions.RotateStoveKnobLeft2();
            }
            if (kitchenInteractions.isHoverRight1)
            {
                kitchenInteractions.RotateStoveKnobRight1();
            }
            if (kitchenInteractions.isHoverRight2)
            {
                kitchenInteractions.RotateStoveKnobRight2();
            }
            if (kitchenInteractions.isHoverOvenSwitch)
            {
                kitchenInteractions.ToggleOven();
            }
            if (kitchenInteractions.isHoverOvenDoor)
            {
                kitchenInteractions.OpenOvenDoor();
            }
            if (kitchenInteractions.isHoverBedroom)
            {
                kitchenInteractions.LoadBedroomScene();
            }
        }
    }
}
