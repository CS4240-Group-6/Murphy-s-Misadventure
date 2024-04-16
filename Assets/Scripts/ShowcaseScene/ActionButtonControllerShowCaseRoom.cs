using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionButtonControllerShowCaseRoom : MonoBehaviour
{
    [SerializeField] 
    private InputActionReference aButton; // Reference to the primary action button

    [SerializeField]
    ShowCaseRoomHandler showCaseRoom;

    private void Awake()
    {
        aButton.action.Enable(); // Enable the primary action button
        showCaseRoom = GetComponent<ShowCaseRoomHandler>();
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
            if (showCaseRoom.isHoverIntroDoor)
            {
                showCaseRoom.LoadIntroScene();
            }
        }
    }
}
