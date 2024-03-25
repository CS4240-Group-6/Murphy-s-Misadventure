using System.Collections;
using System.Collections.Generic;
using GLTFast.Schema;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class DoorScript1 : XRGrabInteractable
{
    public Transform target;
    Rigidbody rb;

    // Start is called before the first frame update
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        Debug.Log("onselectEntering");
        // Call the base method first to ensure that necessary setup is done
        base.OnSelectEntering(args);

        // Check if the interactor is grabbing the door
        if (selectingInteractor != null)
        {
            // Check if the interacted object has the "Door" tag
            if (args.interactable.gameObject.CompareTag("Respawn"))
            {
                // Call the method to change the level
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log("It works");
        // Add change scene logic here Jonny
        int previousLevel = GlobalState.GetLevel();
        if (previousLevel == 1 || previousLevel == 2 || previousLevel == 8) {
            SceneManager.LoadScene("BedroomScene");
        }
        else if (previousLevel == 3 || previousLevel == 4 || previousLevel == 5) {
            SceneManager.LoadScene("KitchenScene");
            Debug.Log("It reaches the go to KitchenScene code");
        }
        else if (previousLevel == 6 || previousLevel == 7) {
            SceneManager.LoadScene("BedroomScene");
        }
    }
}
