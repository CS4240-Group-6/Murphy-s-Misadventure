#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool isPouring = false;
    private Stream currentStream = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalcaulatePourAngle() < pourThreshold;

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        Debug.Log("start");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        Debug.Log("end");
        currentStream.End();
        currentStream = null;
    }

    private float CalcaulatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
#endif