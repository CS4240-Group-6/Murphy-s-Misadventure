using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoor : MonoBehaviour
{
    public GameObject doorPlaceholder;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
        doorPlaceholder.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision entered: " + collision.gameObject.tag);
        // Check if the collision involves the specific collider you want to deactivate on collision
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision entered with player tag");
            // Deactivate the GameObject to which this script is attached
            doorPlaceholder.SetActive(false);
            door.SetActive(true);
        }
    }
}
