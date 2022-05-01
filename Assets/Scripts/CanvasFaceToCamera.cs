using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFaceToCamera : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        transform.forward = cam.transform.forward;
    }
}
