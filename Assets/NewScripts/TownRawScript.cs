using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownRawScript : MonoBehaviour
{
    public TownInfo townInfo;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
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

    public GameObject TownRawCanvas;
    void Awake()
    {
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
    void FixedUpdate()
    {
        fullBar.fillAmount = timeCurrent / timeForProduct;
    }
    public void OpenTownRawInfo()
    {
        TownRawCanvas.SetActive(true);
        townNameText.text = townName;
        publicRawSprite.sprite = rawSprite;
        if (isTown == true)
            publicBussinessSprite.sprite = businessSprite;
    }
    public void CloseTownRawInfo()
    {
        TownRawCanvas.SetActive(false);
    }
    public void Upgrade()
    {
        if (isTown == true)
        {
            if (upgradeLvl <= 3)
            {
                if (mainScript.pData.money >= upgradeCost[upgradeLvl])
                {
                    mainScript.pData.money -= upgradeCost[upgradeLvl];
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
        if (isTown == true)
        {
            if (rawCount >= rawToProduct)
            {
                if (productCount < maxStorageProduct && productCount+productFromRaw < maxStorageProduct)
                {
                    RTP = RawToProduct();
                    StartCoroutine(RTP);
                }
                else
                {
                    MSG = Msg(2, townName + " Storage is Full!");
                    StartCoroutine(MSG);
                }
            }
            else
            {
                MSG = Msg(2, townName + " Raw is not enough. Need to make " + productFromRaw + " product: " + rawToProduct);
                StartCoroutine(MSG);
            }
        }
        else
        {
            if (rawCount < maxStorageRaw)
            {
                RTP = RawToProduct();
                StartCoroutine(RTP);
            }
            else
            {
                MSG = Msg(2, "Storage is Full!");
                StartCoroutine(MSG);
            }
        }
        
    }
    private void ChangeProduct(float value)
    {
        productCount += value;
        Debug.Log("Product Changed : " + value + " New Product: " + productCount);
    }
    private void ChangeRaw(float value)
    {
        rawCount += value;
        Debug.Log("Raw Changed : " + value + " New Raw: " + rawCount);
    }
    private IEnumerator RawToProduct()
    {
        if (isTown == true)
        {
            for (timeCurrent = 0; timeCurrent < timeForProduct; timeCurrent += Time.deltaTime)
            {
                yield return new WaitForSeconds(Time.deltaTime);
            }
            ChangeProduct(+productFromRaw);
            ChangeRaw(-rawToProduct);
            timeCurrent = 0;
            CheckProductReady();
        }
        else
        {
            for (timeCurrent = 0; timeCurrent < timeForProduct; timeCurrent += Time.fixedDeltaTime)
            {
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            timeCurrent = 0;
            ChangeRaw(+rawToProduct);
            CheckProductReady();
        }

    }
    private IEnumerator Msg(float value, string msg)
    {
        Debug.Log(msg);
        yield return new WaitForSeconds(value);
        CheckProductReady();
    }
}
