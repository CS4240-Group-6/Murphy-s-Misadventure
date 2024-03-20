using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer lineRenderer = null;
    private Vector3 targetPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Begin()
    {
        StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while(gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();

            MoveToPosition(0, transform.position);
            MoveToPosition(1, targetPosition);

            yield return null;
        }
        
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 10.0f);

        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(10.0f);
        Debug.Log(endPoint);

        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 tartgetPositon)
    {
        lineRenderer.SetPosition(index, targetPosition);
    }
}
