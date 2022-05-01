using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainScript : MonoBehaviour
{
    public RailwaySystem rS;
    private GameObject mCamera;
    public CityScript cScript;
    public UIScript uiS;
    public Road road;
    public int roadNumber;
    public ButtonBuildRoad btnBR;
    private Animator mcAnimator;
    public int CityNumber;

    private GameObject trainClone;
    public bool isGamePaused;
    public bool isCityOpen = false;
    public bool isButtonOpen = false;
    public bool isBuildRoad = false;
    public bool isRoadSelect = false;
    public float coins;
    public float diamonds;
    private void Start()
    {
        mcAnimator = uiS.mcoins.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        uiS.coinsText.text = FormatNumsHelper.FormatNum(coins);
        uiS.diamondsText.text = FormatNumsHelper.FormatNum(diamonds);
    }
    public void RaycastGo()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit))
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return;
            else
            {
                if (isGamePaused == false)
                {
                    if (isCityOpen == false)
                    {
                        if (isBuildRoad == false)
                        {
                            if (isButtonOpen == false)
                            {
                                if (_hit.collider.tag == "City")
                                {
                                    cScript = _hit.collider.gameObject.GetComponent<CityScript>();
                                    CityNumber = cScript.CityNumber;
                                    cScript.OpenButton();
                                }
                            }
                            else
                                //if (_hit.collider.tag != "CurrentCity")
                                uiS.CloseButton();
                        }
                        else
                        {
                            if (rS.isMoveToRail == false)
                            {
                                if (_hit.collider.tag == "CurrentRoad" || _hit.collider.tag == "Road")
                                {
                                    if (isRoadSelect == false)
                                    {
                                        Debug.Log("115");
                                        isRoadSelect = true;
                                        road = _hit.collider.gameObject.GetComponent<Road>();
                                        SelectRoad();
                                        uiS.buyPrice.text = FormatNumsHelper.FormatNum(road.price) + " $";
                                        uiS.ui[2].SetActive(true);

                                    }
                                    else

                                    {
                                        Debug.Log("else");
                                        if (_hit.collider.tag == "Road")
                                        {
                                            if (road.gameObject.tag != "BuildedRoad")
                                            {
                                                isRoadSelect = false;
                                                SelectCansel();
                                            }
                                            isRoadSelect = true;
                                            road = _hit.collider.gameObject.GetComponent<Road>();
                                            SelectRoad();
                                            uiS.buyPrice.text = FormatNumsHelper.FormatNum(road.price) + " $";
                                            uiS.ui[2].SetActive(true);
                                        }
                                        else if (_hit.collider.tag != "BuildedRoad")
                                        {
                                            isRoadSelect = false;
                                            SelectCansel();
                                            uiS.ui[2].SetActive(false);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                rS.isMoveToRail = false;
                                isRoadSelect = false;
                                SelectCansel();
                                uiS.ui[2].SetActive(false);
                            }
                                

                        }
                    }
                }
            }
        }
    }
    public void BuyRoad()
    {
        if (road.price <= coins)
        {
            coins -= road.price;
            road.rend.material = road.mat[2];
            roadNumber = road.roadNumber;
            //cScript.road[roadNumber] = cScript.empty[roadNumber];
            road.gameObject.tag = "BuildedRoad";
            cScript.ui[2].SetActive(false);
        }
        else
        {
            Debug.Log("You have not money!");
            isRoadSelect = false;
            SelectCansel();
            cScript.ui[2].SetActive(false);
        }


    }
    public void MinusCoinsPlay()
    {
        mcAnimator.enabled = false;
        StartCoroutine("MinusCoins");
        mcAnimator.enabled = true;
    }
    IEnumerator MinusCoins()
    {
        uiS.ui[10].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        uiS.ui[10].SetActive(false);
    }
    public void UpgradeBusiness() => cScript.UpgradeBusiness();
    public void SelectRoad() => road.SelectRoad();
    public void SelectCansel() => road.SelectCansel();
    public void OpenButton() => cScript.OpenButton();
    public void CloseButton() => uiS.CloseButton();
    //public void OpenBuild() => cScript.OpenBuild();
    //public void CloseBuild() => cScript.CloseBuild();
}
