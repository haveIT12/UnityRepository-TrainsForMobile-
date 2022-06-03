using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{
    public MainSceneScript mainScript;
    public TownRawScript townRawScript;
    public RailRoadSystemScript rsScript;
    public TrainSystemScript tsScript;
    public int idMenu; // 1-Depot; 2-TrainShop; 3-TrainMenu; 4-TownRaw;
    [Header("MainUI")]
    public GameObject canvasMainUI;
    public GameObject btnBuildRail;
    public TextMeshProUGUI moneyui;
    public TextMeshProUGUI ticketsui;
    [Space]
    [Header("BGFB")]
    public GameObject canvasBgFB;
    public TextMeshProUGUI bgfbmoney;
    public TextMeshProUGUI bgfbtickets;
    public TextMeshProUGUI bgfgname;
    [Space]
    [Header("TownUI")]
    public GameObject canvasTown;
    public TextMeshProUGUI townNameText;
    public TextMeshProUGUI businessNameText;
    public TextMeshProUGUI rawToProductText;
    public TextMeshProUGUI productFromRawText;
    public TextMeshProUGUI newRawToProductText;
    public TextMeshProUGUI newProductFromRawText;
    public TextMeshProUGUI productCountText;
    public TextMeshProUGUI rawCountText;
    public TextMeshProUGUI upgradeCostText;

    public Image publicBussinessSprite;
    public Image publicRawSprite;
    public Image publicBussinessSprite1;
    public Image publicRawSprite1;
    public Image publicBussinessSprite2;
    public Image publicRawSprite2;
    public Image productFullBar;
    public Image rawFullBar;
    public Image rawToProductFullBar;
    public Button upgradeButton;
    [Space]
    [Header("RawUI")]
    public GameObject canvasRaw;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeRawText;
    public TextMeshProUGUI rawCountFirstText;
    public Image rawSpriteImage;
    public Image RawSprite;
    public Image rawFullBarZero;
    public Image rawFullBarFirst;
    public Image rawFullBarSecond;
    public Image rawFullBarThird;
    public Image rawToRawFullBar;
    [Space]
    [Header("BuildRailUI")]
    public GameObject canvasBuildRail;
    public GameObject cancelBuild;
    public GameObject buyRail;
    public Text priceRoadText;
    [Space]
    [Header("Depot")]
    public GameObject canvasDepot;
    public Image trainDepotImage;
    public TextMeshProUGUI nameTrainDepot;
    public TextMeshProUGUI speedTrainDepot;
    public Button selectTrainDepot;
    public Image firstWagonDepot;
    public Image secondWagonDepot;
    public Image thirdWagonDepot;
    public Image fourthWagonDepot;
    public GameObject[] trainListDepot;
    [Space]
    [Header("TrainShop")]
    public GameObject canvasTrainShop;
    public TextMeshProUGUI[] priceTrain;
    public GameObject[] maskTrainShop;

    void Update()
    {
        if(canvasBgFB.activeSelf)
            UpdateBGFB();
        else
        {
            moneyui.text = FormatNumsHelper.FormatNum(mainScript.pData.money);
            ticketsui.text = FormatNumsHelper.FormatNum(mainScript.pData.tickets);
        }
        if (mainScript.isTownRawOpened == true)
        {
            if (townRawScript.isTown == true)
                UpdateInfoTown();
            else
                UpdateInfoRaw();

        }
        else if (mainScript.isBuildRailOpen == true)
        {
            if (rsScript.roadSelected != null)
            {
                if (mainScript.pData.money >= rsScript.roadSelected.price)
                {
                    buyRail.GetComponent<Button>().interactable = true;
                }
                else
                    buyRail.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void UpdateBGFB()
    {
        bgfbmoney.text = FormatNumsHelper.FormatNum(mainScript.pData.money);
        bgfbtickets.text = FormatNumsHelper.FormatNum(mainScript.pData.tickets);
    }
    public void OpenTrainShop()
    { 
    
    }
    public void OpenDepot()
    {
        if (tsScript.tScript != null)
        {
            trainDepotImage.gameObject.SetActive(true);
            nameTrainDepot.gameObject.SetActive(true);
            speedTrainDepot.gameObject.SetActive(true);
            //selectTrainDepot
            firstWagonDepot.gameObject.SetActive(true);
            secondWagonDepot.gameObject.SetActive(true);
            thirdWagonDepot.gameObject.SetActive(true);
            fourthWagonDepot.gameObject.SetActive(true);

            trainDepotImage.sprite = tsScript.tScript.trainSprite;
            nameTrainDepot.text = tsScript.tScript.trainName;
            speedTrainDepot.text = tsScript.tScript.maxSpeed.ToString();
            //selectTrainDepot
            firstWagonDepot.sprite = tsScript.tScript.firstWagonDepot;
            secondWagonDepot.sprite = tsScript.tScript.secondWagonDepot;
            thirdWagonDepot.sprite = tsScript.tScript.thirdWagonDepot;
            fourthWagonDepot.sprite = tsScript.tScript.fourthWagonDepot;
            //trainListDepot
        }
        else
        {
            selectTrainDepot.interactable = false;
            trainDepotImage.gameObject.SetActive(false);
            nameTrainDepot.gameObject.SetActive(false);
            speedTrainDepot.gameObject.SetActive(false);
            //selectTrainDepot
            firstWagonDepot.gameObject.SetActive(false);
            secondWagonDepot.gameObject.SetActive(false);
            thirdWagonDepot.gameObject.SetActive(false);
            fourthWagonDepot.gameObject.SetActive(false);
            //trainListDepot
        }
        if (trainListDepot.Length == 0)
        { 
            
        }
        
    }
    public void UpdateInfoDepot()
    {

    }
    public void UpdateInfoTrainShop()
    {

    }
    public void UpdateInfoTown()
    {
        productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
        rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        productFullBar.fillAmount = mainScript.townRawScript.productCount / mainScript.townRawScript.maxStorageProduct;
        rawFullBar.fillAmount = mainScript.townRawScript.rawCount / mainScript.townRawScript.maxStorageRaw;
        rawToProductFullBar.fillAmount = townRawScript.timeCurrent / townRawScript.timeForProduct;
        if (townRawScript.upgradeLvl > 3)
        {
            upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
            upgradeButton.interactable = false;
        }
        else if (mainScript.pData.money < townRawScript.upgradeCost[townRawScript.upgradeLvl])
        {
            upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.GetComponent<Image>().color = new Color(255, 255, 255);
            upgradeButton.interactable = true;
        }
    }
    public void UpdateInfoRaw()
    {
        rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        rawFullBarFirst.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
        rawFullBarZero.fillAmount = townRawScript.timeCurrent / townRawScript.timeForProduct;
    }
    public void OpenTownRaw()
    {
        if (townRawScript.isTown == true)
        {
            canvasTown.SetActive(true);
            townNameText.text = townRawScript.townName;
            businessNameText.text = townRawScript.businessName;
            publicBussinessSprite.sprite = townRawScript.businessSprite;
            publicBussinessSprite1.sprite = townRawScript.businessSprite;
            publicBussinessSprite2.sprite = townRawScript.businessSprite;
            publicRawSprite.sprite = townRawScript.rawSprite;
            publicRawSprite1.sprite = townRawScript.rawSprite;
            publicRawSprite2.sprite = townRawScript.rawSprite;
            rawToProductText.text = FormatNumsHelper.FormatNum(townRawScript.rawToProduct);
            productFromRawText.text = FormatNumsHelper.FormatNum(townRawScript.productFromRaw);
            productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
            rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
            productFullBar.fillAmount = townRawScript.productCount / townRawScript.maxStorageProduct;
            rawFullBar.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
            if (townRawScript.upgradeLvl < 4)
            {
                upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeButton.interactable = false;
                upgradeCostText.text = FormatNumsHelper.FormatNum(townRawScript.upgradeCost[townRawScript.upgradeLvl]) + "$";
                newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.newRawToProduct[townRawScript.upgradeLvl + 1]));
                newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.newProductFromRaw[townRawScript.upgradeLvl + 1]));
            }
            else
            {
                newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.newRawToProduct[townRawScript.upgradeLvl]));
                newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.newProductFromRaw[townRawScript.upgradeLvl]));
                upgradeCostText.text = "MaxLvl";
                upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeButton.interactable = false;
            }
        }
        else
        {
            canvasRaw.SetActive(true);
            townRawScript.rawCount.ToString();
            nameText.text = townRawScript.townName;
            typeRawText.text = townRawScript.rawName;
            rawFullBarFirst.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
            RawSprite.sprite = townRawScript.rawSprite;
            rawSpriteImage.sprite = townRawScript.rawSpriteImage;
            rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        }
    }
    public void CheckUnlockedTrains()
    {
        Debug.Log("CheckUnlockedTrains");
        for (int i = 0; i < mainScript.pData.trainUnlocked.Length; i++)
        {
            if (mainScript.pData.trainUnlocked[i] == true)
            {
                maskTrainShop[i].SetActive(false);
                priceTrain[i].text = FormatNumsHelper.FormatNum(tsScript.tInfo[i].priceTrain) + "$";
            }
            else
            {
                maskTrainShop[i].SetActive(true);
                priceTrain[i].text = "????";
            }
        }
    }
    public void CloseMenu()
    {
        Debug.Log("closemenu");
        switch (idMenu)
        {
            case 1:
                {
                    canvasBgFB.SetActive(false);
                    canvasDepot.SetActive(false);
                    mainScript.isDepotOpen = false;
                    break;
                }
            case 2:
                {
                    canvasBgFB.SetActive(false);
                    canvasTrainShop.SetActive(false);
                    mainScript.isTrainShopOpen = false;
                    break;
                }
            case 4:
                {
                    canvasBgFB.SetActive(false);
                    mainScript.isTownRawOpened = false;
                    if (townRawScript.isTown == true)
                        canvasTown.SetActive(false);
                    else
                        canvasRaw.SetActive(false);
                    break;
                }
        }
        mainScript.camRig.GetComponent<CameraController>().enabled = true;
        canvasMainUI.SetActive(true);
    }
}
