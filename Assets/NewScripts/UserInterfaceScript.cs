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
    public Sprite currencyMoney;
    public Sprite currencyTickets;
    public Color green;
    public Color yellow;
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
    public TextMeshProUGUI currentTimeForProduct;
    public TextMeshProUGUI nextTimeForProduct;
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

    public Image[] peopleImageTown;
    public Sprite peopleImageTownEmptySprite;
    public Sprite peopleImageTownFullSprite;
    public TextMeshProUGUI currentTimeForPeople;
    public TextMeshProUGUI newTimeForPeople;
    public TextMeshProUGUI countOfPeople;
    public TextMeshProUGUI maxPeopleCurrent;
    public TextMeshProUGUI peopleForTime;
    public TextMeshProUGUI maxPeopleNext;
    public TextMeshProUGUI peopleForTimeNext;
    public Image peopleFullBar;

    [Space]
    [Header("RawUI")]
    public GameObject canvasRaw;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeRawText;
    public TextMeshProUGUI rawCountFirstText;
    public TextMeshProUGUI timeForProduct;
    public Image rawSpriteImage;
    public Image RawSprite;
    public Image rawFullBarZero;
    public Image rawFullBarFirst;
    public Image rawFullBarSecond;
    public Image rawFullBarThird;
    public Image rawToRawFullBar;
    [Space]
    [Header("RawMenu")]
    public Button upgradeRaw;
    public TextMeshProUGUI timeToRawNext;
    public TextMeshProUGUI timeToRawCurrent;
    public TextMeshProUGUI nextPeopleToRaw;
    public TextMeshProUGUI currentPeopleToRaw;

    public TextMeshProUGUI countOfPeopleRaw;
    public TextMeshProUGUI secondFullBarCountRaw;
    public TextMeshProUGUI upgradePriceRaw;
    public TextMeshProUGUI lvlOpenSecondStorage;
    public Image fullBarPeopleRaw;
    public Image secondfullBarRaw;
    public Image emptySecondFullBar;
    public Image resourceToRawStorage;//people
    public Image secondRawStorage;
    public Image resourseToRawFirst;
    public Image rawFromResourse;

    public TextMeshProUGUI currentRawFromPeople;
    public TextMeshProUGUI nextRawFromPeople;
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
    public GameObject infoDepot;
    public Image trainDepotImage;
    public TextMeshProUGUI nameTrainDepot;
    public TextMeshProUGUI speedTrainDepot;
    public Button selectTrainDepot;
    public List<Image> wagonDepot;
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
    public GameObject panelNoRoute;
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
    public Image[] wagonCargoSprite;
    public TextMeshProUGUI[] loadWeightTrainMenu;
    [Space]
    [Header("Upgrade")]
    public TextMeshProUGUI[] nameAbility;
    public TextMeshProUGUI[] countAbility;
    public Image[] imageAbility;
    public Image[] maskAbility;
    public Button upgradeTrain;
    public TextMeshProUGUI upgradeTrainPrice;
    public Image currencyUpgradeTrain;
    public GameObject centerUpgradeTrain;
    public GameObject rightUpgradeTrain;
    [Space]
    [Header("RepairMenu")]
    public GameObject canvasRepairTrain;
    public Image firstHealthImageRepairTrain;
    public Image secondHealthImageRepairTrain;
    public TextMeshProUGUI currentHealthRepairTrain;
    public TextMeshProUGUI firstMaxHealthRepairTrain;
    public TextMeshProUGUI secondMaxHealthRepairTrain;
    public TextMeshProUGUI afterHealthRepairTrain;
    public TextMeshProUGUI repairCostText;
    public Button repairButtonRepairTrain;
    public bool isRepairMenuOpen;
    [Header("WagonBuyMenu")]
    public WagonScript[] wagon;
    public GameObject canvasWagonBuy;
    public Button[] wagonButtonBuy;//0- pass 1-freight
    public TextMeshProUGUI[] priceBuyWagon;
    [Header("SellTrainMenu")]
    public GameObject canvasSellTrainMenu;
    public TextMeshProUGUI nameTrainSellMenu;
    public TextMeshProUGUI currentHealthSellMenu;
    public TextMeshProUGUI maxHealthSellMenu;
    public TextMeshProUGUI sellPriceSellMenu;
    public TextMeshProUGUI extraPriceSellMenu;
    public Image trainImageSellMenu;
    public Image[] wagonImageSellMenu;
    public Image healthImageSellMenu;
    public bool isSellMenuOpen;
    public bool isWagonBuyMenuOpen;

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
                if (mainScript.pData.newMoney >= rsScript.roadSelected.price)
                {
                    buyRail.GetComponent<Button>().interactable = true;
                }
                else
                    buyRail.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void AddNewRoute()
    {
        CloseMenu();
        tsScript.trManager.OpenAll();
        tsScript.trManager.tScript = tsScript.tScript;
        mainScript.camToTargetCoroutine = mainScript.CamToTarget(tsScript.trManager.gameObject, true, 15f);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
    }
    public void OpenSellMenuTrain()
    {
        canvasSellTrainMenu.SetActive(true);
        isSellMenuOpen = true;
        tsScript.tScript.ShowHp();
        nameTrainSellMenu.text = tsScript.tScript.trainName;
        trainImageSellMenu.sprite = tsScript.tScript.trainSprite;
        currentHealthSellMenu.text = tsScript.tScript.health.ToString();
        maxHealthSellMenu.text = tsScript.tScript.maxHealth.ToString();
        sellPriceSellMenu.text = FormatNumsHelper.FormatNum(tsScript.tScript.sellPrice) + "$";
        extraPriceSellMenu.text = FormatNumsHelper.FormatNum(tsScript.tScript.sellExtraPrice) + "$";
        healthImageSellMenu.color = tsScript.tScript.colorHealth;
        for (int b = 0; b < wagonImageSellMenu.Length; b++)
            wagonImageSellMenu[b].gameObject.SetActive(false);
        for (int i = 0; i < tsScript.tScript.wagon.Count; i++)
        {
            wagonImageSellMenu[i].gameObject.SetActive(true);
            wagonImageSellMenu[i].sprite = tsScript.tScript.wagon[i].wagonSprite;
        }
    }
    public void UpdateInfoSellMenuTrain()
    {
        Debug.Log("sellinfo");
        sellPriceSellMenu.text = FormatNumsHelper.FormatNum(tsScript.tScript.sellPrice) + "$";
        currentHealthSellMenu.text = tsScript.tScript.health.ToString();
        currentHealthSellMenu.color = tsScript.tScript.colorHealth;
        healthImageSellMenu.color = tsScript.tScript.colorHealth;
    }
    public void OpenRepairTrain()
    {
        isRepairMenuOpen = true;
        tsScript.tScript.ShowHp();
        canvasRepairTrain.gameObject.SetActive(true);
        if (mainScript.pData.newMoney >= tsScript.tScript.repairCost)
            repairButtonRepairTrain.interactable = true;
        else
            repairButtonRepairTrain.interactable = false;
        repairCostText.text = FormatNumsHelper.FormatNum(tsScript.tScript.repairCost) + "$";

        currentHealthRepairTrain.color = tsScript.tScript.colorHealth;
        currentHealthRepairTrain.text = tsScript.tScript.health.ToString();
        firstHealthImageRepairTrain.color = tsScript.tScript.colorHealth;
        firstMaxHealthRepairTrain.text = tsScript.tScript.maxHealth.ToString();

        afterHealthRepairTrain.color = tsScript.tScript.newRepairColor;
        afterHealthRepairTrain.text = tsScript.tScript.newRepair.ToString();
        secondHealthImageRepairTrain.color = tsScript.tScript.newRepairColor;
        secondMaxHealthRepairTrain.text = tsScript.tScript.maxHealth.ToString();
    }
    public void UpdateRepairInfo()
    {
        Debug.Log("repinfo");
        if (mainScript.pData.newMoney >= tsScript.tScript.repairCost)
            repairButtonRepairTrain.interactable = true;
        else
            repairButtonRepairTrain.interactable = false;

        repairCostText.text = FormatNumsHelper.FormatNum(tsScript.tScript.repairCost) + "$";

        currentHealthRepairTrain.color = tsScript.tScript.colorHealth;
        currentHealthRepairTrain.text = tsScript.tScript.health.ToString();

        firstHealthImageRepairTrain.color = tsScript.tScript.colorHealth;

        afterHealthRepairTrain.color = tsScript.tScript.newRepairColor;
        afterHealthRepairTrain.text = tsScript.tScript.newRepair.ToString();

        secondHealthImageRepairTrain.color = tsScript.tScript.newRepairColor;
    }
    public void UpdateWagonBuyMenu()
    {
        Debug.Log("waginfo");
        wagonButtonBuy[1].interactable = true;
        wagonButtonBuy[0].interactable = true;
        for (int i = 0; i < tsScript.wagonPref.Length; i++)
        {
            if (mainScript.pData.newMoney >= tsScript.wagonPref[i].price)
                wagonButtonBuy[i].interactable = true;
            else
                wagonButtonBuy[i].interactable = false;
            priceBuyWagon[i].text = FormatNumsHelper.FormatNum(tsScript.wagonPref[i].price) + "$";
        }
        if (tsScript.tScript.typeTrain == "Pass Only!")
            wagonButtonBuy[1].interactable = false;
        else if (tsScript.tScript.typeTrain == "Freight Only!")
            wagonButtonBuy[0].interactable = false;
        switch (tsScript.tScript.typeTrain)
        {
            case "Freight":
                {
                    wagonButtonBuy[0].interactable = false;
                    break;
                }
            case "Passenger":
                {
                    wagonButtonBuy[1].interactable = false;
                    break;
                }
        }
    }
    public void OpenWagonBuyMenu()
    {
        isWagonBuyMenuOpen = true;
        wagonButtonBuy[1].interactable = true;
        wagonButtonBuy[0].interactable = true;
        canvasWagonBuy.SetActive(true);
        for (int i = 0; i < tsScript.wagonPref.Length; i++)
        {
            if (mainScript.pData.newMoney >= tsScript.wagonPref[i].price)
                wagonButtonBuy[i].interactable = true;
            else
                wagonButtonBuy[i].interactable = false;
            priceBuyWagon[i].text = FormatNumsHelper.FormatNum(tsScript.wagonPref[i].price) + "$";
        }
        if (tsScript.tScript.typeTrain == "Pass Only!")
            wagonButtonBuy[1].interactable = false;
        else if (tsScript.tScript.typeTrain == "Freight Only!")
            wagonButtonBuy[0].interactable = false;
        switch (tsScript.tScript.typeTrain)
        {
            case "Freight":
                {
                    wagonButtonBuy[0].interactable = false;
                    break;
                }
            case "Passenger":
                {
                    wagonButtonBuy[1].interactable = false;
                    break;
                }
        }
    }
    public void CloseWagonBuyMenu()
    {
        isWagonBuyMenuOpen = false;
        canvasWagonBuy.SetActive(false);
    }
    public void CloseRepairTrain()
    {
        canvasRepairTrain.SetActive(false);
        isRepairMenuOpen = false;
    }
    public void CloseSellMenuTrain()
    {
        canvasSellTrainMenu.SetActive(false);
        isSellMenuOpen = false;
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
        canvasMainUI.SetActive(false);
        idMenu = 2;
        canvasTrainShop.SetActive(true);
        bgfgname.text = "Train Shop";
        canvasBgFB.SetActive(true);
        mainScript.isTrainShopOpen = true;
        mainScript.camRig.GetComponent<CameraController>().enabled = false;
    }
    public void OpenDepot()
    {
        tsScript.CloseElementDepot();
        tsScript.tScript = null;
        if (mainScript.isTownRawInfoOpened == true)
            mainScript.townRawScript.CloseTownRawInfo();
        for (int t = 0; t < tsScript.train.Count; t++)
        {
            TrainScript tScript = tsScript.train[t].GetComponent<TrainScript>();
            tScript.maxHealthText.text = tScript.maxHealth.ToString();
            tScript.healthText.text = tScript.health.ToString();
            tScript = null;
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
        selectTrainDepot.interactable = false;
        trainDepotImage.gameObject.SetActive(false);
        nameTrainDepot.gameObject.SetActive(false);
        speedTrainDepot.gameObject.SetActive(false);
        for (int i = 0; i < wagonDepot.Count; i++)
            wagonDepot[i].gameObject.SetActive(false);

    }
    public void CheckTrainUpgrade(TrainScript tScript)
    {
        currencyUpgradeTrain.gameObject.SetActive(true);

        for (int i = 0; i < maskAbility.Length; i++)
            maskAbility[i].gameObject.SetActive(true);
        for (int u = 0; u < tScript.upgradeLvl; u++)
        {
            maskAbility[u].gameObject.SetActive(false);
            nameAbility[u].text = tScript.tUpgrade[u].upgradeName;
        }
            
        if (tScript.isUpgradeTicket)
            currencyUpgradeTrain.sprite = currencyTickets;
        else
            currencyUpgradeTrain.sprite = currencyMoney;
        upgradeTrainPrice.transform.SetParent(rightUpgradeTrain.transform);
        upgradeTrainPrice.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        upgradeTrain.interactable = true;
        if (tScript.upgradeLvl < tScript.tUpgrade.Length)
        {
            if (tScript.tUpgrade[tScript.upgradeLvl].isTickets)
            {
                if (tsScript.mainScript.pData.newTickets < tScript.tUpgrade[tScript.upgradeLvl].upgradeCost)
                {
                    upgradeTrain.interactable = false;
                    upgradeTrainPrice.text = FormatNumsHelper.FormatNum(tScript.tUpgrade[tScript.upgradeLvl].upgradeCost);
                    return;
                }
            }
            else
            {
                if (tsScript.mainScript.pData.newMoney < tScript.tUpgrade[tScript.upgradeLvl].upgradeCost)
                {
                    upgradeTrain.interactable = false;
                    upgradeTrainPrice.text = FormatNumsHelper.FormatNum(tScript.tUpgrade[tScript.upgradeLvl].upgradeCost);
                    return;
                }
            }
            upgradeTrainPrice.text = FormatNumsHelper.FormatNum(tScript.tUpgrade[tScript.upgradeLvl].upgradeCost);
        }
        switch (tScript.upgradeLvl)
        {
            case 0:
                {
                    countAbility[0].text = tScript.maxSpeed + tScript.tUpgrade[0].upgradeInfo;
                    break;
                }
            case 1:
                {
                    
                    countAbility[1].text = tScript.chanceBroke + tScript.tUpgrade[1].upgradeInfo;
                    break;
                }
            case 2:
                {
                    countAbility[2].text = tScript.maxHealth + tScript.tUpgrade[2].upgradeInfo;
                    break;
                }
            case 3:
                {
                    countAbility[3].text = tScript.wagonsLoadingSpeed + tScript.tUpgrade[3].upgradeInfo;
                    break;
                }
            case 4:
                {
                    countAbility[4].text = tScript.tUpgrade[4].upgradeInfo;
                    break;
                }
            case 5:
                {
                upgradeTrainPrice.transform.SetParent(centerUpgradeTrain.transform);
                upgradeTrainPrice.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                upgradeTrain.interactable = false;
                upgradeTrainPrice.text = "MaxLvl";
                currencyUpgradeTrain.gameObject.SetActive(false);
                break;
                }
        }
    }
    public void OpenTrainMenu(TrainScript tScript)
    {
        canvasBgFB.SetActive(false);
        canvasDepot.SetActive(false);
        mainScript.isDepotOpen = false;
        contentDepot.offsetMax = new Vector2(0, 0);
        tsScript.CloseElementDepot();
        idMenu = 3;
        bgfgname.text = "Train Menu";
        canvasBgFB.SetActive(true);
        mainScript.isTrainMenuOpen = true;
        canvasTrainMenu.SetActive(true);

        nameTrainTrainMenu.text = tScript.trainName + tScript.subNameTrain;
        speedTrainTrainMenu.text = tScript.maxSpeed.ToString() + " KM/H";
        imageTrainTrainMenu.sprite = tScript.trainSprite;

        tsScript.tScript.ShowHp();
        healthTrainTrainMenu.text = tScript.health.ToString();
        healthTrainTrainMenu.color = tScript.colorHealth;
        maxHealthTrainTrainMenu.text = tScript.maxHealth.ToString();
        imageHealthTrainMenu.color = tScript.colorHealth;

        typeTrainTrainMenu.text = tScript.typeTrain;
        typeTrainTrainMenu.color = tScript.colorTypeTrain;

        mainScript.camRig.GetComponent<CameraController>().enabled = false;
        //Upgrade
        CheckTrainUpgrade(tScript);
        //
        for (int b = 0; b < buyWagonTrainMenu.Length; b++)
        {
            wagonTrainMenu[b].gameObject.SetActive(false);
            buyWagonTrainMenu[b].gameObject.SetActive(true);
        }
        for (int i = 0; i < tScript.wagon.Count; i++)
        {
            wagonTrainMenu[tScript.wagon[i].wagonNum].gameObject.SetActive(true);
            wagonTrainMenu[tScript.wagon[i].wagonNum].sprite = tScript.wagon[i].wagonSprite;
            buyWagonTrainMenu[tScript.wagon[i].wagonNum].gameObject.SetActive(false);
            if (tsScript.tScript.wagon[i].spriteCargo != null)
                wagonCargoSprite[tsScript.tScript.wagon[i].wagonNum].sprite = tsScript.tScript.wagon[i].spriteCargo;
            else
                wagonCargoSprite[tsScript.tScript.wagon[i].wagonNum].sprite = tsScript.tScript.wagon[i].emptySpriteCargo;
            loadWeightTrainMenu[tScript.wagon[i].wagonNum].text = FormatNumsHelper.FormatNum(tScript.wagon[i].loadWeight) + "/" + FormatNumsHelper.FormatNum(tScript.wagon[i].maxLoadWeight);
        }
        panelNoRoute.SetActive(false);
        if (tsScript.tScript.way.Count == 0)
            panelNoRoute.SetActive(true);
    }
    public void UpdateInfoTown()
    {
        productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
        rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        countOfPeople.text = FormatNumsHelper.FormatNum(townRawScript.peopleCount);

        productFullBar.fillAmount = mainScript.townRawScript.productCount / mainScript.townRawScript.maxStorageProduct;
        rawFullBar.fillAmount = mainScript.townRawScript.rawCount / mainScript.townRawScript.maxStorageRaw;


        rawToProductFullBar.fillAmount = townRawScript.timeCurrent / townRawScript.timeForProduct;
        peopleFullBar.fillAmount = townRawScript.timeCurrentPeople / townRawScript.timeForPeople;
        if (townRawScript.upgradeLvl > 3)
        {
            upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
            upgradeButton.interactable = false;
        }
        else if (mainScript.pData.newMoney < townRawScript.upgradeCost[townRawScript.upgradeLvl])
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
        
        countOfPeopleRaw.text = FormatNumsHelper.FormatNum(townRawScript.peopleCount);

        rawFullBarZero.fillAmount = townRawScript.timeCurrentRaw / townRawScript.timeForRaw;
        rawFullBarFirst.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
        fullBarPeopleRaw.fillAmount = townRawScript.peopleCount / townRawScript.maxPeople;
        rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        if (townRawScript.isSecondStorageOpen == true)
        {
            secondfullBarRaw.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
            rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount/2);
            secondFullBarCountRaw.text = FormatNumsHelper.FormatNum(townRawScript.rawCount/2);
        }
           
        if (townRawScript.upgradeLvl > 3)
        {
            upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
            upgradeRaw.interactable = false;
        }
        else if (mainScript.pData.newMoney < townRawScript.upgradeCost[townRawScript.upgradeLvl])
        {
            upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
            upgradeRaw.interactable = false;
        }
        else
        {
            upgradeRaw.GetComponent<Image>().color = new Color(255, 255, 255);
            upgradeRaw.interactable = true;
        }
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
            currentTimeForProduct.text = townRawScript.timeForProduct.ToString() + "s";
            for (int i = 0; i < peopleImageTown.Length; i++)
                peopleImageTown[i].sprite = peopleImageTownEmptySprite;
            townRawScript.CheckPeople();
            //station
            countOfPeople.text = FormatNumsHelper.FormatNum(townRawScript.peopleCount);
            peopleForTime.text = FormatNumsHelper.FormatNum(townRawScript.peopleForTime);
            currentTimeForPeople.text = townRawScript.timeForPeople.ToString() + "s";
            maxPeopleCurrent.text = FormatNumsHelper.FormatNum(townRawScript.maxPeople);

            if (townRawScript.upgradeLvl < 4)
            {
                upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeRaw.interactable = false;
                nextTimeForProduct.text = townRawScript.newTimeForProduct[townRawScript.upgradeLvl+1].ToString() + "s";
                upgradeCostText.text = FormatNumsHelper.FormatNum(townRawScript.upgradeCost[townRawScript.upgradeLvl]) + "$";
                newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.newRawToProduct[townRawScript.upgradeLvl + 1]));
                newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.newProductFromRaw[townRawScript.upgradeLvl + 1]));
                //station
                peopleForTimeNext.text = FormatNumsHelper.FormatNum((townRawScript.peopleForTimeNext[townRawScript.upgradeLvl + 1]));
                newTimeForPeople.text = townRawScript.timeForPeopleNext[townRawScript.upgradeLvl + 1].ToString() + "s";
                maxPeopleNext.text = FormatNumsHelper.FormatNum(townRawScript.maxPeopleNext[townRawScript.upgradeLvl + 1]);
            }
            else
            {
                nextTimeForProduct.text = townRawScript.newTimeForProduct[townRawScript.upgradeLvl].ToString() + "s";
                newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.newRawToProduct[townRawScript.upgradeLvl]));
                newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.newProductFromRaw[townRawScript.upgradeLvl]));
                upgradeCostText.text = "MaxLvl";
                upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeRaw.interactable = false;
                //station
                peopleForTimeNext.text = FormatNumsHelper.FormatNum((townRawScript.peopleForTime));
                newTimeForPeople.text = townRawScript.timeForPeople.ToString() + "s";
                maxPeopleNext.text = FormatNumsHelper.FormatNum(townRawScript.maxPeople);
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
            resourceToRawStorage.sprite = townRawScript.resourceToRaw;
            resourseToRawFirst.sprite = townRawScript.resourceToRaw;
            rawFromResourse.sprite = townRawScript.rawSprite;
            rawSpriteImage.sprite = townRawScript.rawSpriteImage;

            rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
            countOfPeople.text = FormatNumsHelper.FormatNum(townRawScript.peopleCount);

            currentRawFromPeople.text = FormatNumsHelper.FormatNum((townRawScript.rawFromPeople));
            timeToRawCurrent.text = townRawScript.newTimeForRaw[townRawScript.upgradeLvl].ToString() + "s";
            currentPeopleToRaw.text = FormatNumsHelper.FormatNum((townRawScript.peopleToRaw));
            emptySecondFullBar.gameObject.SetActive(true);
            lvlOpenSecondStorage.text = townRawScript.lvlOpenSecondStorage.ToString() + "lvl";
            if (townRawScript.isSecondStorageOpen == true)
                emptySecondFullBar.gameObject.SetActive(false);
            if (townRawScript.upgradeLvl < 4)
            {
                nextRawFromPeople.text = FormatNumsHelper.FormatNum((townRawScript.newRawFromPeople[townRawScript.upgradeLvl + 1]));
                timeToRawNext.text = townRawScript.newTimeForRaw[townRawScript.upgradeLvl + 1].ToString() + "s";
                upgradePriceRaw.text = FormatNumsHelper.FormatNum(townRawScript.upgradeCost[townRawScript.upgradeLvl]) + "$";
                nextPeopleToRaw.text = FormatNumsHelper.FormatNum((townRawScript.newPeopleToRaw[townRawScript.upgradeLvl + 1]));
                upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeRaw.interactable = false;
            }
            else
            {
                upgradePriceRaw.text = "MaxLvl";
                upgradeRaw.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeRaw.interactable = false;
            }
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
                if (tsScript.tInfo[i].priceTrain > mainScript.pData.newMoney)
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
        switch (idMenu)//1 - Depot; 2 - TrainShop; 3 - TrainMenu; 4 - TownRaw; 999 - Null;
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
                    break;
                }
            case 3:
                {
                    canvasBgFB.SetActive(false);
                    canvasTrainMenu.SetActive(false);
                    panelNoRoute.SetActive(true);
                    mainScript.isTrainMenuOpen = false;
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
