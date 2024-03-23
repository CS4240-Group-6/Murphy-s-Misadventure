using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer lineRenderer = null;
    private ParticleSystem splashParticle = null;

    private Coroutine pourRoutine = null;
    private Vector3 targetPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        splashParticle = GetComponentInChildren<ParticleSystem>();
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        pourRoutine = StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while(gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();

            MoveToPosition(0, transform.position);
            AnimateToPositoin(1, targetPosition);

            yield return null;
        }
        
    }

    public void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        while(!HasReachedPositon(0, targetPosition))
        {
            AnimateToPositoin(0, targetPosition);
            AnimateToPositoin(1, targetPosition);

            yield return null;
        }

        Destroy(gameObject);
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 5.0f);

        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(5.0f);

        if (hit.collider.isTrigger && hit.transform.gameObject.tag == "Fill")
        {
            Debug.Log("hit object to be filled");
            // fill object
        }

        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index, targetPosition);
    }

    private void AnimateToPositoin(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPositon(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticle()
    {
        while(gameObject.activeSelf)
        {
            splashParticle.gameObject.transform.position = targetPosition;

            bool isHitting = HasReachedPositon(1, targetPosition);
            splashParticle.gameObject.SetActive(isHitting);

            yield return null;
        }
    }

    private void AddColliderToStream()
    {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();

        col.transform.parent = lineRenderer.transform;

        float lineLength = Vector3.Distance(transform.position, targetPosition);
        col.size = new Vector3(lineLength, 0.1f, 0.1f);

        Vector3 midPoint = (transform.position + targetPosition)/2;
        col.transform.position = midPoint;

        col.transform.Rotate(0, 0, 90);
    }
}
