using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Color startColor = Color.cyan;
    public Color endColor = Color.black;
    [Range(0,10)]
    public float speed = 1;

    Renderer renderer;

    void Awake() {
        renderer = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        renderer.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
