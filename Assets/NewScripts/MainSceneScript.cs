using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSceneScript : MonoBehaviour
{
    public PlayerData pData;
    public UserInterfaceScript uiScript;
    public TownRawScript townRawScript;
    public RailRoadSystemScript rsScript;
    public GameObject town;
    public Camera cam;
    public CameraController camController;
    public GameObject camRig;

    public bool isGamePaused;
    public bool isTownRawOpened;
    public bool isTownRawInfoOpened;
    public bool isNewGame = true;
    public bool isBuildRailOpen;
    public IEnumerator camToTargetCoroutine;
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
                if (isGamePaused == false)
                {
                    if (isTownRawOpened == false)
                    {
                        if (isBuildRailOpen == false)
                        {
                            if (isTownRawInfoOpened == false)
                            {
                                if (_hit.collider.tag == "City")
                                {
                                    OpenTownRawInfo(_hit);
                                }
                                    
                            }
                            else
                            {
                                if (_hit.collider.transform.parent.tag == "City")
                                {
                                    CloseTownRawInfo();
                                    OpenTownRawInfo(_hit);
                                }
                                else
                                    CloseTownRawInfo();
                            }
                        }
                        else
                        {
                            if (isTownRawInfoOpened == true)
                                CloseTownRawInfo();
                            if (_hit.collider.transform.parent != null && _hit.collider.transform.parent.tag == "Road")
                            {
                                rsScript.CloseSelect();
                                rsScript.SelectRail(_hit);
                            }
                            else if (_hit.collider.transform.parent != null && _hit.collider.transform.parent.tag != "Road")
                                rsScript.CloseSelect();
                            else
                                rsScript.CloseSelect();
                        }
                    }
                }
                else
                { 
                
                }
            }
        }
    }
    public void Upgrade() => townRawScript.Upgrade();
    public void OpenTownRaw()
    {
        isTownRawOpened = true;
        uiScript.OpenTownRaw();
        camRig.GetComponent<CameraController>().enabled = false;
    }
    public void CloseTownRaw()
    {
        isTownRawOpened = false;
        uiScript.CloseTownRaw();
        camRig.GetComponent<CameraController>().enabled = true;
        CloseTownRawInfo();
    }
    private void OpenTownRawInfo(RaycastHit _hit)
    {
        isTownRawInfoOpened = true;

        townRawScript = _hit.collider.gameObject.GetComponent<TownRawScript>();
        uiScript.townRawScript = townRawScript;
        townRawScript.OpenTownRawInfo();
        townRawScript.gameObject.tag = "CurrentCity";

        camToTargetCoroutine = CamToTarget(townRawScript.toCam, true, 5f);
        StartCoroutine(camToTargetCoroutine);
    }
    private void CloseTownRawInfo()
    {
        isTownRawInfoOpened = false;

        townRawScript.gameObject.tag = "City";
        townRawScript.CloseTownRawInfo();

        StopCoroutine(camToTargetCoroutine);
    }
    public IEnumerator CamToTarget(GameObject target, bool isZoom, float zoom)
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 gotopos = new Vector3(target.transform.position.x, camRig.transform.position.y, target.transform.position.z);

        while (elapsedTime < waitTime)
        {
            if (elapsedTime >= 0.2f)
            {
                if (camController.touchZero.phase == TouchPhase.Moved)
                {
                    StopCoroutine(camToTargetCoroutine);
                    yield return null;
                }
            }
            if (isZoom == true)
            {
                camController.newZoom = Mathf.Lerp(camController.newZoom, zoom, (elapsedTime / waitTime));
            }
            camController.newPosition = Vector3.Lerp(camController.newPosition, gotopos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        camController.newPosition = gotopos;
        camController.newZoom = zoom;
        yield return null;
    }
}
