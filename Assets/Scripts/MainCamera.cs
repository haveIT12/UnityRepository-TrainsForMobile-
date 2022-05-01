using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class MainCamera : MonoBehaviour
{
    Vector3 touch;
    public float zoomMin = 7;
    public float zoomMax = 14;
    public Camera camer;
    public GameObject cameraTarget;
    public CinemachineVirtualCamera vCam;
    public MainScript mScript;
    private bool isZoom = false;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float forwardLimit;
    [SerializeField]
    float backLimit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                touch = camer.ScreenToWorldPoint(Input.mousePosition);
                mScript.RaycastGo();
        }
        if (Input.GetMouseButton(0))
        {
            if (mScript.isCityOpen == false & mScript.isGamePaused == false)
            {
                if (Input.touchCount == 2)
                {
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

                    float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
                    float currentDistTouch = (touchZero.position - touchOne.position).magnitude;
                    float difference = currentDistTouch - distTouch;
                    zoom(difference * 0.017f);
                }
                if (isZoom == false)
                {
                    Vector3 direction = touch - camer.ScreenToWorldPoint(Input.mousePosition);

                    cameraTarget.transform.position += direction;
                    //ограничение
                    cameraTarget.transform.position = new Vector3(
                    Mathf.Clamp(cameraTarget.transform.position.x, leftLimit, rightLimit),
                    0,
                    Mathf.Clamp(cameraTarget.transform.position.z, backLimit, forwardLimit));
                }
            }
        }
    }
    private void zoom(float increment)
    {
        vCam.m_Lens.OrthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
        StartCoroutine(CourotineSample());
    }
    private IEnumerator CourotineSample()
    {
        isZoom = true;
        yield return new WaitForSeconds(0.3f);
        isZoom = false;
    }
}
