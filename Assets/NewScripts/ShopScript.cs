using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private List<ShopItemScript> _item;
    public MainSceneScript mainScript;
    [Space]
    [Header("New Values")]
    [SerializeField] private float[] newDamageFromRail;
    [SerializeField] private float[] newChanceDamageFromRail;
    [SerializeField] private float[] newExtraSpeed;
    [SerializeField] private float[] newExtraWagonSize;
    [SerializeField] private float[] newExtraProductionTime;
    private void Awake()
    {
        for (int i = 0; i < _item.Count; i++)
            _item[i].Init();
    }
    public float GetDataFromItem(float count, string name, int lvl)
    {
        switch (name)
        {
            case "Damage":
                {
                    mainScript.GetDataShop(name, newDamageFromRail[lvl]);
                    return newDamageFromRail[lvl];
                }
            case "ChanceDamage":
                {
                    mainScript.GetDataShop(name, newChanceDamageFromRail[lvl]);
                    return newChanceDamageFromRail[lvl];
                }
            case "ExtraSpeed":
                {
                    mainScript.GetDataShop(name, newExtraSpeed[lvl]);
                    return newExtraSpeed[lvl];
                }
            case "ExtraWagonsSize":
                {
                    mainScript.GetDataShop(name, newExtraWagonSize[lvl]);
                    return newExtraWagonSize[lvl];
                }
            case "ExtraProductionTime":
                {
                    mainScript.GetDataShop(name, newExtraProductionTime[lvl]);
                    return newExtraProductionTime[lvl];
                }
        }
        return count;
    }
    public void OpenShop()
    {
        for (int i = 0; i < _item.Count; i++)
            _item[i].Init();
    }
    public void CheckUpgrade()
    {
        for (int i = 0; i < _item.Count; i++)
            _item[i].CheckUpgrade();
    }
}
