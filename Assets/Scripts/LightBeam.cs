using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam
{

    public GameObject beamObj;
    TubeRenderer beam;
    List<Vector3> bounceIndices = new List<Vector3>();

    public LightBeam(Vector3 position, Vector3 direction, TubeRenderer beamRenderer)
    {
        //this.beam = new TubeRenderer();
        this.beamObj = new GameObject();
        this.beamObj.name = "Light Beam";
        this.beam = beamRenderer;
        /*this.beam._radiusOne = startWidth;
        this.beam.endWidth = endWidth;
        this.beam.startColor = startColor;
        this.beam.endColor = endColor;*/

        CastRay(position, direction);
    }

    void CastRay(Vector3 position, Vector3 direction)
    {
        bounceIndices.Add(position);

        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        bool foundHit = Physics.Raycast(ray, out hit, 50, 1);

        if (foundHit)
        {
            if (hit.collider.gameObject.tag == "Reflector")
            {
                Vector3 pos = hit.point;
                Vector3 dir = Vector3.Reflect(direction, hit.normal);
                CastRay(pos, dir);
            }
            else
            {
                bounceIndices.Add(hit.point);
            }

            if (hit.collider.gameObject.tag == "Meltable")
            {
                hit.collider.gameObject.GetComponent<MeltHandler>().Melt();
            }
        }
        else
        {
            bounceIndices.Add(ray.GetPoint(50));
        }
        UpdateBeam();
    }

    void UpdateBeam()
    {
        beam.SetPositions(bounceIndices.ToArray());
    }
}
