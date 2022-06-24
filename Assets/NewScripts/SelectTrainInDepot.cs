using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrainInDepot : MonoBehaviour
{
    public TrainScript tScript;
    private void Start()
    {
    }
    public void Select()
    {
        tScript.tsScript.SelectElementDepot(tScript);
    }
    public void This(TrainScript ts)
    {
        tScript = ts;
    }
    /*public void SelectThis()
    {
        mask.SetActive(true);
        uiScript.trainDepotImage.sprite = train.trainSprite;
        uiScript.nameTrainDepot.text = train.trainName;
        uiScript.speedTrainDepot.text = train.maxSpeed.ToString();
        uiScript.trainDepotImage.sprite = train.trainSprite;
        for (int i = 0; train.wagon.Length <= i; i++)
        {
            if (train.wagon[i] == true)
            {
                uiScript.wagonDepot[i].gameObject.SetActive(true);
                uiScript.wagonDepot[i].sprite = train.wagons[i];
            }
            else
                Debug.Log(i + " null");
        }
    }*/
}
