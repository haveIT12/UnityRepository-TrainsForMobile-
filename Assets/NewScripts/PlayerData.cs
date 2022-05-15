using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public MainSceneScript mainScript;
    public float money;
    public float diamonds;
    private void Update()
    {
        coins.text = FormatNumsHelper.FormatNum(money);
    }
    public void AddCoins()
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
    }
}
