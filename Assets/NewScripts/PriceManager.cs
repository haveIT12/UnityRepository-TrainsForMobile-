using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData pData;
    [Header("Raw")]
    [SerializeField]
    private float wheatPrice;
    [SerializeField]
    private float milkPrice;
    [SerializeField]
    private float fishPrice;
    [SerializeField]
    private float woodPrice;
    [SerializeField]
    private float ironOrePrice;
    [SerializeField]
    private float coalOrePrice;                 
    [SerializeField]
    private float meatPrice;                    
    [SerializeField]
    private float oilPrice;                     
    [SerializeField]
    private float sugarPrice;                   
    [SerializeField]
    private float ironPrice;                    
    [SerializeField]
    private float linenAndCottonPrice;          
    [SerializeField]
    private float vegetablesPrice;

    [Space]
    [Header("Product")]
    [SerializeField]
    private float planksPrice;
    [SerializeField]
    private float breadPrice;                      
    [SerializeField]
    private float clothPrice;                     
    [SerializeField]
    private float coalPrice;                       
    [SerializeField]
    private float dieselPrice;                     
    [SerializeField]
    private float furniturePrice;

    [Space]
    [Header("Passenger")]
    [SerializeField]
    private float passengerPrice;

    private float totalPrice;
    private void CheckPrice(string whatCheck, float count)
    {
        totalPrice = 0;
        switch (whatCheck)
        {
            case "Wheat":
                {
                    totalPrice = wheatPrice * count;
                    break;
                }
            case "Bread":
                {
                    totalPrice = breadPrice * count;
                    break;
                }
            case "Wood":
                {
                    totalPrice = woodPrice * count;
                    break;
                }
            case "Planks":
                {
                    totalPrice = planksPrice * count;
                    break;
                }
            case "Passenger":
                {
                    totalPrice = passengerPrice * count;
                    break;
                }
        }
    }
    public void Sell(WagonScript sender, float count, string whatSell)
    {
        CheckPrice(whatSell, count);
        sender.totalPrice = totalPrice;
        pData.ChangeMoney(sender.gameObject, totalPrice);
    }
}
