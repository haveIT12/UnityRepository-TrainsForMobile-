using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownRawScript : MonoBehaviour
{
    public bool isTown;
    public TownInfo townInfo;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;

    public int TownNumber;
    public string townName;
    public string businessName;
    public string rawName;
    public Sprite businessSprite;
    public Sprite rawSprite;

    public float maxStorageProduct;
    public float maxStorageRaw;

    public float[] upgradeCost;
    public float rawToProduct;
    public float productFromRaw;
    public float multiplier;
    public float productCount;
    public float rawCount;

    public GameObject TownRawCanvas;
    void Awake()
    {
        townName = townInfo.townName;
        businessName = townInfo.businessName;
        rawName = townInfo.rawName;
        businessSprite = townInfo.businessSprite;
        rawSprite = townInfo.rawSprite;
            
        maxStorageProduct = townInfo.maxStorageProduct;
            
        maxStorageRaw = townInfo.maxStorageRaw;
        upgradeCost = townInfo.upgradeCost;
        rawToProduct = townInfo.rawToProduct;
        productFromRaw = townInfo.productFromRaw;
        multiplier = townInfo.multiplier;
    }
    void Update()
    {
    }
    public void OpenTownRaw()
    {
    }
    public void CloseTownRaw()
    {
        
    }
}
