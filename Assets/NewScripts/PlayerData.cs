using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public MainSceneScript mainScript;
    public float money;
    public float tickets;
    public bool[] trainUnlocked;
    public void ChangeMoney(GameObject sender, float count)
    {
        money += count;
        Debug.Log("Money " + count + "From: " + sender + "Balance: " + money);
    }
    public void ChangeTickets(GameObject sender, float count)
    {
        tickets += count;
        Debug.Log("Tickets " + count + "From: " + sender + "Balance: " + tickets);
    }
    /*public void AddCoins()
    {
        money += 1000f;
    }
    public void Resett()
    {
        mainScript.townRawScript.upgradeLvl = 0;
        mainScript.townRawScript.productFromRaw = mainScript.townRawScript.newProductFromRaw[mainScript.townRawScript.upgradeLvl];
        mainScript.townRawScript.rawToProduct = mainScript.townRawScript.newRawToProduct[mainScript.townRawScript.upgradeLvl];
    }
    public void AddRawToTown()
    {
        if (mainScript.townRawScript.isTown == true)
        {
            mainScript.townRawScript.rawCount += 500f;
        }
    }*/
}
