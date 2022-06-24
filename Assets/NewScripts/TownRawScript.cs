using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TownRawScript : MonoBehaviour
{
    public TownInfo townInfo;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public TownRawManager trManager;
    public TargetPointer tPointer;
    public Outline outline;
    public RailRoadScript[] road;
    [Space]
    [Header("Train")]
    public GameObject spawnPoint;
    public GameObject[] directionPoint;
    [Header("InfoCanvasObjects")]
    public TextMeshProUGUI townNameText;
    public GameObject emptyBar;
    public Image fullBar;
    public Image publicBussinessSprite;
    public Image publicRawSprite;
    public Button openBtn;
    [Space]
    public bool isTown;
    public int TownNumber;
    public string townName;
    public string businessName;
    public string rawName;
    public string rawType;
    public string productType;
    public Sprite rawSpriteImage;
    public Sprite businessSprite;
    public Sprite rawSprite;
    public float timeForProduct;
    public float timeCurrent = 0;
    public bool isProductReady;
    public bool changeCount;
    private bool isTownRawOpen;
    public bool isCityUnblock;
    public bool isCitySelectWay;
    public bool isCityCanBeSelectWay;
    private IEnumerator MSG;
    private IEnumerator RTP;

    public float maxStorageProduct;
    public float maxStorageRaw;

    public int upgradeLvl;
    public float[] upgradeCost;
    public float rawToProduct;
    public float[] newProductFromRaw;
    public float[] newRawToProduct;
    public float productFromRaw;
    public float multiplier;
    public float productCount;
    public float rawCount;
    public float newProduct;
    public float newRaw;
    public int numWay; // 0-start 1-finish

    private WaitForSeconds twoSeconds;
    public GameObject TownRawCanvas;
    void Awake()
    {
        tPointer = gameObject.GetComponent<TargetPointer>();
        //outline.enabled = true;
        twoSeconds = new WaitForSeconds(2f);
        if (isTown == true)
        {
            productType = townInfo.typeProduct;
            businessName = townInfo.businessName;
            businessSprite = townInfo.businessSprite;
            maxStorageProduct = townInfo.maxStorageProduct;
            upgradeCost = townInfo.upgradeCost;
            productFromRaw = townInfo.productFromRaw;
            newProductFromRaw = townInfo.newProductFromRaw;
            newRawToProduct = townInfo.newRawToProduct;
            
        }
        else
            rawSpriteImage = townInfo.rawSpriteImage;
        townName = townInfo.townName;
        rawName = townInfo.rawName;
        maxStorageRaw = townInfo.maxStorageRaw;
        rawSprite = townInfo.rawSprite;
        rawToProduct = townInfo.rawToProduct;
        timeForProduct = townInfo.timeForProduct;
        multiplier = townInfo.multiplier;
        rawType = townInfo.typeRaw;
    }
    private void Start()
    {
        newRaw = rawCount;
        if (isTown == true)
            newProduct = productCount;
        //outline.enabled = false;
        CheckProductReady();
    }
    private void Update()
    {
        if (isCityUnblock == true)
        { 
            if (changeCount == true)
            {
                if (isTown == true)
                {
                    productCount = Mathf.Lerp(productCount, newProduct, Time.deltaTime * 5f);
                    rawCount = Mathf.Lerp(rawCount, newRaw, Time.deltaTime * 5f);
                    if (rawCount - newRaw <= 0.4)
                    {
                        productCount = Mathf.Round(productCount);
                        rawCount = Mathf.Round(rawCount);
                        changeCount = false;
                    }
                }
                else
                {
                    rawCount = Mathf.Lerp(rawCount, newRaw, Time.deltaTime * 5f);
                    if (newRaw - rawCount <= 0.4)
                    {
                        rawCount = Mathf.Round(rawCount);
                        changeCount = false;
                    }
                }
            }
            if (isProductReady == true)
            {
                timeCurrent += Time.deltaTime;
                if (timeCurrent > timeForProduct)
                {
                    if (isTown == true)
                    {
                        StartCoroutine(ChangeProduct(+productFromRaw));
                        StartCoroutine(ChangeRaw(-rawToProduct));
                        isProductReady = false;
                        timeCurrent = 0;
                        CheckProductReady();
                    }
                    else
                    {
                        StartCoroutine(ChangeRaw(rawToProduct));
                        isProductReady = false;
                        timeCurrent = 0;
                        CheckProductReady();
                    }
                }  
            }
            if (isTownRawOpen == true)
            {
                fullBar.fillAmount = timeCurrent / timeForProduct;
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
                        if (_hit.collider.gameObject.name != gameObject.name)
                        {
                            CloseTownRawInfo();
                        }
                    }
                }   
            }  
        }
    }
    public void Upgrade()
    {
        if (isTown == true)
        {
            if (upgradeLvl <= 3)
            {
                if (mainScript.pData.money >= upgradeCost[upgradeLvl])
                {
                    mainScript.pData.ChangeMoney(this.gameObject, -upgradeCost[upgradeLvl]);
                    upgradeLvl++;
                    productFromRaw = newProductFromRaw[upgradeLvl];
                    rawToProduct = newRawToProduct[upgradeLvl];
                    uiScript.rawToProductText.text = FormatNumsHelper.FormatNum((rawToProduct));
                    uiScript.productFromRawText.text = FormatNumsHelper.FormatNum((productFromRaw));
                    if (upgradeLvl > 3)
                        uiScript.upgradeCostText.text = "MaxLvl";
                    else
                    {
                        uiScript.upgradeCostText.text = FormatNumsHelper.FormatNum(upgradeCost[upgradeLvl]) + "$";
                        uiScript.newRawToProductText.text = FormatNumsHelper.FormatNum((newRawToProduct[upgradeLvl+1]));
                        uiScript.newProductFromRawText.text = FormatNumsHelper.FormatNum((newProductFromRaw[upgradeLvl+1]));
                    }

                }
                else
                    Debug.Log("You dont have enough money!");
            }
            else
                Debug.Log("Your Lvl is Max");
        }
    }
    private void CheckProductReady()
    {
        if (isCityUnblock == true)
        { 
            if (isTown == true)
            {
                if (newRaw >= rawToProduct)
                {
                    if (newProduct < maxStorageProduct && newProduct+productFromRaw < maxStorageProduct)
                    {
                        isProductReady = true;
                        if (mainScript.isSelectWayOpen == false && mainScript.isTownRawInfoOpened == false)
                            tPointer.Hide();
                    }
                    else
                    {
                        isProductReady = false;
                        if (mainScript.isTownRawInfoOpened == false)
                            StartCoroutine(Msg("StorageFull"));
                    }
                }
                else
                {
                    isProductReady = false;
                    if (mainScript.isTownRawInfoOpened == false)
                        StartCoroutine(Msg("RawIsNotEnough"));
                }
            }
            else
            {
                if (newRaw < maxStorageRaw)
                {
                    isProductReady = true;
                    if (mainScript.isSelectWayOpen == false && mainScript.isTownRawInfoOpened == false)
                        tPointer.Hide();
                }
                else
                {
                    isProductReady = false;
                    if (mainScript.isTownRawInfoOpened == false)
                        StartCoroutine(Msg("StorageFull"));
                }
            }
        }
    }
    private IEnumerator ChangeProduct(float value)
    {
        changeCount = true;
        newProduct += value;
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator ChangeRaw(float value)
    {
        changeCount = true;
        newRaw += value;
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator Msg(string msg)
    {
        if (mainScript.isSelectWayOpen == false)
        { 
            tPointer.Hide();
            tPointer.Spawn(gameObject, msg);
        }
        yield return twoSeconds;
        CheckProductReady();
    }
    public void OnMouseDown()
    {
        if (mainScript.isGamePaused == false)
        {
            if (mainScript.isBuildRailOpen == false)
            {
                if (isCityUnblock == true)
                { 
                    if (mainScript.isSelectWayOpen == false)
                    {
                        if (uiScript.idMenu == 999)
                        {
                            if (mainScript.isTownRawInfoOpened == false)
                            {
                                if(isTownRawOpen == false)
                                    OpenTownRawInfo();
                            }
                        }
                    }
                    else
                        trManager.CheckClick(this);
                }
            }
        }
    }
    public void CloseTownRawInfo()
    {
        if (tPointer.PointerUI != null)
            tPointer.PointerUI.gameObject.SetActive(true);
        TownRawCanvas.SetActive(false);

        mainScript.isTownRawInfoOpened = false;
        isTownRawOpen = false;
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
    }
    public void OpenTownRawInfo()
    {
        for (int b = 0; b < uiScript.tsScript.train.Count; b++)
        {
            uiScript.tsScript.train[b].GetComponent<TrainScript>().tPointer.Hide();
        }
        if (tPointer.PointerUI != null)
            tPointer.PointerUI.gameObject.SetActive(false);
        isTownRawOpen = true;
        mainScript.isTownRawInfoOpened = true;
        mainScript.townRawScript = this;

        uiScript.townRawScript = this;

        mainScript.camToTargetCoroutine = mainScript.CamToTarget(gameObject, true, 5f);
        mainScript.StartCoroutine(mainScript.camToTargetCoroutine);

        TownRawCanvas.SetActive(true);
        townNameText.text = townName;
        publicRawSprite.sprite = rawSprite;
        if (isTown == true)
            publicBussinessSprite.sprite = businessSprite;
    }
}
