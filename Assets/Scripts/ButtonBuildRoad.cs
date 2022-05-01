using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuildRoad : MonoBehaviour
{
    public MainScript mScript;
    public GameObject[] btnBuildRoad;
    public void isBuildRoaddOpen()
    {
        btnBuildRoad[0].SetActive(false);
        btnBuildRoad[1].SetActive(true);
        btnBuildRoad[2].SetActive(true);
        mScript.isBuildRoad = true;
    }
    public void isBuildRoaddClose()
    {
        btnBuildRoad[0].SetActive(true);
        btnBuildRoad[1].SetActive(false);
        btnBuildRoad[2].SetActive(false);
        mScript.isBuildRoad = false;
    }
}
