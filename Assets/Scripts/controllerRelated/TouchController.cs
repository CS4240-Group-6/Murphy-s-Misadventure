using UnityEngine;

public class TouchController : MonoBehaviour
{
    public OVRInput.Controller Controller;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(Controller); //  * Quaternion.Euler(-90, 180, 0)
    }
}
