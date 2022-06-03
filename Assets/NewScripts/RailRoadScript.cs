using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RailRoadScript : MonoBehaviour
{
    public RailRoadSystemScript rsScript;
    public MainSceneScript mainScript;
    public Material[] mat; // 0 - normal material, 1 - neutral material 2- selected material;
    public bool isRailBuild;
    public bool isRailSelected;
    public int trainsCountOnRail;
    public int trainsCountOnRailMax;
    private Transform[] childCollider;

    public string path;
    public float price;
    private void Update()
    {
        if (mainScript.isBuildRailOpen == true)
        {
            if (isRailSelected == true)
            {
                if (isRailBuild == false)
                { 
                    if (Input.GetMouseButtonDown(0))
                    { 
                        Ray ray = mainScript.cam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                        RaycastHit _hit;
                        if (Physics.Raycast(ray, out _hit))
                        {
                            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                            {
                                return;
                            }
                            if (_hit.collider.gameObject.transform.parent.name != this.gameObject.name)
                            {
                                CloseSelect();
                            }
                        }
                    }
                }
            }
        }
    }
    public void Spawn(int colorNumber)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material = mat[colorNumber];
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void RoadSelect()
    {
        Debug.Log("RoadSelect");
        isRailSelected = true;
        rsScript.roadSelected = this;
        gameObject.GetComponent<MeshRenderer>().material = mat[2];
        mainScript.uiScript.buyRail.SetActive(true);
        mainScript.uiScript.priceRoadText.text = FormatNumsHelper.FormatNum(price);
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(gameObject, true, 15f);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
    }
    public void CloseSelect()
    {
        Debug.Log("CloseSelect");
        int matNub;
        if (isRailBuild == true)
            matNub = 0;
        else
            matNub = 1;
        isRailSelected = false;
        gameObject.GetComponent<MeshRenderer>().material = mat[matNub];
        rsScript.CheckIsAnySelected();
    }
}
