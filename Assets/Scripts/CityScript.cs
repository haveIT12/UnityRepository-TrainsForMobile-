using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using TMPro;

public class CityScript : MonoBehaviour
{
    private SpriteRenderer sRend;

    public GameObject[] ui;
    public GameObject[] empty;

    public Sprite[] business;
    public Sprite[] bCurrent;

    
    public MainScript mScript;
    public UIScript uS;

    public TextMeshProUGUI[] nameCity;
    public TextMeshProUGUI[] uitext; //0popul 1businesnametext 2cmusinesnametext  3upgradebefore 4upgradeafter 5storagebusiness 6storagecbisumess

    public string BusinessName;
    public string cBusinessName;
    public string mera;

    public int upgradeBusinessLvl;
    public float[] upgradeBusinessCost;
    public int upgradeStorageLvl;
    public float[] upgradeStorageCost;
    public int[] upglvlBusiness;

    public float storageProduct;
    public float storageRaw;
    public float storageProductMax;
    public float storageRawMax;

    public int CityNumber;
    public float population;
    public void Start()
    {
        if (upgradeBusinessLvl == 4)
        {
            uS.upgradeBusinessCost.text = "Max";
            uS.btn[0].interactable = false;
        }
        else if(upgradeBusinessLvl != 0)
            uS.upgradeBusinessCost.text = "Upgrade" + FormatNumsHelper.FormatNum(upgradeBusinessCost[upgradeBusinessLvl]) + "$";
    }
    public void Update()
    {
    }

    public void OpenButton()
    {
        nameCity[0].text = gameObject.name;
        sRend = ui[2].GetComponent<SpriteRenderer>();
        switch (BusinessName)
        {
            case "Bakery":
                {
                    sRend.sprite = business[0];
                    break;
                }
            case "Furniture Shop":
                {
                    sRend.sprite = business[0];
                    break;
                }
            case "Sawmill":
                {
                    sRend.sprite = business[0];
                    break;
                }
        }
        sRend = ui[1].GetComponent<SpriteRenderer>();
        switch (cBusinessName)
        {
            case "Farm":
                {
                    sRend.sprite = bCurrent[0];
                    break;
                }
            case "Forest":
                {
                    sRend.sprite = bCurrent[1];
                    break;
                }
            case "Planks":
                {
                    sRend.sprite = bCurrent[2];
                    break;
                }
        }
        gameObject.tag = "CurrentCity";
        mScript.isButtonOpen = true;
        ui[5].transform.localPosition = uS.posCityButton[CityNumber];
        ui[5].SetActive(true);
    }
    public void UpgradeBusiness()
    {
        if (upgradeBusinessLvl != 4)
        {
            if (mScript.coins >= upgradeBusinessCost[upgradeBusinessLvl])
            {
                mScript.coins -= upgradeBusinessCost[upgradeBusinessLvl];
                upgradeBusinessLvl++;
                uS.bar[0].fillAmount += 0.25f;
                uitext[3].text = upglvlBusiness[upgradeBusinessLvl].ToString() + mera;
                uitext[4].text = upglvlBusiness[upgradeBusinessLvl + 1].ToString() + mera;
                if (upgradeBusinessLvl == 4)
                {
                    uS.upgradeBusinessCost.text = "MAX";
                    uS.btn[0].interactable = false;
                }
                else
                    uS.upgradeBusinessCost.text = "Upgrade" + FormatNumsHelper.FormatNum(upgradeBusinessCost[upgradeBusinessLvl]) + "$";
            }
            else
                Debug.Log("You have not money");
        }
        else
            Debug.Log("MaxUpgradeLvl");
    }
    public void OpenCity()
    {
        uS.btn[0].interactable = true;
        uitext[3].text = upglvlBusiness[upgradeBusinessLvl].ToString() + mera;
        uitext[4].text = upglvlBusiness[upgradeBusinessLvl + 1].ToString() + mera;
        uitext[0].text = "Population: " + FormatNumsHelper.FormatNum(population);
        nameCity[1].text = gameObject.name;
        uitext[1].text = BusinessName;
        uS.bar[0].fillAmount = upgradeBusinessLvl / 4f;
        uS.bar[1].fillAmount = storageProduct / storageProductMax;
        uS.bar[2].fillAmount = storageRaw / storageRawMax;
        uitext[5].text = storageProduct.ToString() + "t";
        uitext[6].text = storageRaw.ToString() + "t";
        if (upgradeBusinessLvl == 4)
        {
            uS.upgradeBusinessCost.text = "MAX";
            uS.btn[0].interactable = false;
        }
        else
            uS.upgradeBusinessCost.text = "Upgrade" + FormatNumsHelper.FormatNum(upgradeBusinessCost[upgradeBusinessLvl]) + "$";
        /*switch (BusinessName)
        {
            case "Bakery":
                {
                    break;
                }
            case "////":
                {
                    break;
                }
        }
        switch (cBusinessName)
        {
            case "Farm":
                {
                    break;
                }
        }*/
    }
}
