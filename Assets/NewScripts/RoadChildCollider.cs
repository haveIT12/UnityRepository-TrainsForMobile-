using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChildCollider : MonoBehaviour
{
    public RailRoadScript rScript;
    public void OnMouseDown()
    {
        if (rScript.mainScript.isBuildRailOpen == true)
        {
            if (rScript.isRailBuild == false)
            {
                if (rScript.isRailSelected == false)
                { 
                    rScript.RoadSelect();
                }
            }
        }
    }
}
