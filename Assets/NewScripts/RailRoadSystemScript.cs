using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRoadSystemScript : MonoBehaviour
{
    public GameObject[] road;
    public RailRoadScript roadSelected;
    public MainSceneScript mScript;
    public UserInterfaceScript uScript;
    public GameObject toCam;
    void Start()
    {

    }
    void Update()
    {

    }
    public void BuyRail()
    {
        mScript.pData.ChangeMoney(this.gameObject, -roadSelected.price);
        roadSelected.isRailBuild = true;
        roadSelected.CloseSelect("BuildedRoad", 0);
        uScript.buyRail.SetActive(false);
        roadSelected = null;
    }
    public void OpenBuild()
    {
        mScript.isBuildRailOpen = true;
        for (int i = 0; i < road.Length; i++)
        {
            if (road[i].GetComponent<RailRoadScript>().isRailBuild == false)
                road[i].GetComponent<RailRoadScript>().Spawn(1);
        }
        uScript.canvasBuildRail.SetActive(true);
        uScript.buyRail.SetActive(false);
        mScript.camToTargetCoroutine = mScript.CamToTarget(toCam, true, 15f);
        mScript.StartCoroutine(mScript.camToTargetCoroutine);
    }
    public void CloseBuild()
    {
        mScript.isBuildRailOpen = false;
        for (int i = 0; i < road.Length; i++)
        {
            if (road[i].GetComponent<RailRoadScript>().isRailBuild == false)
                road[i].GetComponent<RailRoadScript>().Hide();
        }
        uScript.canvasBuildRail.SetActive(false);
    }
    public void SelectRail(RaycastHit _hit)
    {
        roadSelected = _hit.collider.gameObject.GetComponentInParent<RailRoadScript>();
        if(roadSelected.isRailBuild == false)
        {
            roadSelected.RoadSelect();
            mScript.camToTargetCoroutine = mScript.CamToTarget(roadSelected.toCam, true, 15f);
            mScript.StartCoroutine(mScript.camToTargetCoroutine);
            uScript.buyRail.SetActive(true);
            uScript.priceRoadText.text = roadSelected.price.ToString();
        }
    }
    public void CloseSelect()
    {
        if (roadSelected != null)
        { 
            roadSelected.CloseSelect("Road", 1);
            uScript.buyRail.SetActive(false);
        }

    }
}
