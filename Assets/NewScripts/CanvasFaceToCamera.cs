using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFaceToCamera : MonoBehaviour
{
    public GameObject cam;
    private void Start()
    {
        cam = GameObject.Find("Camera");
    }
    private void Update()
    {
        transform.forward = cam.transform.forward;
    }
}
