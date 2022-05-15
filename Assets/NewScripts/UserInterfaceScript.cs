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



    void Start()
    {
        
    }
    void Update()
    {

        if (mainScript.isTownRawOpened == true)
        {
            if (townRawScript.isTown == true)
            {
                productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
                rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
                productFullBar.fillAmount = mainScript.townRawScript.productCount / mainScript.townRawScript.maxStorageProduct;
                rawFullBar.fillAmount = mainScript.townRawScript.rawCount / mainScript.townRawScript.maxStorageRaw;
                rawToProductFullBar.fillAmount = townRawScript.fullBar.fillAmount;
                if(townRawScript.upgradeLvl > 3){
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
            else
            {
                rawCountFirstText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
                rawFullBarFirst.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
                rawFullBarZero.fillAmount = townRawScript.fullBar.fillAmount;
            }

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
            newRawToProductText.text = FormatNumsHelper.FormatNum((townRawScript.newRawToProduct[townRawScript.upgradeLvl+1]));
            newProductFromRawText.text = FormatNumsHelper.FormatNum((townRawScript.newProductFromRaw[townRawScript.upgradeLvl+1]));
            productCountText.text = FormatNumsHelper.FormatNum(townRawScript.productCount);
            rawCountText.text = FormatNumsHelper.FormatNum(townRawScript.rawCount);
            productFullBar.fillAmount = townRawScript.productCount / townRawScript.maxStorageProduct;
            rawFullBar.fillAmount = townRawScript.rawCount / townRawScript.maxStorageRaw;
            if (townRawScript.upgradeLvl < 4)
            {
                upgradeButton.GetComponent<Image>().color = new Color(103, 103, 103);
                upgradeButton.interactable = false;
                upgradeCostText.text = FormatNumsHelper.FormatNum(townRawScript.upgradeCost[townRawScript.upgradeLvl]) + "$";
            }
            else
            {
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
    public void CloseTownRaw()
    {
        if (townRawScript.isTown == true)
            canvasTown.SetActive(false);
        else
            canvasRaw.SetActive(false);
    }
}
