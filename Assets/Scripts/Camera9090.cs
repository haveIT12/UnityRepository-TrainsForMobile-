using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera9090 : MonoBehaviour
{
    public Camera camer;
    private Transform cameraTransform;
    private Vector3 newPosition;
    private float newZoom;
    private bool isDragging = false;
    private Vector3 lastPos;
    private Touch touchZero;
    private Touch touchOne;
    public Vector3 direction;

    [Header("LimitCameraBounds")]
    public float leftLimit;
    public float rightLimit;
    public float forwardLimit;
    public float backLimit;
    [Range(0.05f, 5f)]
    public float moveTime;

    [Space]
    private Vector3 startDrag;
    private Vector3 targetPosition;
    [Header("ZoomSettings")]
    public float zoomMin = 7;
    public float zoomMax = 14;
    public bool isZoom = false;
    [Range(0.05f, 5f)]
    public float zoomTime;
    [Range(0.0017f, /*0.0*/100f)]
    public float zoomSensivity;

    private void Awake()
    {
        newZoom = camer.orthographicSize;
        newPosition = gameObject.transform.position;
        cameraTransform = this.GetComponentInChildren<Camera>().transform;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            
            touchZero = Input.GetTouch(0);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = camer.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                switch (touchZero.phase)
                {
                    case TouchPhase.Began:
                        isDragging = true;
                        startDrag = ray.GetPoint(distance);
                        break;
                    case TouchPhase.Moved:
                        newPosition += startDrag - ray.GetPoint(distance);
                        direction = startDrag - ray.GetPoint(distance);
                        gameObject.transform.position += direction;
                        break;
                    case TouchPhase.Ended:
                        isDragging = false;
                        break;
                }
            }
            if (Input.touchCount == 2)
            {
                touchOne = Input.GetTouch(1);
                switch (touchOne.phase)
                {
                    case TouchPhase.Began:
                        isDragging = false;
                        break;
                    case TouchPhase.Moved:
                        Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
                        Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

                        float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
                        float currentDistTouch = (touchZero.position - touchOne.position).magnitude;
                        float difference = currentDistTouch - distTouch;
                        zoom(difference * zoomSensivity);
                        break;

                    case TouchPhase.Ended:
                        isDragging = false;
                        //StartCoroutine("CourotineSample");
                        break;
                }
            }
        }
        if (isDragging == false)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(newPosition.x * 1.3f, newPosition.y, newPosition.z * 1.3f), moveTime * Time.deltaTime);
            newPosition = new Vector3(
            Mathf.Clamp(newPosition.x, leftLimit, rightLimit),
            15,
            Mathf.Clamp(newPosition.z, backLimit, forwardLimit));
        }
    camer.orthographicSize = Mathf.Lerp(camer.orthographicSize, newZoom, zoomTime);
        /*if (isDragging == false)
        {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position -= direction, moveTime * Time.deltaTime);

        gameObject.transform.position = new Vector3(
        Mathf.Clamp(gameObject.transform.position.x, leftLimit, rightLimit),
        15,
        Mathf.Clamp(gameObject.transform.position.z, backLimit, forwardLimit));
        }*/
    }
    private void zoom(float increment)
    {
            newZoom = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
            //StartCoroutine("CourotineSample");
    }
    private IEnumerator CourotineSample()
    {
        isZoom = true;
        yield return new WaitForSeconds(0.3f);
        isZoom = false;
    }
}
