using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrainInDepot : MonoBehaviour
{
    public TrainScript tScript;
    public void Select()
    {
        if (!tScript.isTrainSelectDepot)
            tScript.tsScript.SelectElementDepot(tScript);
        else
            tScript.CloseElementDepot();
    }
    public void This(TrainScript ts)
    {
        tScript = ts;
    }
}
