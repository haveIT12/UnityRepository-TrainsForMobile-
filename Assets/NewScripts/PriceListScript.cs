using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceListScript : MonoBehaviour
{
    [SerializeField] private PriceManager pManager;
    [SerializeField] private UserInterfaceScript uiScript;
    [SerializeField] private List<PriceListItemScript> item;
    public GameObject canvas;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private Image graph;
    [SerializeField] private Sprite[] graphSprite;//0-up; 1-down; 2-?
    //Passenger
    [SerializeField] private TextMeshProUGUI pricePassenger;
    [SerializeField] private TextMeshProUGUI passengerPriceUpdate;
    [SerializeField] private float[] newTicketCost;
    [SerializeField] private float[] pUpdateCost;
    [SerializeField] private bool[] pUpdateIsTicket;
    [SerializeField] private int pUpdateLvl;
    [SerializeField] private Button passengerButtonUpdate;
    [SerializeField] private Button passengerButtonUpdateAd;
    [SerializeField] private Image currencyPassengerUpdate;
    [SerializeField] private GameObject pCenterPos;
    [SerializeField] private float _currentTimer;

    public float[] timeToMode;
    public int timesOfUpdate; //how much time was updated
    [SerializeField] private float changeTime;
    [SerializeField] private TimerScript timerS;
    public bool isTimerWork;
    private bool isOpen;
    private IEnumerator changeLerp;
    private int mode;
    public int[] modes;
    private void Awake()
    {
        isTimerWork = true;
        mode = modes[timesOfUpdate];
    }
    private void Update()
    {
        if (isTimerWork)
        {
            _currentTimer += Time.deltaTime;
            if (timeToMode[timesOfUpdate] - _currentTimer <= 0)
            {
                UpdatePrices();
            }
            else
            {
                if (isOpen)
                {
                    float minutes = Mathf.FloorToInt(timeToMode[timesOfUpdate] - _currentTimer) / 60;
                    float seconds = Mathf.FloorToInt((timeToMode[timesOfUpdate] - _currentTimer) % 60);
                    if (seconds >= 10)
                        timer.text = minutes + ":" + seconds;
                    else
                        timer.text = minutes + ":0" + seconds;
                }
            }
        }
    }
    public void OpenPriceList()
    {
        isOpen = true;
        canvas.SetActive(true);
        for (int i = 0; i < item.Count; i++)
        {
            item[i].Open();
        }
        GetMode();
        CheckPassenger();
    }
    public void CheckPassenger()
    {
        if (pUpdateLvl > 3)
        {
            pricePassenger.text = FormatNumsHelper.FormatNum(pManager.GetPrice("Passenger"));
            passengerPriceUpdate.gameObject.transform.SetParent(pCenterPos.transform);
            passengerPriceUpdate.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            currencyPassengerUpdate.gameObject.SetActive(false);
            passengerButtonUpdate.interactable = false;
            passengerButtonUpdateAd.interactable = false;
            passengerPriceUpdate.text = "MaxLvl";
        }
        else
        {
            passengerPriceUpdate.gameObject.transform.SetParent(passengerButtonUpdate.transform);
            passengerPriceUpdate.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            currencyPassengerUpdate.gameObject.SetActive(true);
            passengerPriceUpdate.text = FormatNumsHelper.FormatNum(pUpdateCost[pUpdateLvl]);
            if (pUpdateIsTicket[pUpdateLvl])
            {
                currencyPassengerUpdate.sprite = uiScript.currencyTickets;
                if (!uiScript.mainScript.pData.CheckValue(pUpdateCost[pUpdateLvl], true))
                    passengerButtonUpdate.interactable = false;
                else
                    passengerButtonUpdate.interactable = true;
            }
            else
            {
                currencyPassengerUpdate.sprite = uiScript.currencyMoney;
                if (!uiScript.mainScript.pData.CheckValue(pUpdateCost[pUpdateLvl], false))
                    passengerButtonUpdate.interactable = false;
                else
                    passengerButtonUpdate.interactable = true;
            }
            pricePassenger.text = FormatNumsHelper.FormatNum(pManager.GetPrice("Passenger"));
        }
    }
    public void UpgradePassenger()
    {
        if (pUpdateLvl > 3)
        {
            passengerButtonUpdate.interactable = false;
            passengerPriceUpdate.text = "MaxLvl";
        }
        else
        {
            passengerPriceUpdate.text = FormatNumsHelper.FormatNum(pUpdateCost[pUpdateLvl]);
            if (pUpdateIsTicket[pUpdateLvl])
            {
                currencyPassengerUpdate.sprite = uiScript.currencyTickets;
                if (uiScript.mainScript.pData.CheckValue(pUpdateCost[pUpdateLvl], true))
                {
                    uiScript.mainScript.pData.ChangeTickets(this.gameObject, -pUpdateCost[pUpdateLvl]);
                    pUpdateLvl++;
                }
                else
                {
                    CheckPassenger();
                    return;
                }
            }
            else
            {
                currencyPassengerUpdate.sprite = uiScript.currencyMoney;
                if (uiScript.mainScript.pData.CheckValue(pUpdateCost[pUpdateLvl], false))
                {
                    pUpdateLvl++;
                    uiScript.mainScript.pData.ChangeMoney(this.gameObject, -pUpdateCost[pUpdateLvl]);
                }
                else
                {
                    CheckPassenger();
                    return;
                }
            }
            pManager.UpdatePrice("Passenger", newTicketCost[pUpdateLvl-1]);
            CheckPassenger();
        }
    }
    public void ClosePriceList()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i].changeImageGrow.SetActive(false);
            item[i].changeImageDecrease.SetActive(false);
        }
        canvas.SetActive(false);
        isOpen = false;
        uiScript.priceListGrow.SetActive(false);
        uiScript.priceListQ.SetActive(false);
        uiScript.priceListDecrease.SetActive(false);
        if (changeLerp != null)
            StopCoroutine(changeLerp);
    }
    private void UpdatePrices()
    {
        isTimerWork = false;
        for (int i = 0; i < item.Count; i++)
        {
            float a = 1 + Random.Range(pManager.randomPercengeMin[timesOfUpdate], pManager.randomPercengeMax[timesOfUpdate]) / 100;
            item[i].GetPrice();
            pManager.RandomUpdate(item[i]._name, a);
            item[i].CheckDifference(a);
            item[i].GetPrice();
            item[i].priceElement.text = FormatNumsHelper.FormatNum(pManager.GetPrice(item[i]._name));
            if (isOpen)
            {
                //
            }
            else
            {
                if (mode == 0)
                    uiScript.priceListGrow.SetActive(true);
                else if (mode == 1)
                    uiScript.priceListDecrease.SetActive(true);
                else if (mode == 2)
                    uiScript.priceListQ.SetActive(true);
            }
        }
        timesOfUpdate++;
        if (timesOfUpdate < modes.Length)
        {
            mode = modes[timesOfUpdate];
            GetMode();
            _currentTimer = 0;
            isTimerWork = true;
        }
        else
        {
            _currentTimer = 0;
            timer.text = "N/A";
            graph.gameObject.SetActive(false);
        }
    }
    private void GetMode()
    {
        switch (mode)
        {
            case 0:
                {
                    if (changeLerp != null)
                        StopCoroutine(changeLerp);
                    changeLerp = ChangeMode(graphSprite[0]);
                    StartCoroutine(changeLerp);
                    break;
                }
            case 1:
                {
                    if (changeLerp != null)
                        StopCoroutine(changeLerp);
                    changeLerp = ChangeMode(graphSprite[1]);
                    StartCoroutine(changeLerp);
                    break;
                }
            case 2:
                {
                    if (changeLerp != null)
                        StopCoroutine(changeLerp);
                    changeLerp = ChangeMode(graphSprite[2]);
                    StartCoroutine(changeLerp);
                    break;
                }
        }
    }
    private IEnumerator ChangeMode(Sprite sprite, bool changing = false)
    {
        float elapsedTime = 0;
        if (changing)
        {
            while (elapsedTime < changeTime)
            {
                graph.color = Color.Lerp(new Color(255, 255, 255, 255), new Color(255, 255, 255, 0), (elapsedTime / changeTime*0.01f));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        elapsedTime = 0;
        graph.sprite = sprite;
        graph.color = new Color(255, 255, 255, 0);
        while (elapsedTime < changeTime)
        {
            graph.color = Color.Lerp(new Color(255, 255, 255, 0), new Color(255, 255, 255, 255), (elapsedTime / changeTime*0.01f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        graph.color = new Color(255, 255, 255, 255);
        yield return null;
    }
}
