using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterCameraSetup : MonoBehaviour
{
    private Camera teleporterCamera;
    private Material teleporterMaterial;
    // Start is called before the first frame update
    void Start()
    {
        teleporterCamera = transform.parent.Find("TeleporterCamera").GetComponentInParent<Camera>();
        teleporterMaterial = GetComponent<Renderer>().material;

        if (teleporterCamera.targetTexture != null)
        {
            teleporterCamera.targetTexture.Release();
        }
        teleporterCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        teleporterMaterial.mainTexture = teleporterCamera.targetTexture;


        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.gameObject);
            other.enabled = false;
            var playerController = other.gameObject;
            var offset = playerController.GetComponent<BNG.BNGPlayerController>().CameraRig.localPosition.y;
            playerController.transform.position = teleporterCamera.transform.position - new Vector3(0, offset, 0);
            other.enabled = true;
        }
    }
}
