using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuryCameraController : MonoBehaviour {
    public GameObject canvasCamera, cameraObj;

    public void ActiveCamera(bool value)
    {
        canvasCamera.SetActive(value);
        cameraObj.SetActive(value);
    }
}
