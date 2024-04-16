using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonControllerTutorialRoom : MonoBehaviour
{
    [SerializeField] private InputActionReference aButton; // Reference to the primary action button

    [SerializeField] TutorialRoomHandler tutorialRoom;
    [SerializeField] FireExtinguisherInteractionForTutorial fireExtinguisher;

    private void Awake()
    {
        aButton.action.Enable(); // Enable the primary action button
        tutorialRoom = GetComponent<TutorialRoomHandler>();
    }

    private void OnDestroy()
    {
        aButton.action.Disable(); // Disable the primary action button
    }

    // Update is called once per frame
    void Update()
    {
        if (aButton.action.triggered)
        {
            Debug.Log("A button pressed");
            if (tutorialRoom.isHoverIntroDoor)
            {
                tutorialRoom.LoadIntroScene();
            }
            else if (tutorialRoom.isHoverFuseBoxSwitch) {
                tutorialRoom.ActivateFuseBoxSwitch();
            }
            else if (fireExtinguisher.isExtinguisherInHand) {
                fireExtinguisher.EjectParticles();
            }
        }
    }
}
