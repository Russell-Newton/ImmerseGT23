using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltHandler : MonoBehaviour
{

    public float meltSpeedX = 0;
    public float meltSpeedY = 1;
    public float meltSpeedZ = 0;

    public List<GameObject> trapped;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        foreach (var obj in trapped)
        {
            obj.GetComponent<Collider>().enabled = false;
        }
    }

    // Update is called once per frame
    public void Melt()
    {
        transform.localScale -= new Vector3(meltSpeedX, meltSpeedY, meltSpeedZ) * Time.deltaTime;

        if (transform.localScale.x < 0 || transform.localScale.y < 0 || transform.localScale.z < 0)
        {
            Destroy(gameObject);

            foreach (var obj in trapped)
            {
                obj.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
