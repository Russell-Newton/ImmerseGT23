using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PreRenderFlipper : MonoBehaviour
{
    public bool toggle = true;
    public bool isLeftEye = true;

    /// <summary>
    ///  called (once per eye)
    /// </summary>
    void OnPreRender()
    {
        Shader.SetGlobalInt("RenderingEye", isLeftEye ? 1 : 0);
        if (toggle)
        {
            isLeftEye = !isLeftEye;
        }
    }
}

public class TeleporterController : MonoBehaviour
{

    public GameObject portalTarget;

    private GameObject playerController;
    private Camera rigCamera;

    private Vector3 cameraDisplacement;
    private GameObject cameraContainer;
    private GameObject leftEyeAnchor;
    private Camera leftEye;
    private GameObject rightEyeAnchor;
    private Camera rightEye;

    private Material leftMaterial;
    private Material rightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rigCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        playerController = GameObject.Find("XR Rig/PlayerController");

        cameraContainer = new GameObject("Portal Cameras");
        cameraContainer.transform.SetParent(gameObject.transform);
        cameraContainer.transform.position = portalTarget.transform.position;
        cameraDisplacement = portalTarget.transform.position - new Vector3(rigCamera.transform.position.x, 0, rigCamera.transform.position.z);

        /*
        leftEyeAnchor = new GameObject("Left Eye");
        leftEyeAnchor.transform.parent = cameraContainer.transform;
        leftEye = leftEyeAnchor.AddComponent<Camera>() as Camera;
        leftEye.projectionMatrix = rigCamera.projectionMatrix;
        rightEyeAnchor = new GameObject("Right Eye");
        rightEyeAnchor.transform.parent = cameraContainer.transform;
        rightEye = rightEyeAnchor.AddComponent<Camera>() as Camera;
        rightEye.projectionMatrix = rigCamera.projectionMatrix;

        
        leftMaterial = transform.Find("TeleporterFrame/Left").GetComponent<Renderer>().material;
        if (leftEye.targetTexture != null)
        {
            leftEye.targetTexture.Release();
        }
        leftEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        leftMaterial.SetTexture("_MainTex", leftEye.targetTexture);

        rightMaterial = transform.Find("TeleporterFrame/Right").GetComponent<Renderer>().material;
        if (rightEye.targetTexture != null)
        {
            rightEye.targetTexture.Release();
        }
        rightEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        rightMaterial.SetTexture("_MainTex", rightEye.targetTexture);

        rigCamera.gameObject.AddComponent<PreRenderFlipper>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        cameraContainer.transform.position = rigCamera.transform.position + cameraDisplacement;
        cameraContainer.transform.rotation = rigCamera.transform.rotation;

        /*
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftEye);
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightEye);

        Vector3 leftEyePosition, rightEyePosition;
        Quaternion leftEyeRotation, rightEyeRotation;

        leftDevice.TryGetFeatureValue(CommonUsages.leftEyePosition, out leftEyePosition);
        leftDevice.TryGetFeatureValue(CommonUsages.leftEyeRotation, out leftEyeRotation);
        rightDevice.TryGetFeatureValue(CommonUsages.rightEyePosition, out rightEyePosition);
        rightDevice.TryGetFeatureValue(CommonUsages.rightEyeRotation, out rightEyeRotation);

        leftEye.transform.localPosition = leftEyePosition;
        leftEye.transform.localRotation = leftEyeRotation;
        rightEye.transform.localPosition = rightEyePosition;
        rightEye.transform.localRotation = rightEyeRotation;
        */
    }

    public Transform GetTeleportTransform()
    {
        return portalTarget.transform;
    }
}
