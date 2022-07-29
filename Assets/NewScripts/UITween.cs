using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UITween : MonoBehaviour
{
    [SerializeField] RectTransform
    /*MainMenu*/
    build_mui, tasks_mui, shop_mui, depot_mui, priceList_mui, panelMoney_mui, panelTickets_mui,
    menu_mui, exp_mui, reward_mui, timer_mui;
    [Header("BgFB")]
    [SerializeField] CanvasGroup panel_bgui;
    [SerializeField] RectTransform ppanel_bgui;
    [SerializeField] RectTransform buttonClose_bgui;
    [SerializeField] RectTransform buttonMoney_bgui;
    [SerializeField] RectTransform buttonTickets_bgui;
    [Header("Town")]
    [SerializeField] CanvasGroup panel_townui;
    [SerializeField] RectTransform ppanel_townui;
    [SerializeField] RectTransform button_townui;
    [SerializeField] RectTransform buttonText_townui;
    [Header("Raw")]
    [SerializeField] CanvasGroup panel_rawui;
    [SerializeField] RectTransform ppanel_rawui;
    [SerializeField] RectTransform button_rawui;
    [SerializeField] RectTransform buttonText_rawui;
    [Header("Tasks")]
    [SerializeField] CanvasGroup panel_taskui;
    [SerializeField] RectTransform ppanel_taskui;
    [SerializeField] RectTransform imageTimer_taskui;
    [SerializeField] RectTransform imageTasks_taskui;
    [Header("Depot")]
    [SerializeField] CanvasGroup panel_depotui;
    [SerializeField] RectTransform ppanel_depotui;
    [SerializeField] RectTransform button_depotui;
    [SerializeField] RectTransform buttonShop_depotui;
    [SerializeField] RectTransform imageTrain_depotui;
    [SerializeField] RectTransform text_depotui;


    [SerializeField] float speedMainUI = 1;
    [SerializeField] UserInterfaceScript uiScript;
    private void Start()
    {
        OpenMainUI();
    }
    public void OpenMainUI()
    {
        uiScript.canvasMainUI.SetActive(true);
        depot_mui.DOAnchorPos(new Vector2(16, 65), speedMainUI).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasMainUI.SetActive(true); });
        build_mui.DOAnchorPos(new Vector2(325, 145), speedMainUI).SetEase(Ease.OutQuart);
        shop_mui.DOAnchorPos(new Vector2(107, 431), speedMainUI).SetEase(Ease.OutQuart);
        exp_mui.DOAnchorPos(new Vector2(0, 0), speedMainUI).SetEase(Ease.OutQuart);
        tasks_mui.DOAnchorPos(new Vector2(-122, 192), speedMainUI).SetEase(Ease.OutQuart);
        reward_mui.DOAnchorPos(new Vector2(-121, 46), speedMainUI).SetEase(Ease.OutQuart);
        priceList_mui.DOAnchorPos(new Vector2(-97, 270), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOAnchorPos(new Vector2(103, -97), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOLocalRotate(new Vector3(0, 0, -720), speedMainUI).SetEase(Ease.OutQuart);
        timer_mui.DOAnchorPos(new Vector2(289, -77), speedMainUI).SetEase(Ease.OutQuart);
        panelTickets_mui.DOAnchorPos(new Vector2(0, 31), speedMainUI).SetEase(Ease.OutQuart);
        panelMoney_mui.DOAnchorPos(new Vector2(0, -32), speedMainUI).SetEase(Ease.OutQuart);
    }
    public void CloseMainMenu()
    {
        depot_mui.DOAnchorPos(new Vector2(-228, 65), speedMainUI).SetEase(Ease.OutQuart);
        build_mui.DOAnchorPos(new Vector2(325, -110), speedMainUI).SetEase(Ease.OutQuart);
        shop_mui.DOAnchorPos(new Vector2(-310, 431), speedMainUI).SetEase(Ease.OutQuart);
        exp_mui.DOAnchorPos(new Vector2(0, -100), speedMainUI).SetEase(Ease.OutQuart);
        tasks_mui.DOAnchorPos(new Vector2(150, 192), speedMainUI).SetEase(Ease.OutQuart);
        reward_mui.DOAnchorPos(new Vector2(140, 46), speedMainUI).SetEase(Ease.OutQuart);
        priceList_mui.DOAnchorPos(new Vector2(250, 270), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOAnchorPos(new Vector2(-80, -97), speedMainUI).SetEase(Ease.OutQuart);
        menu_mui.DOLocalRotate(new Vector3(0, 0, 720), speedMainUI).SetEase(Ease.OutQuart);
        timer_mui.DOAnchorPos(new Vector2(289, 135), speedMainUI).SetEase(Ease.OutQuart);
        panelTickets_mui.DOAnchorPos(new Vector2(500, 31), speedMainUI).SetEase(Ease.OutQuart);
        panelMoney_mui.DOAnchorPos(new Vector2(385, -32), speedMainUI).SetEase(Ease.OutQuart);
        Debug.Log("y");
    }
    public void OpenBgFB()
    {
        uiScript.canvasBgFB.SetActive(true);
        panel_bgui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasBgFB.SetActive(true); });
        buttonClose_bgui.DOScale(1, speedMainUI * 0.6f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonMoney_bgui.DOScale(0.7f, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonTickets_bgui.DOScale(0.7f, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_bgui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void CloseBgFB()
    {
        panel_bgui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => 
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasBgFB.SetActive(false); 
        });
        buttonClose_bgui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.OutBack);
        buttonMoney_bgui.DOScale(0, speedMainUI * 0.2f).SetEase(Ease.OutBack);
        buttonTickets_bgui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        ppanel_bgui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTown()
    {
        uiScript.canvasTown.SetActive(true);
        panel_townui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasTown.SetActive(true); });
        button_townui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonText_townui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_townui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void CloseTown()
    {
        panel_townui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => 
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasTown.SetActive(false); 
        });
        button_townui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_townui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenRaw()
    {
        uiScript.canvasRaw.SetActive(true);
        panel_rawui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasRaw.SetActive(true); });
        button_rawui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonText_rawui.DOScale(1, speedMainUI * 0.4f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_rawui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void CloseRaw()
    {
        panel_rawui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasRaw.SetActive(false);
        });
        button_rawui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_rawui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
    public void OpenTaskMenu()
    {
        uiScript.canvasTaskMenu.SetActive(true);
        panel_taskui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasRaw.SetActive(true); });
        imageTimer_taskui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        imageTasks_taskui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_taskui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.taskSystem.task.Count; i++)
        {
            uiScript.taskSystem.task[i].imageTask.GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.InOutBack).SetDelay(speedMainUI * 0.2f); ;
            if (uiScript.taskSystem.task[i].isDone())
            {
                uiScript.taskSystem.task[i].doneImage.GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.InOutBack).SetDelay(speedMainUI * 0.2f); ;
            }
        }
    }
    public void CloseTaskMenu()
    {
        panel_taskui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasTaskMenu.SetActive(false);
        });
        imageTasks_taskui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        imageTimer_taskui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_taskui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.taskSystem.task.Count; i++)
        {
            uiScript.taskSystem.task[i].imageTask.GetComponent<RectTransform>().DOScale(0, Random.Range(0f, 0.3f)).SetEase(Ease.InOutBack);
            if (uiScript.taskSystem.task[i].isDone())
            {
                uiScript.taskSystem.task[i].doneImage.GetComponent<RectTransform>().DOScale(0, Random.Range(0f, 0.3f)).SetEase(Ease.InOutBack);
            }
        }
    }
    public void OpenDepot()
    {
        text_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        uiScript.canvasDepot.SetActive(true);
        panel_depotui.DOFade(1, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() => { uiScript.canvasRaw.SetActive(true); });
        button_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        buttonShop_depotui.DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        ppanel_depotui.DOScale(1.5f, speedMainUI * 0.6f).SetEase(Ease.OutBack);
        text_depotui.GetComponent<RectTransform>().DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        for (int i = 0; i < uiScript.trainListDepot.Count; i++)
        {
            uiScript.trainListDepot[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.trainListDepot[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.OutBack).SetDelay(speedMainUI * 0.2f);
        }
    }
    public void SelectTrainDepot()
    {
        imageTrain_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        imageTrain_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        button_depotui.localScale = Vector3.zero;
        button_depotui.DOScale(1, speedMainUI * 0.3f).SetEase(Ease.OutBack);
        for (int i = 0; i < uiScript.wagonDepot.Count; i++)
        {
            uiScript.wagonDepot[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            uiScript.wagonDepot[i].GetComponent<RectTransform>().DOScale(1, Random.Range(0.3f, 0.6f)).SetEase(Ease.OutBack);
        }
    }
    public void CloseTrainDepot()
    {
        text_depotui.GetComponent<RectTransform>().localScale = Vector3.zero;
        text_depotui.GetComponent<RectTransform>().DOScale(1, speedMainUI * 0.5f).SetEase(Ease.OutBack);
        imageTrain_depotui.DOScale(0, speedMainUI * 0.3f).SetEase(Ease.OutBack).OnComplete(() => 
        {
            if (uiScript.tsScript.tScript != null)
                return;
            imageTrain_depotui.gameObject.SetActive(false);
        });
    }
    public void CloseDepot()
    {
        panel_depotui.DOFade(0, speedMainUI * 0.4f).SetEase(Ease.OutQuart).OnComplete(() =>
        {
            if (uiScript.idMenu != 999)
                return;
            uiScript.canvasDepot.SetActive(false);
        });
        button_depotui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        buttonShop_depotui.DOScale(0, speedMainUI * 0.4f).SetEase(Ease.InOutBack);
        ppanel_depotui.DOScale(0, speedMainUI * 0.6f).SetEase(Ease.OutBack);
    }
}
