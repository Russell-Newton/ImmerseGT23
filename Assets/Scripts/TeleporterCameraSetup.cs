using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TeleporterCameraSetup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.enabled = false;
            var playerController = other.gameObject;
            var offset = playerController.GetComponent<BNG.BNGPlayerController>().CameraRig.localPosition.y;
            playerController.transform.position = transform.parent.GetComponent<TeleporterController>().GetTeleportTransform().position;
            playerController.transform.rotation = Quaternion.Euler(0, transform.parent.GetComponent<TeleporterController>().GetTeleportTransform().rotation.eulerAngles.y, 0);
            other.enabled = true;
        }
    }
}
