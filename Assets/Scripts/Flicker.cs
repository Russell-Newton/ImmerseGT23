using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{

    public float flickerSpeed;
    public float flickerSaturation;

    private Color baseColor;
    private Light toFlicker;
    private float flickerY;

    // Start is called before the first frame update
    void Start()
    {
        toFlicker = GetComponent<Light>();
        baseColor = toFlicker.color;
        flickerY = Random.Range(0, 10);
        GameObject.Find("XR Rig").GetComponentInChildren<Camera>().gameObject.AddComponent<FlareLayer>();
    }

    // Update is called once per frame
    void Update()
    {
        toFlicker.color = baseColor * Mathf.Clamp01(flickerSaturation + Mathf.PerlinNoise(flickerSpeed * Time.time, flickerY));
    }
}
