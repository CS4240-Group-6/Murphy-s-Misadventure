using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStove : MonoBehaviour
{
    private List<ResetObject> resetObjects = new List<ResetObject>();

    // Start is called before the first frame update
    void Start()
    {
        ResetObject[] foundObjects = GetComponentsInChildren<ResetObject>();
        resetObjects.AddRange(foundObjects);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetStoveObjects()
    {
        foreach (ResetObject ro in resetObjects)
        {
            ro.ResetPosition();
        }
    }
}
