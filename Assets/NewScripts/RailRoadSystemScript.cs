using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRoadSystemScript : MonoBehaviour
{
    public GameObject[] road;
    public RailRoadScript roadSelected;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public void BuyRail()
    {
        mainScript.pData.ChangeMoney(this.gameObject, -roadSelected.price);
        roadSelected.isRailBuild = true;
        roadSelected.gameObject.GetComponent<MeshRenderer>().material = roadSelected.mat[0];
        uiScript.buyRail.SetActive(false);
        roadSelected = null;
    }
    public void OpenBuild()
    {
        if (mainScript.isTownRawInfoOpened == true)
            mainScript.townRawScript.CloseTownRawInfo();
        uiScript.canvasMainUI.SetActive(false);
        mainScript.isBuildRailOpen = true;
        for (int i = 0; i < road.Length; i++)
        {
            if (road[i].GetComponent<RailRoadScript>().isRailBuild == false)
                road[i].GetComponent<RailRoadScript>().Spawn(1);
        }
        uiScript.canvasBuildRail.SetActive(true);
        uiScript.buyRail.SetActive(false);
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(gameObject, true, 15f);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
    }
    public void CloseBuild()
    {
        uiScript.canvasMainUI.SetActive(true);
        mainScript.isBuildRailOpen = false;
        for (int i = 0; i < road.Length; i++)
        {
            if (road[i].GetComponent<RailRoadScript>().isRailBuild == false)
                road[i].GetComponent<RailRoadScript>().Hide();
        }
        if (roadSelected != null)
            roadSelected.CloseSelect();
        uiScript.canvasBuildRail.SetActive(false);
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
    }
}
