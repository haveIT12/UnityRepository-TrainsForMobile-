using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRoadScript : MonoBehaviour
{
    public RailRoadSystemScript rsScript;
    public GameObject toCam;
    public Material[] mat; // 0 - normal material, 1 - neutral material 2- selected material;
    public bool isRailBuild;
    public bool isRailSelected;

    public string path;
    public float price;
    public void Spawn(int colorNumber)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material = mat[colorNumber];
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void RoadSelect()
    {
        gameObject.tag = "RoadSelected";
        isRailSelected = true;
        gameObject.GetComponent<MeshRenderer>().material = mat[2];
    }
    public void CloseSelect(string tagName, int materialNubmer)
    {
        gameObject.tag = tagName;
        isRailSelected = false;
        gameObject.GetComponent<MeshRenderer>().material = mat[materialNubmer];
    }
}
