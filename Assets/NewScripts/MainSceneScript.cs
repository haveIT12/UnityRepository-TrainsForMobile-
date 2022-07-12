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
    public PointerManager pManager;
    public List<TownRawScript> trScript;
    public List<TownRawScript> allTowns;

    public bool isGamePaused;
    public bool isTownRawOpened;
    public bool isTownRawInfoOpened;
    public bool isNewGame = true;
    public bool isBuildRailOpen;
    public bool isDepotOpen;
    public bool isTrainShopOpen;
    public bool isTrainMenuOpen;
    public bool isSelectWayOpen;
    public IEnumerator camToTargetCoroutine;
    public void Upgrade() => townRawScript.Upgrade();
    public void OpenTownRaw()
    {
        uiScript.bgfgname.text = townRawScript.name;
        uiScript.canvasMainUI.SetActive(false);
        uiScript.idMenu = 4;
        uiScript.canvasBgFB.SetActive(true);
        isTownRawOpened = true;
        uiScript.OpenTownRaw();
        camRig.GetComponent<CameraController>().enabled = false;
        townRawScript.CloseTownRawInfo();
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
        if(isZoom == true)
            camController.newZoom = zoom;
        yield return null;
    }
}
