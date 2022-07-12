using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public MainSceneScript mainScript;
    public float money;
    public float newMoney;
    public float tickets;
    public float newTickets;
    public bool[] trainUnlocked;
    private void Update()
    {
        if (money != newMoney)
        {
            money = Mathf.Lerp(money, newMoney, 3f * Time.deltaTime);
        }
        if (tickets != newTickets)
        {
            tickets = Mathf.Lerp(tickets, newTickets, 3f * Time.deltaTime);
        }
    }
    public void ChangeMoney(GameObject sender, float count)
    {
        newMoney += count;
        CheckManuValues();
        //Debug.Log("Money " + count + "From: " + sender + "Balance: " + newMoney);
    }
    public void ChangeTickets(GameObject sender, float count)
    {       
        newTickets += count;
        CheckManuValues();
        //Debug.Log("Tickets " + count + "From: " + sender + "Balance: " + newTickets);
    }
    public void ChangeTrainState(int numTrain, bool openOrClose)
    {
        if (numTrain <= trainUnlocked.Length)
        {
            if (openOrClose == true)
            {
                trainUnlocked[numTrain] = true;
                Debug.Log("Train: " + numTrain + " unlocked!");
            }
            else
            {
                trainUnlocked[numTrain] = false;
                Debug.Log("Train: " + numTrain + " locked!");
            }
        }
        else
            Debug.LogWarning("Wrong NumberOfTrain! Enterred number: " + numTrain + " Max Train: " + trainUnlocked.Length);
        mainScript.uiScript.CheckUnlockedTrains();
    }
    private void CheckManuValues()
    {
        if (mainScript.isTrainShopOpen)
            mainScript.uiScript.CheckUnlockedTrains();
        else if (mainScript.uiScript.idMenu == 3)
        {
            mainScript.uiScript.CheckTrainUpgrade(mainScript.uiScript.tsScript.tScript);
            if (mainScript.uiScript.isRepairMenuOpen)
                mainScript.uiScript.UpdateRepairInfo();
            else if (mainScript.uiScript.isSellMenuOpen)
                mainScript.uiScript.UpdateInfoSellMenuTrain();
            else if (mainScript.uiScript.isWagonBuyMenuOpen)
                mainScript.uiScript.UpdateWagonBuyMenu();
        }
    }
}
