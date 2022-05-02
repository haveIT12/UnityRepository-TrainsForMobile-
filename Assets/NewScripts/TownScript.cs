using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownScript : MonoBehaviour
{
    public TownInfo townInfo;
    public string townName => townInfo.townName;
    private string businessName => townInfo.businessName;
    private string rawName => townInfo.rawName;

    private Sprite businessSprite => townInfo.businessSprite;
    private Sprite rawSprite => townInfo.rawSprite;

    [SerializeField]
    public int maxStorageProduct => townInfo.maxStorageProduct;
    [SerializeField]
    public int maxStorageRaw => townInfo.maxStorageRaw;
    private int[] upgradeCost => townInfo.upgradeCost;
    private int rawToProduct => townInfo.rawToProduct;
    private int productFromRaw => townInfo.productFromRaw;
    private float multiplier => townInfo.multiplier;

    public int productCount;
    public int rawCount;


    public TextMeshProUGUI townNameText;
    public TextMeshProUGUI businessNameText;
    public TextMeshProUGUI rawToProductText;
    public TextMeshProUGUI productFromRawText;
    public TextMeshProUGUI newRawToProductText;
    public TextMeshProUGUI newProductFromRawText;
    public TextMeshProUGUI productCountText;
    public TextMeshProUGUI rawCountText;

    public Image publicBussinessSprite;
    public Image publicRawSprite;
    public Image publicBussinessSprite1;
    public Image publicRawSprite1;
    public Image publicBussinessSprite2;
    public Image publicRawSprite2;
    public Image productFullBar;
    public Image rawFullBar;

    void Start()
    {
        

    }

    void Update()
    {
        townNameText.text = townName;
        businessNameText.text = businessName;
        rawToProductText.text = rawToProduct.ToString();
        productFromRawText.text = productFromRaw.ToString();
        newRawToProductText.text = (rawToProduct - 10).ToString();
        newProductFromRawText.text = (productFromRaw + 10).ToString();
        productCountText.text = productCount.ToString();
        rawCountText.text = rawCount.ToString();

        publicBussinessSprite.sprite = businessSprite;
        publicBussinessSprite1.sprite = businessSprite;
        publicBussinessSprite2.sprite = businessSprite;
        publicRawSprite.sprite = rawSprite;
        publicRawSprite1.sprite = rawSprite;
        publicRawSprite2.sprite = rawSprite;
        productFullBar.fillAmount = productCount / maxStorageProduct;
        rawFullBar.fillAmount = rawCount / maxStorageRaw;
    }
}
