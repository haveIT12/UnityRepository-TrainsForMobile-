using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceListItemScript : MonoBehaviour
{
    [SerializeField] private PriceManager pManager;
    [SerializeField] private PriceListScript pList;
    [SerializeField] private Image imageElement;
    [SerializeField] private TextMeshProUGUI nameElement;
    [SerializeField] public TextMeshProUGUI growPriceElement;
    [SerializeField] public TextMeshProUGUI decreasePriceElement;
    [SerializeField] public TextMeshProUGUI differentText;
    public TextMeshProUGUI priceElement;
    [SerializeField] private Image currencyImage;
    [SerializeField] private GameObject mask;

    [SerializeField] private bool isThisTypeOpen;
    public string _name;
    [SerializeField] private float _newPrice;
    [SerializeField] private Sprite _currency;
    [SerializeField] private Sprite _image;
    [SerializeField] private float _price;
    public GameObject changeImageGrow;
    public GameObject changeImageDecrease;
    private void Awake()
    {
        //pManager = FindObjectOfType<PriceManager>();
    }
    public void GetPrice()
    {
        _price = pManager.GetPrice(_name);
    }
    public void Open()
    {
        if (isThisTypeOpen)
            mask.SetActive(false);
        else
            mask.SetActive(true);
        GetPrice();
        imageElement.sprite = _image;
        nameElement.text = _name;
        priceElement.text = FormatNumsHelper.FormatNum(_price);
        currencyImage.sprite = _currency;
        if (pManager.gameObject.GetComponent<PriceListScript>().timesOfUpdate != 0)
        {
            differentText.gameObject.GetComponent<Animator>().enabled = true;
            differentText.gameObject.SetActive(true);
        }
        else
            differentText.gameObject.SetActive(false);
    }
    public void CheckDifference(float count)
    {
        if (isThisTypeOpen)
        {
            string different;
            if (_price * count >= _price)
            {
                different = "+" + FormatNumsHelper.FormatNum(Mathf.RoundToInt(_price * count) - _price);
                changeImageGrow.SetActive(true);
                differentText.color = Color.green;
            }
            else
            {
                different = "-" + FormatNumsHelper.FormatNum(_price - Mathf.RoundToInt(_price * count));
                changeImageDecrease.SetActive(true);
                differentText.color = Color.red;
            }
            differentText.gameObject.SetActive(false);
            differentText.text = different;
            differentText.gameObject.GetComponent<Animator>().enabled = true;
            differentText.gameObject.SetActive(true);
        }
    }
}
