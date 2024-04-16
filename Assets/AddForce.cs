using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb;
    public float forceMagnitude = 10f;

    public void ApplyForce()
    {
        if (rb != null)
        {
            // Add force to the Rigidbody
            rb.AddForce(Vector3.back * forceMagnitude, ForceMode.Impulse);
        }
    }
}
