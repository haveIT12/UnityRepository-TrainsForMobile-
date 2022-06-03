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
    private bool isTownRawOpen;
    [Header("InfoCanvasObjects")]
    public TextMeshProUGUI townNameText;
    public Image fullBar;
    public Image publicBussinessSprite;
    public Image publicRawSprite;
    [Space]

    public bool isTown;
    public int TownNumber;
    public string townName;
    public string businessName;
    public string rawName;
    public Sprite rawSpriteImage;
    public Sprite businessSprite;
    public Sprite rawSprite;
    public float timeForProduct;
    public float timeCurrent = 0;
    public bool isProductReady;
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

    private WaitForSeconds twoSeconds;
    public GameObject TownRawCanvas;
    void Awake()
    {
        twoSeconds = new WaitForSeconds(2f);
        if (isTown == true)
        {
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
    }
    private void Start()
    {
        CheckProductReady();
    }
    private void Update()
    {
        if (isProductReady == true)
        {
            timeCurrent += Time.deltaTime;
            if (timeCurrent > timeForProduct)
            {
                if (isTown == true)
                {
                    ChangeProduct(+productFromRaw);
                    ChangeRaw(-rawToProduct);
                    isProductReady = false;
                    timeCurrent = 0;
                    CheckProductReady();
                }
                else
                {
                    ChangeRaw(+rawToProduct);
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
        string msg;
        if (isTown == true)
        {
            if (rawCount >= rawToProduct)
            {
                if (productCount < maxStorageProduct && productCount+productFromRaw < maxStorageProduct)
                {
                    isProductReady = true;
                }
                else
                {
                    isProductReady = false;
                    msg = townName + " Storage is Full!";
                    MSG = Msg(msg);
                    StartCoroutine(MSG);
                    msg = null;
                }
            }
            else
            {
                isProductReady = false;
                msg = townName + " Raw is not enough. Need to make " + productFromRaw + " product: " + rawToProduct;
                MSG = Msg(msg);
                StartCoroutine(MSG);
                msg = null;
            }
        }
        else
        {
            if (rawCount < maxStorageRaw)
            {
                isProductReady = true;
            }
            else
            {
                isProductReady = false;
                MSG = Msg("Storage is Full!");
                StartCoroutine(MSG);
                msg = null;
            }
        }
        
    }
    private void ChangeProduct(float value)
    {
        productCount += value;
        //Debug.Log("Product Changed : " + value + " New Product: " + productCount);
    }
    private void ChangeRaw(float value)
    {
        rawCount += value;
        //Debug.Log("Raw Changed : " + value + " New Raw: " + rawCount);
    }
    private IEnumerator Msg(string msg)
    {
        //Debug.Log(msg);
        yield return twoSeconds;
        CheckProductReady();
    }
    public void OnMouseDown()
    {
        if (mainScript.isGamePaused == false)
        {
            if (mainScript.isBuildRailOpen == false)
            {
                if (mainScript.isTownRawInfoOpened == false)
                {
                    if(isTownRawOpen == false)
                        OpenTownRawInfo();
                }
            }
        }
    }
    public void CloseTownRawInfo()
    {
        TownRawCanvas.SetActive(false);

        mainScript.isTownRawInfoOpened = false;
        isTownRawOpen = false;
        mainScript.StopCoroutine(mainScript.camToTargetCoroutine);
    }
    public void OpenTownRawInfo()
    {
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
