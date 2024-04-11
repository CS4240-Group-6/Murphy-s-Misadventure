using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    Vector3 originalPos;
    Quaternion originalRot;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
        originalRot = gameObject.transform.rotation;
    }

    // private void OnDisable()
    // {
    //     ResetPosition();
    // }

    public void ResetPosition()
    {
        transform.position = originalPos;
        transform.rotation = originalRot;
    }
}
