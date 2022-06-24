using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainScript : MonoBehaviour
{
    [Header("Links")]
    public TrainSystemScript tsScript;
    public UserInterfaceScript uiScript;
    public TrainInfo tInfo;
    public TargetPointer tPointer;
    [Space]
    [Header("Wagons")]
    public List<WagonScript> wagon;
    public GameObject[] placeForWagon;
    [Space]
    [Header("Other")]
    public string trainName;
    public float maxSpeed;
    public float maxHealth;
    public float health;
    public string typeTrain;
    public string subNameTrain;
    public float repairCost;
    public bool sell;
    //public bool[] wagon;
    public bool isTrainSelectDepot;
    public Color colorHealth;
    public Color colorTypeTrain;
    [Space]
    [Header("Way")]
    public List<TownRawScript> way;
    public TownRawScript placeWhereIAm;
    public TownRawScript placeWhereIAmGoing;
    public RailRoadScript road;
    public int target;
    public bool canILoad;
    public bool canIMove;
    public string directionMovement;
    [Space]
    [Header("UI")]
    public Sprite trainSprite;
    public Sprite[] wagonSprite;

    public GameObject pref;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;
    public TextMeshProUGUI trainNameText;
    private GameObject mask;
    [Header("TrainMenu")]
    public GameObject canvasTrainMenu;
    public float asdsad;

    void Awake()
    {
        tPointer = gameObject.GetComponent<TargetPointer>();
        tsScript = FindObjectOfType<TrainSystemScript>();
        uiScript = tsScript.uiScript;
        trainName = tInfo.trainName;
        trainSprite = tInfo.spriteTrain;
        maxSpeed = tInfo.maxSpeed;
        maxHealth = tInfo.maxHealth;
        health = maxHealth;
        typeTrain = tInfo.typeTrain;
    }
    private void Start()
    {
        checktype();
    }
    private void FixedUpdate()
    {
        if (canIMove == true)
        {
            if (directionMovement == "Forward")
            {
                /*if (target == 0)
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, road.point[target].position, (maxSpeed / 20) * Time.fixedDeltaTime);
                }*/
                if (target < road.point.Count)
                {
                    gameObject.transform.position += transform.forward * (maxSpeed / 10) * Time.fixedDeltaTime;
                    Quaternion lookOnLook = Quaternion.LookRotation(road.point[target].transform.position - gameObject.transform.position);
                    gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, (maxSpeed / 3) * Time.fixedDeltaTime);
                }
                if (target == road.point.Count)
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, placeWhereIAmGoing.spawnPoint.transform.position, (maxSpeed / 20) * Time.fixedDeltaTime);
            }
            if (directionMovement == "Backward")
            {
                /*if (target == road.point.Count)
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, road.point[target].position, (maxSpeed / 20) * Time.fixedDeltaTime);
                }*/
                if (target >= 0)
                {
                    gameObject.transform.position += transform.forward * (maxSpeed / 10) * Time.fixedDeltaTime;
                    Quaternion lookOnLook = Quaternion.LookRotation(road.point[target].transform.position - gameObject.transform.position);
                    gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, (maxSpeed / 3) * Time.fixedDeltaTime);
                }
                if (target == -1)
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, placeWhereIAmGoing.spawnPoint.transform.position, (maxSpeed / 20) * Time.fixedDeltaTime);
            }
        }
    }
    private void Update()
    {
        if (sell == true) //временно
            SellTrain();
    }
    public void Spawn()
    {
        placeWhereIAm = way[0];
        gameObject.transform.SetParent(way[0].gameObject.transform);
        gameObject.transform.position = way[0].spawnPoint.transform.position;
        gameObject.transform.forward = way[0].spawnPoint.transform.forward;
        gameObject.transform.SetParent(tsScript.gameObject.transform);
        CheckDirection();
        canILoad = true;
        CheckStation();
    }
    public void Move()
    {
        Debug.Log(road.townraw.Count);
        for (int i = 0; i < road.townraw.Count; i++)
        {
            Debug.Log("1");
            if (road.townraw[i] != placeWhereIAm)
            {
                Debug.Log("2");
                placeWhereIAmGoing = road.townraw[i];
            }
        }
        if (placeWhereIAmGoing == road.townraw[0])
        {
            Debug.Log("3");
            target = road.point.Count-1;
            directionMovement = "Backward";
        }   
        else if (placeWhereIAmGoing == road.townraw[1])
        {
            Debug.Log("4");
            target = 0;
            directionMovement = "Forward";
        }
        gameObject.transform.position = placeWhereIAm.spawnPoint.transform.position;
        gameObject.transform.forward = placeWhereIAm.spawnPoint.transform.forward;
        canIMove = true;
    }
    private void CheckStation()
    {
        if (canILoad == true)
        {
            if (wagon.Count > 0)
            {
                /*
                for (int i = 0; i < wagon.Count; i++)
                {
                    if (wagon[i].typeOfWagon == "Freight")
                        wagon[i].StartCoroutine(wagon[i].UnLoadTheWagon());
                }
                Debug.Log("5");
                for (int b = 0; b < wagon.Count; b++)
                {
                    Debug.Log("6");
                    if (wagon[b].typeOfWagon == "Freight")
                    {
                        Debug.Log("7");
                        if (placeWhereIAm.productType == "")
                        {
                            Debug.Log("8");
                            if (placeWhereIAm.newRaw >= wagon[b].maxLoadWeight)
                                wagon[b].StartCoroutine(wagon[b].LoadToTheWagon(placeWhereIAm.rawType, wagon[b].maxLoadWeight, "Raw"));
                        }
                        else
                        {
                            Debug.Log("9");
                            if (placeWhereIAm.newProduct >= wagon[b].maxLoadWeight)
                                wagon[b].StartCoroutine(wagon[b].LoadToTheWagon(placeWhereIAm.productType, wagon[b].maxLoadWeight, "Product"));
                        }
                    }
                }*/
            }
            else
            {
                if (uiScript.mainScript.isTownRawInfoOpened == false && uiScript.idMenu == 999 && uiScript.mainScript.isSelectWayOpen == false
                && uiScript.mainScript.isBuildRailOpen == false)
                {
                    tPointer.Hide();
                    tPointer.Spawn(gameObject, "NoWagons");
                }
            }
        }
        //void go();
        //yield return new WaitForSeconds(1f);
        //StartCoroutine(CheckStation());
    }
    private void CheckDirection()
    {
        float dist1 = Vector3.Distance(road.gameObject.transform.position, placeWhereIAm.directionPoint[0].transform.position);
        float dist2 = Vector3.Distance(road.gameObject.transform.position, placeWhereIAm.directionPoint[1].transform.position);
        if (dist1 < dist2)
            gameObject.transform.forward = placeWhereIAm.directionPoint[0].transform.forward;
        else
            gameObject.transform.forward = placeWhereIAm.directionPoint[1].transform.forward;
    }
    public void checktype()
    {
        if (typeTrain == "Universal")
        {
            colorTypeTrain = tsScript.colorTypeTrain[0];
            subNameTrain = "niversal";
        }

        else if (typeTrain == "Freight Only!")
        {
            colorTypeTrain = tsScript.colorTypeTrain[1];
            subNameTrain = "reight";
        }

        else if (typeTrain == "Pass Only!")
        {
            colorTypeTrain = tsScript.colorTypeTrain[2];
            subNameTrain = "assenger";
        }

    }
    public void checkhp(float health)
    {
        if (health >= maxHealth)
            colorHealth = tsScript.hpcolor[0];
        else if (health / maxHealth >= 0.8f)
            colorHealth = tsScript.hpcolor[1];
        else if (health / maxHealth >= 0.6f)
            colorHealth = tsScript.hpcolor[2];
        else if (health / maxHealth >= 0.4f)
            colorHealth = tsScript.hpcolor[3];
        else if (health / maxHealth >= 0.2f)
            colorHealth = tsScript.hpcolor[4];
        else if (health / maxHealth < 0.2f)
            colorHealth = tsScript.hpcolor[5];
        if (tsScript.mainScript.isTrainMenuOpen == true)
        {
            uiScript.healthTrainTrainMenu.color = colorHealth;
            uiScript.imageHealthTrainMenu.color = colorHealth;
        }
    }
    public IEnumerator checkHP()
    {
        checkhp(health);
        yield return new WaitForSeconds(1f);
        StartCoroutine(checkHP());
    }
    public void SelectThis()
    {
        checkhp(health);
        tsScript.tScript = this;
        isTrainSelectDepot = true;
        mask = pref.transform.GetChild(0).gameObject;
        mask.SetActive(true);
        uiScript.trainDepotImage.gameObject.SetActive(true);
        uiScript.trainDepotImage.sprite = trainSprite;
        uiScript.nameTrainDepot.gameObject.SetActive(true);
        uiScript.nameTrainDepot.text = trainName;
        uiScript.speedTrainDepot.gameObject.SetActive(true);
        uiScript.speedTrainDepot.text = maxSpeed.ToString() + " KM/H";
        maxHealthText.color = tsScript.colorSelect;
        trainNameText.color = Color.white;
        healthText.color = colorHealth;
        healthText.text = health.ToString();
        uiScript.selectTrainDepot.interactable = true;
        /*for (int i = 0; i < wagon.Count; i++)
        {
            if (wagon)
            {
                uiScript.wagonDepot[i].gameObject.SetActive(true);
                uiScript.wagonDepot[i].sprite = wagonSprite[i];
            }
            else
                Debug.Log(i + " null");
        }*/
    }

    public void CloseElementDepot()
    {
        isTrainSelectDepot = false;
        mask = pref.transform.GetChild(0).gameObject;
        mask.SetActive(false);
        uiScript.nameTrainDepot.gameObject.SetActive(false);
        uiScript.speedTrainDepot.gameObject.SetActive(false);
        uiScript.trainDepotImage.gameObject.SetActive(false);
        maxHealthText.color = tsScript.colorNeutral;
        trainNameText.color = tsScript.colorSecondNeutral;
        healthText.color = tsScript.colorNeutral;
        uiScript.selectTrainDepot.interactable = false;
        /*for (int i = 0; i < wagon.Length; i++)
        {
            if (wagon[i] == true)
            {
                uiScript.wagonDepot[i].gameObject.SetActive(false);
                uiScript.wagonDepot[i].sprite = null;
            }
        }*/
    }
    public void RepairTrain()
    {

    }
    public void SellTrain()
    {
        tsScript.train.Remove(this.gameObject);
        Destroy(pref);
        Destroy(this.gameObject);
    }
    public void BuyWagon(string typeWagon)
    {
        if (wagon.Count == 0)
            tPointer.Hide();
        if (typeWagon == "Freight")
        {
            var Wagon = Instantiate(tsScript.wagonPref[0], gameObject.transform);
            Wagon.transform.position = placeForWagon[wagon.Count].transform.position;
            Wagon.train = this;
            wagon.Add(Wagon.GetComponent<WagonScript>());
            //gameObject.transform.position += new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.65f);
            gameObject.transform.position += transform.forward * 0.65f;
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.forward, 0.65f);
        }
        else
        {
            var Wagon = Instantiate(tsScript.wagonPref[1], placeForWagon[wagon.Count].transform, gameObject);
        }
        canILoad = true;
        Debug.Log(typeWagon);
    }
    public void AddDepotElement()
    {
        pref = Instantiate(tsScript.prefElementDepot, tsScript.contentDepot.transform);
        tsScript.uiScript.trainListDepot.Add(pref);
        pref.GetComponent<SelectTrainInDepot>().This(this);
        GameObject mxHealth = pref.gameObject.transform.GetChild(2).gameObject;
        maxHealthText = mxHealth.GetComponent<TextMeshProUGUI>();
        maxHealthText.text = maxHealth.ToString();

        GameObject tnt = pref.gameObject.transform.GetChild(1).gameObject;
        trainNameText = tnt.GetComponent<TextMeshProUGUI>();
        trainNameText.text = trainName;

        GameObject currentHealth = pref.gameObject.transform.GetChild(3).gameObject;
        healthText = currentHealth.GetComponent<TextMeshProUGUI>();
        healthText.text = health.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="City")
        {
            if (other.name == way[0].gameObject.name)
                placeWhereIAm = way[0];
            if (other.name == way[1].gameObject.name)
                placeWhereIAm = way[1];
        }
        if (other.tag == "Point")
        {
            if (road.point.Contains(other.gameObject.transform))
            {
                if (directionMovement == "Forward")
                    target++;
                else if (directionMovement == "Backward")
                    target--;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "City")
            placeWhereIAm = null;
    }
}
