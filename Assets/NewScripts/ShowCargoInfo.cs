using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowCargoInfo : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI textPrice;
    public TextMeshProUGUI textTickets;
    public Image moneyImage;
    public Image ticketsImage;
    public TrainScript tScript;
    public void ShowInfoTrain(TrainScript train, float price, bool isTicket, float tickets = 0)
    {
        ticketsImage.gameObject.SetActive(false);
        textTickets.gameObject.SetActive(false);
        if (isTicket)
        {
            ticketsImage.gameObject.SetActive(true);
            textTickets.gameObject.SetActive(true);
            textTickets.text = "+" + FormatNumsHelper.FormatNum(tickets);
        }
        textPrice.text = "+" + FormatNumsHelper.FormatNum(price);
    }
    public void HideInfo()
    {
        canvas.SetActive(false);
    }
}
