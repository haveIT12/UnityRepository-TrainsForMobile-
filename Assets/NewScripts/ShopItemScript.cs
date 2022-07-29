using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private ShopScript sScript;
    [SerializeField] private string _name;
    [SerializeField] private float _count;
    [SerializeField] private string _info;
    [SerializeField] private string _info2;
    [SerializeField] private int _currentLvl;
    [SerializeField] private int _maxLvl;
    [SerializeField] private float[] _price;
    [SerializeField] private bool[] _isTicket;
    public Image[] abilityImageEmpty;
    public Image[] abilityImageFull;
    /////////TMP
    [SerializeField] private Image _currencyImage;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI priceText;
    public void Init()
    {
        _count = sScript.GetDataFromItem(_count, _name, _currentLvl);
        CheckAbility();
        CheckUpgrade();
        if (_isTicket[_currentLvl])
            _currencyImage.sprite = sScript.mainScript.uiScript.currencyTickets;
        else
            _currencyImage.sprite = sScript.mainScript.uiScript.currencyMoney;
        countText.text = _info + _count.ToString() + _info2;
        priceText.text = FormatNumsHelper.FormatNum(_price[_currentLvl]);
    }
    public void Upgrade()
    {
        if (_currentLvl < _maxLvl)
        {
            if (_isTicket[_currentLvl])
            {
                if (sScript.mainScript.pData.CheckValue(_price[_currentLvl], true))
                    sScript.mainScript.pData.ChangeTickets(this.gameObject, -_price[_currentLvl]);
                else
                    return;
            }
            else
            {
                if (sScript.mainScript.pData.CheckValue(_price[_currentLvl], false))
                    sScript.mainScript.pData.ChangeMoney(this.gameObject, -_price[_currentLvl]);
                else
                    return;
            }
            _currentLvl++;
            CheckAbility();
            CheckUpgrade();
            _count = sScript.GetDataFromItem(_count, _name, _currentLvl);
            Init();
        }
    }
    public void CheckAbility()
    {
        for (int i = 0; i < abilityImageFull.Length; i++)
            abilityImageFull[i].gameObject.SetActive(false);
        for (int i = 0; i < _currentLvl; i++)
            abilityImageFull[i].gameObject.SetActive(true);
    }
    public void CheckUpgrade()
    {
        if (_currentLvl >= _maxLvl)
        {
            priceText.gameObject.SetActive(false);
            _currencyImage.gameObject.SetActive(false);
            upgradeButton.interactable = false;
            return;
        }
        else
        {
            priceText.gameObject.SetActive(true);
            _currencyImage.gameObject.SetActive(true);
        }
        if (_isTicket[_currentLvl])
        {
            if (sScript.mainScript.pData.CheckValue(_price[_currentLvl], true))
                upgradeButton.interactable = true;
            else
                upgradeButton.interactable = false;
        }
        else
        {
            if (sScript.mainScript.pData.CheckValue(_price[_currentLvl], false))
                upgradeButton.interactable = true;
            else
                upgradeButton.interactable = false;
        }
    }
}
