using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // private void OnDisable()
    // {
    //     ResetPosition();
    // }

    public void ResetPosition()
    {
        transform.position = originalPos;
    }
}
