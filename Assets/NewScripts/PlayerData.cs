using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TasksSystemScript taskSystem;
    public MainSceneScript mainScript;
    public float money;
    [SerializeField] private float newMoney;
    public float tickets;
    [SerializeField] private float newTickets;
    public bool[] trainUnlocked;
    private float elapsedTimeTickets;
    private float elapsedTimeMoney;
    private float timer = 3f;
    private void Update()
    {
        if (money != newMoney)
        {
            elapsedTimeMoney += Time.deltaTime;
            float perc = elapsedTimeMoney / timer;
            money = Mathf.Lerp(money, newMoney, Mathf.SmoothStep(0, 1, perc));
        }
        if (tickets != newTickets)
        {
            elapsedTimeTickets += Time.deltaTime;
            float percc = elapsedTimeTickets / timer;
            tickets = Mathf.Lerp(tickets, newTickets, Mathf.SmoothStep(0,1, percc));
        }
    }
    public void ChangeMoney(GameObject sender, float count)
    {

        if (newMoney + count >= newMoney)
        {
            if (sender.TryGetComponent(out TaskElementScript te) == false)
                taskSystem.GetInfo(this, count, "Money", true);
        }
        else
            taskSystem.GetInfo(this, count, "Money", false);
        elapsedTimeMoney = 0;
        newMoney += count;
        CheckManuValues();
        //Debug.Log("Money " + count + "From: " + sender + "Balance: " + newMoney);
    }
    public void ChangeTickets(GameObject sender, float count)
    {
        if (newTickets + count >= newTickets)
        {
            if (sender.TryGetComponent(out TaskElementScript te) == false)
                taskSystem.GetInfo(this, count, "Tickets", true);
        } 
        else
            taskSystem.GetInfo(this, count, "Tickets", false);
        /*if (sender.name != "TaskElement")
        {
            Debug.Log(sender.name);
            if (newTickets + count >= newTickets)
                taskSystem.GetInfo(this, count, "Tickets", true);
            else
                taskSystem.GetInfo(this, count, "Tickets", false);
        }*/
        elapsedTimeTickets = 0;
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
        switch (mainScript.uiScript.idMenu)
        {
            case 3:
                {
                    mainScript.uiScript.CheckTrainUpgrade(mainScript.uiScript.tsScript.tScript);
                    if (mainScript.uiScript.isRepairMenuOpen)
                        mainScript.uiScript.UpdateRepairInfo();
                    else if (mainScript.uiScript.isSellMenuOpen)
                        mainScript.uiScript.UpdateInfoSellMenuTrain();
                    else if (mainScript.uiScript.isWagonBuyMenuOpen)
                        mainScript.uiScript.UpdateWagonBuyMenu();
                    break;
                }
            case 5:
                {
                    mainScript.uiScript.pList.CheckPassenger();
                    break;
                }
            case 6:
                {
                    mainScript.uiScript.sScript.CheckUpgrade();
                    break;
                }
        }
    }
    public bool CheckValue(float value, bool isTicket)
    {
        if (isTicket)
        {
            if (value <= newTickets)
                return true;
        }
        else
        {
            if (value <= newMoney)
                return true;
        }
        return false;
    }
}
