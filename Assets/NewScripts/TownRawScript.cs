using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownRawScript : MonoBehaviour
{
    public bool isTown;
    public TownInfo townInfo;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;

    public int TownNumber;
    public string townName;
    private string businessName;
    private string rawName;
    private Sprite businessSprite;
    private Sprite rawSprite;

    [SerializeField]
    public int maxStorageProduct;
    [SerializeField]
    public int maxStorageRaw;

    private int[] upgradeCost;
    private int rawToProduct;
    private int productFromRaw;
    private float multiplier;

    [SerializeField]
    public int productCount;
    [SerializeField]
    public int rawCount;

    public GameObject TownRawCanvas;
    void Start()
    {
        if (mainScript.isNewGame == true)
        {
            townName = townInfo.townName;
            businessName = townInfo.businessName;
            rawName = townInfo.rawName;
            businessSprite = townInfo.businessSprite;
            rawSprite = townInfo.rawSprite;
            
            maxStorageProduct = townInfo.maxStorageProduct;
            
            maxStorageRaw = townInfo.maxStorageRaw;
            upgradeCost = townInfo.upgradeCost;
            rawToProduct = townInfo.rawToProduct;
            productFromRaw = townInfo.productFromRaw;
            multiplier = townInfo.multiplier;
        }
        uiScript.townNameText.text = townName;
        uiScript.businessNameText.text = businessName;
        uiScript.publicBussinessSprite.sprite = businessSprite;
        uiScript.publicBussinessSprite1.sprite = businessSprite;
        uiScript.publicBussinessSprite2.sprite = businessSprite;
        uiScript.publicRawSprite.sprite = rawSprite;
        uiScript.publicRawSprite1.sprite = rawSprite;
        uiScript.publicRawSprite2.sprite = rawSprite;
    }
    void Update()
    {
        uiScript.rawToProductText.text = rawToProduct.ToString();
        uiScript.productFromRawText.text = productFromRaw.ToString();
        uiScript.newRawToProductText.text = (rawToProduct - 10).ToString();
        uiScript.newProductFromRawText.text = (productFromRaw + 10).ToString();
        uiScript.productCountText.text = productCount.ToString();
        uiScript.rawCountText.text = rawCount.ToString();

        uiScript.productFullBar.fillAmount = productCount / maxStorageProduct;
        uiScript.rawFullBar.fillAmount = rawCount / maxStorageRaw;
    }
    public void OpenTownRaw()
    {
        uiScript.townNameText.text = townName;
        uiScript.businessNameText.text = businessName;
        uiScript.publicBussinessSprite.sprite = businessSprite;
        uiScript.publicBussinessSprite1.sprite = businessSprite;
        uiScript.publicBussinessSprite2.sprite = businessSprite;
        uiScript.publicRawSprite.sprite = rawSprite;
        uiScript.publicRawSprite1.sprite = rawSprite;
        uiScript.publicRawSprite2.sprite = rawSprite;
        uiScript.rawToProductText.text = rawToProduct.ToString();
        uiScript.productFromRawText.text = productFromRaw.ToString();
        uiScript.newRawToProductText.text = (rawToProduct - 10).ToString();
        uiScript.newProductFromRawText.text = (productFromRaw + 10).ToString();
        uiScript.productCountText.text = productCount.ToString();
        uiScript.rawCountText.text = rawCount.ToString();

        uiScript.productFullBar.fillAmount = productCount / maxStorageProduct;
        uiScript.rawFullBar.fillAmount = rawCount / maxStorageRaw;
    }
    public void CloseTownRaw()
    {
        
    }
}
