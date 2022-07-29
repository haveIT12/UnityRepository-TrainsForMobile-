using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownRawManager : MonoBehaviour
{
    public List<TownRawScript> town;
    public List<TownRawScript> selectedTown;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public TrainScript tScript;
    public Color[] colors;
    public Color currentColor;
    public float timeLerp;
    public void CheckClick(TownRawScript trScript)
    {
        if (trScript.isCityUnblock == true)
        {
            if (trScript.isCityCanBeSelectWay == true)
            {
                if (trScript.isCitySelectWay == true)
                {
                    switch (selectedTown.Count)
                    {
                        case 1:
                            {
                                uiScript.panelSelectWay.SetActive(false);
                                mainScript.uiScript.tipTextSelectWay.text = "Select FIRST station";
                                UnSelectTown(trScript);
                                CloseAll();
                                OpenAll();
                                break;
                            }
                        case 2:
                            {
                                uiScript.secondCityImageSelectWay.gameObject.SetActive(false);
                                uiScript.secondCityNameSelectWay.gameObject.SetActive(false);
                                mainScript.uiScript.goSelectWay.interactable = false;
                                mainScript.uiScript.tipTextSelectWay.text = "Select SECOND station";
                                if (trScript == selectedTown[0])
                                {
                                    UnSelectTown(trScript);
                                    CheckCityForChoose(selectedTown[0]);
                                }
                                else if (trScript == selectedTown[1])
                                {
                                    UnSelectTown(trScript);
                                    CheckCityForChoose(selectedTown[0]);
                                }
                                if (selectedTown[0].isTown == true)
                                    uiScript.firstCityImageSelectWay.sprite = selectedTown[0].businessSprite;
                                else
                                    uiScript.firstCityImageSelectWay.sprite = selectedTown[0].rawSprite;
                                uiScript.firstCityNameSelectWay.text = selectedTown[0].townName;
                                selectedTown[0].tPointer.Hide();
                                selectedTown[0].tPointer.Spawn(selectedTown[0].gameObject, "FirstCitySelect", true);
                                break;
                            }
                    }
                }
                else
                    SelectTown(trScript);
            }
        }
    }
    public void CheckCityForChoose(TownRawScript trScript)
    {
        for (int i = 0; i < town.Count; i++)
        {
            bool contain = false;
            if (town[i] != trScript)
            {
                if (town[i].isCityUnblock == true)
                { 
                    for (int b = 0; b < town[i].road.Length; b++)
                    {
                        if (town[i].road[b].townraw.Contains(trScript) && town[i].road[b].isRailBuild == true)
                        {
                            contain = true;
                            OpenTownForChoose(town[i]);
                        }
                        if (contain == false)
                        {
                            CloseTownForChoose(town[i]);
                        }
                    }
                }
                
            }
        }
    }
    public void OpenAll()
    {
        mainScript.uiScript.goSelectWay.interactable = false;
        mainScript.uiScript.tipTextSelectWay.text = "Select FIRST station";
        mainScript.uiScript.canvasSelectWay.SetActive(true);
        mainScript.uiScript.uiTween.CloseMainMenu();
        mainScript.isSelectWayOpen = true;
        for(int i = 0; i < town.Count; i++)
        {
            if (town[i].isCityUnblock == true)
            {
                OpenTownForChoose(town[i]);
            }
        }
    }
    public void SetWayToTrain()
    {
        tScript.way.Add(selectedTown[0]);
        tScript.way.Add(selectedTown[1]);
        for (int i = 0; i < selectedTown[0].road.Length; i++)
        {
            if (selectedTown[0].road[i].townraw.Contains(selectedTown[1]))
                tScript.road = selectedTown[0].road[i];
        }
        tScript.Spawn();
        CloseAll();
        uiScript.OpenTrainMenu(tScript);
    }
    private void CloseAll()
    {
        uiScript.panelSelectWay.SetActive(false);
        uiScript.canvasSelectWay.SetActive(false);
        if (tScript.way.Count == 0)
        {
            mainScript.uiScript.uiTween.OpenMainUI();
        }
        mainScript.isSelectWayOpen = false;
        for (int i = 0; i < town.Count; i++)
        {
            town[i].tPointer.Destroy();
            if (selectedTown.Contains(town[i]))
            {
                UnSelectTown(town[i]);
            }
            if (town[i].isCityUnblock == true)
            {
                CloseTownForChoose(town[i]);
            }
        }
    }
    public void SelectTown(TownRawScript trScript)
    {
        switch (selectedTown.Count)
        {
            case 0:
                {
                    trScript.tPointer.Hide();
                    trScript.tPointer.Spawn(trScript.gameObject, "FirstCitySelect", true);
                    if (trScript.isTown == true)
                        uiScript.firstCityImageSelectWay.sprite = trScript.businessSprite;
                    else
                        uiScript.firstCityImageSelectWay.sprite = trScript.rawSprite;
                    uiScript.firstCityNameSelectWay.text = trScript.townName;
                    uiScript.panelSelectWay.SetActive(true);
                    uiScript.secondCityNameSelectWay.gameObject.SetActive(false);
                    uiScript.secondCityImageSelectWay.gameObject.SetActive(false);
                    mainScript.uiScript.tipTextSelectWay.text = "Select SECOND station";
                    selectedTown.Add(trScript);
                    CheckCityForChoose(trScript);
                    break;
                }
            case 1:
                {
                    trScript.tPointer.Hide();
                    trScript.tPointer.Spawn(trScript.gameObject, "SecondCitySelect",true);
                    uiScript.secondCityImageSelectWay.gameObject.SetActive(true);
                    uiScript.secondCityNameSelectWay.gameObject.SetActive(true);
                    if (trScript.isTown == true)
                        uiScript.secondCityImageSelectWay.sprite = trScript.businessSprite;
                    else
                        uiScript.secondCityImageSelectWay.sprite = trScript.rawSprite;
                    uiScript.secondCityNameSelectWay.text = trScript.townName;
                    mainScript.uiScript.goSelectWay.interactable = true;
                    mainScript.uiScript.tipTextSelectWay.text = "Press Accept or select a new station";
                    selectedTown.Add(trScript);
                    break;
                }
            case 2:
                {
                    trScript.tPointer.Hide();
                    trScript.tPointer.Spawn(trScript.gameObject, "SecondCitySelect",true);
                    if (trScript.isTown == true)
                        uiScript.secondCityImageSelectWay.sprite = trScript.businessSprite;
                    else
                        uiScript.secondCityImageSelectWay.sprite = trScript.rawSprite;
                    uiScript.secondCityNameSelectWay.text = trScript.townName;
                    UnSelectTown(selectedTown[1]);
                    selectedTown.Add(trScript);
                    selectedTown[0].numWay = 1;
                    break;
                }
        }
        trScript.numWay = selectedTown.Count;
        trScript.isCitySelectWay = true;
        trScript.outline.enabled = true;
        trScript.outline.OutlineColor = colors[0];
        //StartCoroutine(ColorLerp(trScript, colors[1]));
        trScript.outline.OutlineColor = colors[1];
    }
    public void UnSelectTown(TownRawScript trScript)
    {
        trScript.isCitySelectWay = false;
        selectedTown.Remove(trScript);
        OpenTownForChoose(trScript);
    }
    public void OpenTownForChoose(TownRawScript trScript)
    {
        if(trScript.tPointer != null)
            trScript.tPointer.Destroy();
        trScript.tPointer.Spawn(trScript.gameObject, "CityCanBeSelected",true);
        trScript.TownRawCanvas.SetActive(true);
        trScript.openBtn.gameObject.SetActive(false);
        trScript.emptyBar.SetActive(false);
        trScript.fullBar.gameObject.SetActive(false);
        if (trScript.isTown)
        {
            trScript.fullBarPeople.gameObject.SetActive(false);
            trScript.emptyBarPeople.gameObject.SetActive(false);
        }
        trScript.isCityCanBeSelectWay = true;
        trScript.outline.enabled = true;
        trScript.outline.OutlineMode = Outline.Mode.OutlineAll;
        trScript.outline.OutlineColor = colors[1];
        //StartCoroutine(ColorLerp(trScript, colors[0]));
        trScript.outline.OutlineColor = colors[0];
        trScript.numWay = 3;
    }
    public void CloseTownForChoose(TownRawScript trScript)
    {
        trScript.tPointer.Hide();
        trScript.lastmsg = null;
        trScript.TownRawCanvas.SetActive(false);
        trScript.openBtn.gameObject.SetActive(true);
        trScript.emptyBar.SetActive(true);
        trScript.fullBar.gameObject.SetActive(true);
        if (trScript.isTown)
        {
            trScript.fullBarPeople.gameObject.SetActive(true);
            trScript.emptyBarPeople.gameObject.SetActive(true);
        }
        trScript.isCityCanBeSelectWay = false;
        trScript.isCitySelectWay = false;
        trScript.outline.enabled = false;
        trScript.numWay = 3;
    }
}
