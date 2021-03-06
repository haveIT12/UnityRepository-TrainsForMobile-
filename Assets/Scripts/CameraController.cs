using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraTransform;
    public Camera cam;

    [Space]

    [Header("Main Script")]
    public MainScript mScript;

    [Space]

    [Header("LimitCameraBounds")]
    public float leftLimit;
    public float rightLimit;
    public float forwardLimit;
    public float backLimit;
    [Space]
    [Header("CameraSettings")]
    public float zoomTime;
    public float movementTime;
    public float zoomMin;
    public float zoomMax;
    public float newZoom;
    public float zoomSensivity;

    private bool multiTouch;

    private Touch touchZero;
    private Touch touchOne;

    private Vector3 avgPosition;
    private Vector3 newPosition;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    void Start()
    {
        newPosition = transform.position;
        newZoom = cam.orthographicSize;
    }

    void LateUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            multiTouch = false;
            //mScript.RaycastGo();
        }
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1 && multiTouch == false)
            {
                touchZero = Input.GetTouch(0);
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = cam.ScreenPointToRay(touchZero.position);
                float entry;
                if (plane.Raycast(ray, out entry))
                {
                    switch (touchZero.phase)
                    {
                        case TouchPhase.Began:
                            dragStartPosition = ray.GetPoint(entry);
                            break;
                        case TouchPhase.Moved:
                            dragCurrentPosition = ray.GetPoint(entry);
                            newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                            break;
                        case TouchPhase.Ended:
                            break;
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                multiTouch = true;
                touchZero = Input.GetTouch(0);
                touchOne = Input.GetTouch(1);
                avgPosition = (touchOne.position + touchZero.position)/2;
                Plane planee = new Plane(Vector3.up, Vector3.zero);
                Ray rayy = cam.ScreenPointToRay(avgPosition);
                float entryy;
                if (planee.Raycast(rayy, out entryy))
                {
                    switch (touchOne.phase)
                    {
                        case TouchPhase.Began:
                            dragStartPosition = rayy.GetPoint(entryy);
                            break;
                        case TouchPhase.Moved:
                            dragCurrentPosition = rayy.GetPoint(entryy);
                            newPosition = transform.position + dragStartPosition - dragCurrentPosition;

                            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
                            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

                            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
                            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;
                            float difference = currentDistTouch - distTouch;
                            zoom(difference * zoomSensivity);
                            break;
                    }
                }
            }
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        transform.position.y,
        Mathf.Clamp(transform.position.z, backLimit, forwardLimit)); ;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * zoomTime);
    }
    private void zoom(float increment)
    {
        newZoom = Mathf.Clamp(cam.orthographicSize - increment, zoomMin, zoomMax);
    }

}
