using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Road : MonoBehaviour
{
    public RailwaySystem rS;
    public TextMeshProUGUI pricet;
    public Renderer rend;
    public GameObject[] path;
    public Material[] mat;
    public UIScript uS;
    public float price;
    public int roadNumber;
    public string roadpath;
    void Start()
    {
        uS.ui[7].gameObject.GetComponent<Animator>().enabled = false;
        rend = GetComponent<Renderer>();
    }
    public void SelectRoad()
    {
        Debug.Log("1");
        rS.isMoveToRail = true;
        uS.ui[7].transform.localPosition = rS.posforTable[roadNumber];
        uS.ui[7].SetActive(true);
        uS.ui[7].gameObject.GetComponent<Animator>().enabled = true;
        uS.ui[8].SetActive(false);
        uS.ui[8].gameObject.GetComponent<Animator>().enabled = false;
        pricet.text = FormatNumsHelper.FormatNum(price) + "$";
        gameObject.tag = "CurrentRoad";
        rend.material = mat[1];
        Debug.Log("2");
    }
    public void SelectCansel()
    {
        uS.ui[7].SetActive(false);
        uS.ui[7].gameObject.GetComponent<Animator>().enabled = false;
        if (gameObject.tag == "CurrentRoad")
        { 
            gameObject.tag = "Road";
            rend.material = mat[0];
        }
        rS.isMoveToRail = false;
    }
}
