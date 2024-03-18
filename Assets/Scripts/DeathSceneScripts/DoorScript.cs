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
        rb.MovePosition(target.transform.position);
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
