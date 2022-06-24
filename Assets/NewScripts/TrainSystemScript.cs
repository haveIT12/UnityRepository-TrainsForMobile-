using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSystemScript : MonoBehaviour
{
    [Header("Links")]
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public TownRawManager trManager;
    public TrainScript tScript;
    public List<GameObject> train;
    public TrainInfo[] tInfo;
    [Space]
    public GameObject[] trainShopElements;
    public GameObject prefElementDepot;
    public GameObject contentDepot;
    public GameObject[] trainPrefab;
    [Space]
    [Header("Other")]
    public WagonScript[] wagonPref;
    public float bottomsize;
    public bool isTrainSelectDepot;
    [Space]
    [Header("Colors")]
    public Color[] hpcolor;
    public Color colorSelect;
    public Color colorNeutral;
    public Color colorSecondNeutral;
    public Color[] colorTypeTrain; // 0-universal 1-freight 2-passenger
    public void OpenTrainMenu()
    {
        if(tScript != null)
            uiScript.OpenTrainMenu(tScript);
    }
    public void BuyTrain(int id)
    {
        if (mainScript.pData.money >= tInfo[id].priceTrain)
        {
            if (train.Count < 20)
            {
                if (train.Count >= 8)
                {
                    bottomsize += 83f;
                    uiScript.contentDepot.offsetMin = new Vector2(0, -bottomsize);
                }
                train.Add(Instantiate(trainPrefab[id], gameObject.transform));
                tScript = train[train.Count - 1].GetComponent<TrainScript>();
                train[train.Count - 1].GetComponent<TrainScript>().AddDepotElement();
                mainScript.pData.ChangeMoney(gameObject, -tInfo[id].priceTrain);
                uiScript.CheckUnlockedTrains();
                uiScript.CloseMenu();
                //mainScript.SelectTrainWay();
                trManager.OpenAll();
                trManager.train = train[train.Count-1];
                mainScript.camToTargetCoroutine = mainScript.CamToTarget(trManager.gameObject, true, 15f);
                mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
            }
            else
                Debug.Log("Too Much Trains");

        }

    }
    public void CloseElementDepot()
    {
        if (train.Count != 0)
        {
            for (int i = 0; i < train.Count; i++)
            {
                if (train[i].GetComponent<TrainScript>().isTrainSelectDepot == true)
                {
                    train[i].GetComponent<TrainScript>().CloseElementDepot();
                }
            }
        }
    }
    public void SelectElementDepot(TrainScript TrainScr)
    {
        for (int i = 0; i < train.Count; i++)
        {
            if (train[i].GetComponent<TrainScript>().isTrainSelectDepot == true)
            {
                train[i].GetComponent<TrainScript>().CloseElementDepot();
            }
        }
        TrainScr.SelectThis();
        tScript = TrainScr;
    }
    public void BuyWagon(string type)
    {
        for (int i = 0; i < wagonPref.Length; i++)
        {
            if (mainScript.pData.money >= wagonPref[i].price)
            {
                mainScript.pData.ChangeMoney(wagonPref[i].gameObject, -wagonPref[i].price);
                tScript.BuyWagon(type);
                uiScript.CloseWagonBuyMenu();
                return;
            }
            else
                uiScript.wagonButtonBuy[i].interactable = false;
        }
    }
    public void Move() => tScript.Move();
}
