using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSystemScript : MonoBehaviour
{
    public MainSceneScript mScript;
    public UserInterfaceScript uiScript;
    public TrainScript tScript;
    public GameObject[] trainShopElements;
    public TrainInfo[] tInfo;
    public void OpenDepot()
    {
        uiScript.canvasMainUI.SetActive(false);
        uiScript.idMenu = 1;
        uiScript.canvasDepot.SetActive(true);
        uiScript.bgfgname.text = "Depot";
        uiScript.canvasBgFB.SetActive(true);
        mScript.isDepotOpen = true;
        uiScript.OpenDepot();
        mScript.camRig.GetComponent<CameraController>().enabled = false;
    }
    public void OpenTrainShop()
    {
        uiScript.CheckUnlockedTrains();
        uiScript.CloseMenu();
        uiScript.canvasMainUI.SetActive(false);
        uiScript.idMenu = 2;
        uiScript.canvasTrainShop.SetActive(true);
        uiScript.bgfgname.text = "Train Shop";
        uiScript.canvasBgFB.SetActive(true);
        mScript.isTrainShopOpen = true;
        uiScript.OpenTrainShop();
        mScript.camRig.GetComponent<CameraController>().enabled = false;
    }
}
