using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlugController : MonoBehaviour
{
    public bool isConnected = false;
    public UnityEvent OnWirePlugged;
    public UnityEvent OnWireUnplugged;
    public Transform plugPosition;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;
    public void OnPlugged()
    {
        OnWirePlugged.Invoke();
    }

    public void OnUnplugged()
    {
        OnWireUnplugged.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject == endAnchor.gameObject)
        {
            // isConnected = true;
            // endAnchorRB.isKinematic = true;
            // endAnchor.transform.position = plugPosition.position;
            // endAnchor.transform.rotation = transform.rotation;


            // OnPlugged();
            PlugIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == endAnchor.gameObject)
        {
            PlugOut();
        }
    }

    void PlugIn()
    {
        isConnected = true;
        endAnchorRB.isKinematic = true;
        endAnchor.transform.position = plugPosition.position;
        endAnchor.transform.rotation = transform.rotation;
        OnPlugged();
    }

    void PlugOut()
    {
        isConnected = false;
        endAnchorRB.isKinematic = false;
        OnUnplugged();
    }

    private void Update()
    {

        if (isConnected)
        {
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
