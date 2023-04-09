using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ButtonTest : MonoBehaviour
{ 
    private bool collided = false;
    private void OnCollisionEnter(Collision collision)
    {
        collided = true; 
        Debug.Log("onCollisionEnter: " + collision.ToString() + " " + collided);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        /*if (OVRInput.Get(OVRInput.Button.One)){
            Debug.Log("A button pressed");
        }*/
    }
}