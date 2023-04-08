using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class XRCameraPoseCopy : MonoBehaviour
{

    [Tooltip("XR Rig prefab to search for in the scene")]
    public GameObject rigPrefab;

    public Vector3 cameraTranslation;

    private Camera cameraToCopy;
    private Camera cameraToCopyTo;

    // Start is called before the first frame update
    void Start()
    {
        var rigToCopy = GameObject.Find("XR Rig");
        cameraToCopy = rigToCopy.GetComponentInChildren<Camera>();
        cameraToCopyTo = this.GetComponentInParent<Camera>();
        Debug.Log(cameraToCopy);
    }

    // Update is called once per frame
    void Update()
    {
        cameraToCopyTo.transform.rotation = Quaternion.Euler(cameraToCopy.transform.eulerAngles.x, cameraToCopy.transform.eulerAngles.y, 0);
        cameraToCopyTo.transform.position = cameraToCopy.transform.position + cameraTranslation;
    }
}
