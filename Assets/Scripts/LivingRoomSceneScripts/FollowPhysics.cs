using UnityEngine;

public class FollowPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // MovePosition smoothly moves the object to the target position in a way that works with the physics engine.
        rb.MovePosition(target.position);
        rb.MoveRotation(target.rotation); // also match the target's rotation
    }
}
