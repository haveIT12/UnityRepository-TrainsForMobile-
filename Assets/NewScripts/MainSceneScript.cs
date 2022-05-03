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
    public void Start()
    {
    }
    void Update()
    {
    }
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
                            {
                                townScript = _hit.collider.gameObject.GetComponent<TownScript>();
                                uiScript.OpenTownRawInfo();
                                isTownRawInfoOpened = true;
                                camToTargetCoroutine = CamToTarget(townScript.gameObject);
                                StartCoroutine(camToTargetCoroutine);
                            }
                        }
                        else
                        {
                            if (_hit.collider.tag != "City")
                            {
                                uiScript.CloseTownRawInfo();
                                isTownRawInfoOpened = false;
                                StopCoroutine(camToTargetCoroutine);
                            }
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
    IEnumerator CamToTarget(GameObject target)
    {
        float elapsedTime = 0;
        float waitTime = 2f;
        Vector3 gotopos = new Vector3(target.transform.position.x - lookX, camController.newPosition.y, target.gameObject.transform.position.z - lookZ);
        Debug.Log(target.transform.position);
        while (elapsedTime < waitTime)
        {
            camController.newPosition = Vector3.Lerp(camController.newPosition, gotopos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        /*for (float t = 0.01f; t < waitTime; t += 0.01f)
        {
            yield return null;
        }*/
        //camController.newPosition = gotopos;
        yield return null;
    }
}
