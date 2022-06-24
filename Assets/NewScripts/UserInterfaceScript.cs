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
    public int idMenu; // 1-Depot; 2-TrainShop; 3-TrainMenu; 4-TownRaw; 999-Null;
    [Header("MainUI")]
    public GameObject canvasMainUI;
    public GameObject btnBuildRail;
    public TextMeshProUGUI moneyui;
    public TextMeshProUGUI ticketsui;
    public GameObject canvasPointer;
    [Space]
    [Header("BGFB")]
    public GameObject canvasBgFB;
    public TextMeshProUGUI bgfbmoney;
    public TextMeshProUGUI bgfbtickets;
    public TextMeshProUGUI bgfgname;
    public GameObject[] bgPos;
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
    public int tr;
    public float bottomsize;

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
    public TextMeshProUGUI priceRoadText;
    [Space]
    [Header("SelectWay")]
    public GameObject canvasSelectWay;
    public GameObject panelSelectWay;
    public Button goSelectWay;
    public TextMeshProUGUI tipTextSelectWay;
    public TextMeshProUGUI firstCityNameSelectWay;
    public TextMeshProUGUI secondCityNameSelectWay;
    public Image firstCityImageSelectWay;
    public Image secondCityImageSelectWay;
    [Space]
    [Header("Depot")]
    public GameObject canvasDepot;
    public Image trainDepotImage;
    public TextMeshProUGUI nameTrainDepot;
    public TextMeshProUGUI speedTrainDepot;
    public Button selectTrainDepot;
    public Image[] wagonDepot;
    public List<GameObject> trainListDepot;
    public RectTransform contentDepot;
    [Space]
    [Header("TrainShop")]
    public GameObject canvasTrainShop;
    public TextMeshProUGUI[] priceTrain;
    public GameObject[] maskTrainShop;
    public GameObject[] buttonBuy;
    [Space]
    [Header("TrainMenu")]
    public GameObject canvasTrainMenu;
    public TextMeshProUGUI nameTrainTrainMenu;
    public TextMeshProUGUI speedTrainTrainMenu;
    public Image imageTrainTrainMenu;
    public Image imageHealthTrainMenu;
    public Button btnRepairTrainMenu;
    public Button btnSellTrainMenu;
    public Button upgradeTrainTrainMenu;
    public GameObject[] upgradesTrainTrainMenu;
    public TextMeshProUGUI healthTrainTrainMenu;
    public TextMeshProUGUI maxHealthTrainTrainMenu;
    public TextMeshProUGUI typeTrainTrainMenu;
    public TextMeshProUGUI upgradeTrainCostTrainMenu;
    public Image[] wagonTrainMenu;
    public Button[] buyWagonTrainMenu;
    [Header("RepairMenu")]
    public GameObject canvasRepairTrain;
    public Image firstHealthImageRepairTrain;
    public TextMeshProUGUI currentHealthRepairTrain;
    public TextMeshProUGUI firstMaxHealthRepairTrain;
    public TextMeshProUGUI secondMaxHealthRepairTrain;
    public TextMeshProUGUI afterHealthRepairTrain;
    public TextMeshProUGUI repairCostText;
    public Button repairButtonRepairTrain;
    [Header("WagonBuyMenu")]
    public WagonScript[] wagon;
    public GameObject canvasWagonBuy;
    public Button[] wagonButtonBuy;
    public TextMeshProUGUI[] priceBuyWagon;

    private void Awake()
    {
        idMenu = 999;
        InitializeCanvases();
    }
    void Update()
    {
        if (canvasBgFB.activeSelf)
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
        else if (mainScript.isTrainMenuOpen == true)
        {
            //CheckTrainMenuUpgradeCost();
        }
    }
    public void OpenRepairTrain()
    {
        canvasRepairTrain.SetActive(true);
        if (mainScript.pData.money <= tsScript.tScript.repairCost)
            repairButtonRepairTrain.interactable = false;
        else
            repairButtonRepairTrain.interactable = true;
        repairCostText.text = FormatNumsHelper.FormatNum(tsScript.tScript.repairCost);
        firstHealthImageRepairTrain.color = tsScript.tScript.colorHealth;
        currentHealthRepairTrain.color = tsScript.tScript.colorHealth;
        currentHealthRepairTrain.text = tsScript.tScript.health.ToString();
        firstMaxHealthRepairTrain.text = tsScript.tScript.maxHealth.ToString();
        secondMaxHealthRepairTrain.text = tsScript.tScript.maxHealth.ToString();
        afterHealthRepairTrain.text = tsScript.tScript.maxHealth.ToString();
    }
    public void OpenWagonBuyMenu()
    {
        canvasWagonBuy.SetActive(true);
        for (int i = 0; i < tsScript.wagonPref.Length; i++)
        {
            if (mainScript.pData.money >= tsScript.wagonPref[i].price)
                wagonButtonBuy[i].interactable = true;
            else
                wagonButtonBuy[i].interactable = false;
            priceBuyWagon[i].text = FormatNumsHelper.FormatNum(tsScript.wagonPref[i].price);
        }
    }
    public void CloseWagonBuyMenu()
    {
        canvasWagonBuy.SetActive(false);
    }
    public void CloseRepairTrain()
    {
        canvasRepairTrain.SetActive(false);
    }
    public void UpdateBGFB()
    {
        bgfbmoney.text = FormatNumsHelper.FormatNum(mainScript.pData.money);
        bgfbtickets.text = FormatNumsHelper.FormatNum(mainScript.pData.tickets);
    }
    public void OpenTrainShop()
    {
        CheckUnlockedTrains();
        CloseMenu();
        canvasPointer.SetActive(false);
        canvasMainUI.SetActive(false);
        idMenu = 2;
        canvasTrainShop.SetActive(true);
        bgfgname.text = "Train Shop";
        canvasBgFB.SetActive(true);
        mainScript.isTrainShopOpen = true;
        StartCoroutine("UpdateInfoTrainShop");
        mainScript.camRig.GetComponent<CameraController>().enabled = false;
    }
    public void OpenDepot()
    {
        canvasPointer.SetActive(false);
        tsScript.CloseElementDepot();
        if (mainScript.isTownRawInfoOpened == true)
        {
            mainScript.townRawScript.CloseTownRawInfo();
        }
        canvasMainUI.SetActive(false);
        idMenu = 1;
        canvasDepot.SetActive(true);
        bgfgname.text = "Depot";
        canvasBgFB.SetActive(true);
        mainScript.isDepotOpen = true;
        mainScript.camRig.GetComponent<CameraController>().enabled = false;
        contentDepot.offsetMax = new Vector2(0, 0);
        contentDepot.offsetMin = new Vector2(0, -tsScript.bottomsize);
        /*if (tsScript.tScript != null)
        {
            trainDepotImage.gameObject.SetActive(true);
            nameTrainDepot.gameObject.SetActive(true);
            speedTrainDepot.gameObject.SetActive(true);
            //selectTrainDepot
            wagonDepot[0].gameObject.SetActive(true);
            wagonDepot[1].gameObject.SetActive(true);
            wagonDepot[2].gameObject.SetActive(true);
            wagonDepot[3].gameObject.SetActive(true);

            trainDepotImage.sprite = tsScript.tScript.trainSprite;
            nameTrainDepot.text = tsScript.tScript.trainName;
            speedTrainDepot.text = tsScript.tScript.maxSpeed.ToString();
            //selectTrainDepot
            wagonDepot[0].sprite = tsScript.tScript.wagons[0];
            wagonDepot[1].sprite = tsScript.tScript.wagons[1];
            wagonDepot[2].sprite = tsScript.tScript.wagons[2];
            wagonDepot[3].sprite = tsScript.tScript.wagons[3];
            //trainListDepot
        }
        else
        {*/
        selectTrainDepot.interactable = false;
        trainDepotImage.gameObject.SetActive(false);
        nameTrainDepot.gameObject.SetActive(false);
        speedTrainDepot.gameObject.SetActive(false);
        //selectTrainDepot
        wagonDepot[0].gameObject.SetActive(false);
        wagonDepot[1].gameObject.SetActive(false);
        wagonDepot[2].gameObject.SetActive(false);
        wagonDepot[3].gameObject.SetActive(false);
        //trainListDepot
        //}

    }
    public void UpdateInfoDepot()
    {

    }
    public IEnumerator UpdateInfoTrainShop()
    {
        if (mainScript.isTrainShopOpen == true)
        {
            CheckUnlockedTrains();
            yield return new WaitForSeconds(1f);
            StartCoroutine("UpdateInfoTrainShop");
        }
    }
    /*public void CheckTrainMenuUpgradeCost()
    {
        if (mainScript.pData.money <= tsScript.tScript.tInfo.priceTrain)
        {
            upgradeTrainTrainMenu.interactable = false;
        }
    }*/
    public void OpenTrainMenu(TrainScript tScript)
    {
        canvasBgFB.SetActive(false);
        canvasDepot.SetActive(false);
        canvasPointer.SetActive(false);
        mainScript.isDepotOpen = false;
        contentDepot.offsetMax = new Vector2(0, 0);
        tsScript.CloseElementDepot();
        idMenu = 3;
        bgfgname.text = "Train Menu";
        canvasBgFB.SetActive(true);
        mainScript.isTrainMenuOpen = true;
        canvasTrainMenu.SetActive(true);
        tScript.StartCoroutine(tScript.checkHP());
        nameTrainTrainMenu.text = tScript.trainName + tScript.subNameTrain;
        speedTrainTrainMenu.text = tScript.maxSpeed.ToString() + " KM/H";
        healthTrainTrainMenu.text = tScript.health.ToString();
        maxHealthTrainTrainMenu.text = tScript.maxHealth.ToString();
        imageHealthTrainMenu.color = tScript.colorHealth;
        typeTrainTrainMenu.text = tScript.typeTrain;
        typeTrainTrainMenu.color = tScript.colorTypeTrain;
        upgradeTrainCostTrainMenu.text = FormatNumsHelper.FormatNum(tScript.tInfo.priceTrain);
        mainScript.camRig.GetComponent<CameraController>().enabled = false;
    }
    public void UpdateInfoTown()
    {//townRawScript.productCount
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

        rawFullBarZero.fillAmount = townRawScript.timeCurrent / townRawScript.timeForProduct;
        rawFullBarFirst.fillAmount = mainScript.townRawScript.rawCount / mainScript.townRawScript.maxStorageRaw;
    }
    public void OpenTownRaw()
    {
        canvasPointer.SetActive(false);
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
            bgPos[0].transform.position = bgPos[2].transform.position;
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
        for (int i = 0; i < mainScript.pData.trainUnlocked.Length; i++)
        {
            if (mainScript.pData.trainUnlocked[i] == true)
            {
                maskTrainShop[i].SetActive(false);
                priceTrain[i].text = FormatNumsHelper.FormatNum(tsScript.tInfo[i].priceTrain) + "$";
                if (tsScript.tInfo[i].priceTrain > mainScript.pData.money)
                {
                    buttonBuy[i].GetComponent<Button>().interactable = false;
                }
                else
                {
                    buttonBuy[i].GetComponent<Button>().interactable = true;
                }
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
        switch (idMenu)
        {
            case 1:
                {
                    canvasBgFB.SetActive(false);
                    canvasDepot.SetActive(false);
                    mainScript.isDepotOpen = false;
                    contentDepot.offsetMax = new Vector2(0, 0);
                    tsScript.CloseElementDepot();
                    break;
                }
            case 2:
                {
                    canvasBgFB.SetActive(false);
                    canvasTrainShop.SetActive(false);
                    mainScript.isTrainShopOpen = false;
                    StopCoroutine("UpdateInfoTrainShop");
                    break;
                }
            case 3:
                {
                    canvasBgFB.SetActive(false);
                    canvasTrainMenu.SetActive(false);
                    mainScript.isTrainMenuOpen = false;
                    tsScript.tScript.StopCoroutine(tsScript.tScript.checkHP());
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
                    bgPos[0].transform.position = bgPos[1].transform.position;
                    break;
                }
        }
        idMenu = 999;
        mainScript.camRig.GetComponent<CameraController>().enabled = true;
        canvasPointer.SetActive(true);
        canvasMainUI.SetActive(true);
    }
    public void InitializeCanvases()
    {
        canvasBgFB.SetActive(true);
        canvasBgFB.SetActive(false);
        //Debug.Log("Canvas BgFb initialized");

        canvasDepot.SetActive(true);
        canvasDepot.SetActive(false);
        //Debug.Log("Canvas Depot initialized");

        canvasTrainShop.SetActive(true);
        canvasTrainShop.SetActive(false);
        //Debug.Log("Canvas TrainShop initialized");

        canvasRaw.SetActive(true);
        canvasRaw.SetActive(false);
        //Debug.Log("Canvas Raw initialized");

        canvasTown.SetActive(true);
        canvasTown.SetActive(false);
        //Debug.Log("Canvas Town initialized");

        canvasBuildRail.SetActive(true);
        canvasBuildRail.SetActive(false);
        //Debug.Log("Canvas BuildRail initialized");

        canvasTrainMenu.SetActive(true);
        canvasTrainMenu.SetActive(false);
        //Debug.Log("Canvas TrainMenu initialized");
    }
}
