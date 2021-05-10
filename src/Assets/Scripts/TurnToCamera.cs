using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera ArCam;

    void Start() {
        ArCam = Camera.main;
    }
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + ArCam.transform.rotation * Vector3.forward,
        ArCam.transform.rotation * Vector3.up);
    }
}
