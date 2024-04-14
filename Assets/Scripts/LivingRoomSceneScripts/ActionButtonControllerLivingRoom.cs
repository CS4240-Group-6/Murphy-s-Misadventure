using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonControllerLivingRoom : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference aButton; // Reference to the primary action button
    [SerializeField]
    private InputActionReference bButton; // Reference to the secondary action button

    [SerializeField]
    LivingRoomInteractions livingRoomInteractions;

    private void Awake()
    {
        aButton.action.Enable(); // Enable the primary action button
        bButton.action.Enable(); // Enable the secondary action button
        // livingRoomInteractions = GetComponent<LivingRoomInteractions>();
    }

    private void OnDestroy()
    {
        aButton.action.Disable(); // Disable the primary action button
        bButton.action.Disable(); // Disable the secondary action button
    }

    // Update is called once per frame
    void Update()
    {
        if (aButton.action.triggered)
        {
            Debug.Log("A button pressed");
        }
        if (bButton.action.triggered)
        {
            Debug.Log("B button pressed");
            if (GlobalState.GetLevel() == 1) {
                livingRoomInteractions.TurnOnLights();
                // livingRoomInteractions.OpenCircuitBreaker();
            }
        }
    }
}
