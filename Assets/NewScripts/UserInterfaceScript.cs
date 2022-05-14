using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{
    public MainSceneScript mainScript;
    public TownRawScript townRawScript;
    [Header("TownUI")]
    public GameObject canvasCity;
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
        if (mainScript.isTownRawOpened == true)
        {
            Debug.Log("1");
            productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
            rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
            productFullBar.fillAmount = mainScript.townScript.productCount / mainScript.townScript.maxStorageProduct;
            rawFullBar.fillAmount = mainScript.townScript.rawCount / mainScript.townScript.maxStorageRaw;
        }
    }
    public void OpenTownRawInfo()
    {
        townRawScript.rawCount.ToString();
        townRawScript.TownRawCanvas.SetActive(true);
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
        newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.rawToProduct - 10f));
        newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.productFromRaw + 10f));
        productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
        rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
        productFullBar.fillAmount = townRawScript.productCount / townRawScript.maxStorageProduct;
        rawFullBar.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
    }
    public void CloseTownRawInfo()
    {
        mainScript.townScript.TownRawCanvas.SetActive(false);
    }
    public void OpenTownRaw()
    {
        canvasCity.SetActive(true);
    }
    public void CloseTownRaw()
    {
        canvasCity.SetActive(false);
    }
}
