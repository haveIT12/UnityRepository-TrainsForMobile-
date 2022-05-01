using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject[] ui;
    public Button[] btn;
    public Image[] bar;
    public MainScript mScript;
    public RailwaySystem rSystem;
    public TextMeshProUGUI mcoins;
    public TextMeshProUGUI diamondsText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI buyPrice;
    public TextMeshProUGUI upgradeBusinessCost;
    public Vector3[] posCityButton;

    public void TrainsWagonsRailroad()
    {
        ui[0].SetActive(false);
        ui[1].SetActive(true);
    }
    public void CityStats()
    {
        ui[0].SetActive(true);
        ui[1].SetActive(false);
        ui[4].SetActive(true);
    }
    public void OpenBuild()
    {
        mScript.uiS.CloseButton();
        mScript.isBuildRoad = true;
        ui[0].SetActive(false);
        ui[5].SetActive(false);
        ui[6].SetActive(false);
        ui[3].SetActive(true);
        ui[8].SetActive(true);
        ui[8].gameObject.GetComponent<Animator>().enabled = true;
        rSystem.OpenBuild();
    }
    public void CloseBuild()
    {
        mScript.isBuildRoad = false;
        ui[2].SetActive(false);
        ui[3].SetActive(false);
        ui[5].SetActive(true);
        ui[6].SetActive(true);
        ui[8].SetActive(false);
        ui[8].gameObject.GetComponent<Animator>().enabled = false;
        rSystem.CloseBuild();
    }
    public void CloseCity()
    {
        mScript.isCityOpen = false;
        ui[0].SetActive(false);
        ui[5].SetActive(true);
        ui[6].SetActive(true);
    }
    public void OpenCity()
    {
        mScript.cScript.OpenCity();
        mScript.isCityOpen = true;
        ui[0].SetActive(true);
        ui[5].SetActive(false);
        ui[6].SetActive(false);
    }
    public void CloseButton()
    {
        mScript.cScript.gameObject.tag = "City";
        mScript.isButtonOpen = false;
        mScript.cScript.ui[5].SetActive(false);

    }
}
