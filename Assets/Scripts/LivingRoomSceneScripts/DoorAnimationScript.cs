using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator DoorAnimator;
    private bool isOpen = false;
    private bool isGrabbingDoor = false; 
    private bool isLocked = false;

    void Start()
    {
        DoorAnimator = GetComponentInParent<Animator>();
    }

    public void OnDoorGrabbed(SelectEnterEventArgs args)
    {
        // Check if the Door is already being grabbed
        if (!isGrabbingDoor)
        {
            isGrabbingDoor = true; 
            ToggleDoor();
        }
    }

    public void OnDoorReleased(SelectExitEventArgs args) 
    {
        // Reset the flag when the Door is released
        isGrabbingDoor = false;
    }

    public void OnDoorLockGrabbed()
    {
        isLocked = !isLocked;
        Debug.Log("lock " + isLocked);
    }

    private void ToggleDoor()
    {
        // Toggle Door open/close with animation
        Debug.Log("lock when toggling door " + isLocked);
        if (!isLocked)
        {
            if (isOpen)
            {
                DoorAnimator.Play("CloseDoor");
            }
            else
            {
                DoorAnimator.Play("OpenDoor");
            }
            isOpen = !isOpen;
        }
    }
}

