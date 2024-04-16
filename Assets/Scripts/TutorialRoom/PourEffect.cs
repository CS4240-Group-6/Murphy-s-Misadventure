using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourEffect : MonoBehaviour
{
    private bool bakingSodaParticlesActive;
    [SerializeField] private GameObject bakingSoda;
    [SerializeField] private ParticleSystem bakingSodaParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(bakingSoda.transform.up, Vector3.up) > 90f)
        {
            if (!bakingSodaParticlesActive)
            {
                // Start emitting particles
                bakingSodaParticles.Play();
                bakingSodaParticlesActive = true;
            }
        }
        else
        {
            if (bakingSodaParticlesActive)
            {
                // Stop emitting particles
                bakingSodaParticles.Stop();
                bakingSodaParticlesActive = false;
            }
        }
    }
}
