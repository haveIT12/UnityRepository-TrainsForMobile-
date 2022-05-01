using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailwaySystem : MonoBehaviour
{
    public MainCamera mCam;
    public Vector3[] posforTable;
    public Vector3[] posToMove;
    public MainScript mScript;
    public Road road;
    public GameObject[] rw;
    public GameObject empty;
    public UIScript uS;
    public bool isMoveToRail;
    public float speedMove;
    private void Update()
    {
        if (isMoveToRail == true)
        {
            mCam.cameraTarget.transform.position = Vector3.Lerp(mCam.cameraTarget.transform.position, posToMove[mScript.road.roadNumber], Time.deltaTime * speedMove);
        }
    }
    public void OpenBuild()
    {
        rw[0].SetActive(true);
        rw[1].SetActive(true);
        rw[2].SetActive(true);
        rw[3].SetActive(true);
        rw[4].SetActive(true);
    }
    public void CloseBuild()
    {
        if (mScript.isRoadSelect == true)
        {
            if (mScript.road.gameObject.tag != "BuildedRoad")
            {
                mScript.road.SelectCansel();

            }
        }
        rw[0].SetActive(false);
        rw[1].SetActive(false);
        rw[2].SetActive(false);
        rw[3].SetActive(false);
        rw[4].SetActive(false);
        isMoveToRail = false;
    }
    public void BuyRailRoad()
    {
        if (mScript.road.price <= mScript.coins)
        {
            mScript.MinusCoinsPlay();
            mScript.coins -= mScript.road.price;
            uS.mcoins.text = "-" + FormatNumsHelper.FormatNum(mScript.road.price);
            mScript.road.rend.material = mScript.road.mat[2];
            mScript.roadNumber = mScript.road.roadNumber;
            rw[mScript.roadNumber] = empty;
            mScript.road.gameObject.tag = "BuildedRoad";
            uS.ui[7].SetActive(false);
            uS.ui[7].gameObject.GetComponent<Animator>().enabled = false;
            mScript.uiS.ui[2].SetActive(false);
            isMoveToRail = false;
        }
        else
        {
            Debug.Log("You have not money!");
            mScript.isRoadSelect = false;
            uS.ui[7].SetActive(false);
            uS.ui[7].gameObject.GetComponent<Animator>().enabled = false;
            mScript.SelectCansel();
        }
    }
}
