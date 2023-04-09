using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCaster : MonoBehaviour
{

    public Material material;
    public float transparency = 0.3f;
    public Color saturation = Color.black;

    public float beamStartOffset = 0f;

    private TubeRenderer beamRenderer;
    private LightBeam beam;
    private Light referenceLight;

    private void Start()
    {
        beamRenderer = gameObject.GetComponent<TubeRenderer>();
        beamRenderer.material = material;
        referenceLight = transform.parent.GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beam != null) Destroy(beam.beamObj);
        material.color = new Color(referenceLight.color.r + saturation.r, referenceLight.color.g + saturation.g, referenceLight.color.b + saturation.b, transparency);
        beam = new LightBeam(transform.position + transform.up * beamStartOffset, transform.up, beamRenderer);
    }
}
