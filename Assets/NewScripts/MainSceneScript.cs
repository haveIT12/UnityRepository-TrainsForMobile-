using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSceneScript : MonoBehaviour
{
    public UserInterfaceScript uiScript;
    public TownScript townScript;
    public GameObject town;
    public Camera cam;
    public CameraController camController;
    public float lookX;
    public float lookZ;
    public bool isGamePaused;
    public bool isTownOpened;
    public bool isTownRawInfoOpened;
    private IEnumerator camToTargetCoroutine;
    public void RaycastGo()
    {
        Ray ray = cam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit))
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
            { 
                return;
            }
            else
            {
                Debug.Log(_hit.collider.tag);
                if (isGamePaused == false)
                {
                    if (isTownOpened == false)
                    {
                        if (isTownRawInfoOpened == false)
                        {
                            if (_hit.collider.tag == "City")
                                OpenTownRawInfo(_hit);
                        }
                        else
                        {
                            if (_hit.collider.tag == "City")
                            {
                                CloseTownRawInfo();
                                OpenTownRawInfo(_hit);
                            }
                            else
                                CloseTownRawInfo();
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
    private void OpenTownRawInfo(RaycastHit _hit)
    {
        isTownRawInfoOpened = true;

        townScript = _hit.collider.gameObject.GetComponent<TownScript>();
        uiScript.OpenTownRawInfo();
        townScript.gameObject.tag = "CurrentCity";

        camToTargetCoroutine = CamToTarget(townScript.gameObject);
        StartCoroutine(camToTargetCoroutine);
    }
    private void CloseTownRawInfo()
    {
        isTownRawInfoOpened = false;

        townScript.gameObject.tag = "City";
        uiScript.CloseTownRawInfo();

        StopCoroutine(camToTargetCoroutine);
    }
    IEnumerator CamToTarget(GameObject target)
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 gotopos = new Vector3(target.transform.position.x - lookX, camController.newPosition.y, target.gameObject.transform.position.z - lookZ);

        while (elapsedTime < waitTime)
        {
            if (elapsedTime >= 0.2f)
            {
                if (camController.touchZero.phase == TouchPhase.Moved)
                    StopCoroutine(camToTargetCoroutine);
            }

            camController.newPosition = Vector3.Lerp(camController.newPosition, gotopos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        camController.newPosition = gotopos;
        yield return null;
    }
}
