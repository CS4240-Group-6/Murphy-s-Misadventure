using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugAnimationScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float forceMagnitude = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlugOut() {
        if (rb != null)
        {
            // Calculate the force vector (-x direction)
            Vector3 force = new Vector3(-1f, 0f, -1f) * forceMagnitude;

            // Apply the force to the Rigidbody
            rb.AddForce(force, ForceMode.Force);
        }
    }
}
