using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidPour : MonoBehaviour
{
    private ParticleSystem FluidParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        FluidParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            FluidParticleSystem.Play();
        }
        else
        {
            FluidParticleSystem.Stop();
        }
    }
}
