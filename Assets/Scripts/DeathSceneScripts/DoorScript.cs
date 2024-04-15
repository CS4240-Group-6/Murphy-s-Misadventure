using System.Collections;
using System.Collections.Generic;
using GLTFast.Schema;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
            rb.MovePosition(target.transform.position);
    }

    public void OpenDoor()
    {
        Debug.Log("It works");
        // Add change scene logic here Jonny
        int previousLevel = GlobalState.GetLevel();
        GlobalState.SetStartLevel(true);
        if (previousLevel == 1 || previousLevel == 2) {
            SceneManager.LoadScene("LivingRoomScene");
        }
        else if (previousLevel == 3 || previousLevel == 4) {
            SceneManager.LoadScene("KitchenScene");
            Debug.Log("It reaches the go to KitchenScene code");
        }
        else if (previousLevel == 5 || previousLevel == 6) {
            SceneManager.LoadScene("BedroomScene");
        }
    }
}
