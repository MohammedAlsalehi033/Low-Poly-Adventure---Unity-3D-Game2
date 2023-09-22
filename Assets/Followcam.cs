using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
    public Camera mainCam;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + mainCam.transform.forward);
    }
}
