using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonScript : MonoBehaviour
{
    [Header("Links")]
    public TrainScript train;
    public GameObject touchPlace;
    public GameObject secondPlace;
    public Mesh[] meshWagon;//0-red(raw) 1-green(product)

    private MeshFilter currentMesh;
    private bool canILoad;
    private bool canIUnload;
    private bool loadOrUnload;//true-load; false-unload;
    public bool isWagonSpawned;
    public int wagonNum;
    private string productOrRaw;

    [Space]
    [Header("Settings Wagon")]
    public float price;
    public string typeOfWagon;
    public string typeOfWeight;
    public float loadWeight;
    public float newLoadWeight;
    public float nLW;
    public float maxLoadWeight;
    [SerializeField]
    private float maxLoadPassenger;
    [SerializeField]
    private float maxLoadProduct;
    [SerializeField]
    private float maxLoadRaw;
    public float speedOfLoading;//5f
    public bool isLoaded;
    public bool isUnloaded;
    public Bounds bounds;
    public Sprite wagonSprite;
    public Sprite spriteCargo;
    public Sprite spriteCargoR;
    public Sprite spriteCargoP;
    public Sprite emptySpriteCargo;
    public Sprite passengersSprite;
    public int loadWagonNum;
    public float totalPrice;
    public float sp;
    public float trnsp;

    private void Awake()
    {
        bounds = GetComponent<MeshFilter>().sharedMesh.bounds;
        currentMesh = gameObject.GetComponent<MeshFilter>();
    }
    private void FixedUpdate()
    {
        if (train.tsScript.tScript == train)
        {
            if (train.tsScript.uiScript.idMenu == 3)
                train.tsScript.uiScript.loadWeightTrainMenu[wagonNum].text = FormatNumsHelper.FormatNum(loadWeight) + "/" + FormatNumsHelper.FormatNum(maxLoadWeight);
        }
        if (loadWeight != newLoadWeight)
        {
            loadWeight = Mathf.Lerp(loadWeight, newLoadWeight, Time.fixedDeltaTime * speedOfLoading);
            if (loadOrUnload == true)
            {
                if (newLoadWeight - loadWeight < 0.5)
                {
                    loadWeight = newLoadWeight;
                    isUnloaded = false;
                    isLoaded = true;
                    train.IsWagonsLoad();
                }
            }
            else if (loadOrUnload == false)
            {
                if (newLoadWeight - loadWeight > -0.5)
                {
                    train.tsScript.priceManager.Sell(this, nLW, typeOfWeight);
                    train.totalCargoPrice += totalPrice;
                    totalPrice = 0;
                    if (train.tsScript.tScript == train)
                        train.uiScript.wagonCargoSprite[wagonNum].sprite = emptySpriteCargo;
                    nLW = 0;
                    loadWeight = newLoadWeight;
                    isLoaded = false;
                    isUnloaded = true;
                    Hide();
                    train.IsWagonsUnload();
                }
            }
        }
        if (train.canIMove == true)
        {
            if (isWagonSpawned == true)
            {
                Vector3 direction;
                if (loadWagonNum == 0)
                    direction = (train.dir.transform.position - secondPlace.transform.position).normalized;
                else
                    direction = (train.wagonsLoad[loadWagonNum-1].secondPlace.transform.position - secondPlace.transform.position).normalized;
                gameObject.transform.forward = direction;
                gameObject.transform.position += gameObject.transform.forward * (train.speed / sp) * Time.fixedDeltaTime;
                Quaternion lookOnLook = Quaternion.LookRotation(direction);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookOnLook, (train.speed / trnsp) * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (canILoad == true)//Если загрузка разрешена
            {
                newLoadWeight += maxLoadWeight;
                nLW = newLoadWeight;
                canILoad = false;
            }
            if (canIUnload == true)
            {
                if (typeOfWagon == "Freight")
                {
                    if (productOrRaw == "Raw")
                    {
                        train.placeWhereIAm.ChangeRaw(nLW);
                        newLoadWeight = 0;
                        canIUnload = false;
                    }
                    else if (productOrRaw == "Product")
                    {
                        newLoadWeight = 0;
                        canIUnload = false;
                    }
                }
                else
                {
                    if (train.placeWhereIAm.isTown == false)
                    {
                        train.placeWhereIAm.ChangePeople(nLW);
                        newLoadWeight = 0;
                        canIUnload = false;
                    }
                    newLoadWeight = 0;
                    canIUnload = false;
                }
            }
        }

    }
    public void Spawn()
    {
        speedOfLoading = train.wagonsLoadingSpeed;
        if (typeOfWagon == "Passenger")
            spriteCargo = passengersSprite;
        isWagonSpawned = true;
        GetWagonNumber();//Узнаем номер вагона
        if (loadWagonNum == 0)//Если вагон первый
        {
            gameObject.transform.SetParent(train.transform);//Парент вагона = поезд
            gameObject.transform.position = train.touchPlace.transform.position;//Позиция = точка прикосновения в поезде
        }
        else
        {
            gameObject.transform.SetParent(train.wagonsLoad[loadWagonNum - 1].transform);//Парент вагона = предыдущий поезд
            gameObject.transform.position = train.wagonsLoad[loadWagonNum - 1].touchPlace.transform.position;//Позиция = точка прикосновения в предыдущем вагоне
        }
        gameObject.transform.rotation = train.transform.rotation;//Поворачиваем вагон туда, куда смотрит поезд
        gameObject.transform.SetParent(train.tsScript.transform);//Парент вагона = TrainSystemScript.gameObject
    }
    public void Unload()
    {
        loadOrUnload = false;
        if (typeOfWagon == "Passenger")
        {
            canIUnload = true;
        }
        else
        {
            if (train.placeWhereIAm.isTown == true)//Если место где находится поезд это город
            {
                if (productOrRaw == "Raw")
                {
                    if (typeOfWeight == train.placeWhereIAm.rawType)
                        canIUnload = true;

                }
                else if (productOrRaw == "Product")
                    canIUnload = true;
            }
            else
            {
                isLoaded = false;
                isUnloaded = true;
                train.IsWagonsUnload();
            }
        }
    }
    public void Load()
    {
        loadOrUnload = true;
        if (typeOfWagon == "Passenger")
        {
            typeOfWeight = "Passenger";
            if (train.tsScript.tScript == train)
            {
                train.uiScript.wagonCargoSprite[wagonNum].sprite = spriteCargo;
            }
        }
        else
        {
            if (train.placeWhereIAm.isTown)//Если место где находится поезд это город
            {
                
                spriteCargo = train.placeWhereIAm.businessSprite;
                wagonSprite = spriteCargoP;
                productOrRaw = "Product";//Тип груза - готовый продукт
                typeOfWeight = train.placeWhereIAm.productType;//Тип продукта - продукт место где поезд находится
                currentMesh.mesh = meshWagon[1];
            }
            else//Если место где находится поезд это не город
            {
                
                spriteCargo = train.placeWhereIAm.rawSprite;
                wagonSprite = spriteCargoR;
                productOrRaw = "Raw";//Тип груза - сырье
                typeOfWeight = train.placeWhereIAm.rawType;//Тип сырья - сырье место где поезд находится
                currentMesh.mesh = meshWagon[0];
            }
            if (train.tsScript.tScript == train)
            {
                train.uiScript.wagonCargoSprite[wagonNum].sprite = spriteCargo;
                train.uiScript.wagonTrainMenu[wagonNum].sprite = wagonSprite;
            }
        }
        
        canILoad = true;
    }
    public void Hide()
    {
        isWagonSpawned = false;
        gameObject.transform.position = new Vector3(0, -1000, 0);
    }
    public void GetWagonNumber()
    {
        for (int i = 0; i < train.wagon.Count; i++)
        {
            if (train.wagon[i] == this)
                wagonNum = i;
        }
        for (int v = 0; v < train.wagonsLoad.Count; v++)
        {
            if (train.wagonsLoad[v] == this)
                loadWagonNum = v;
        }
    }
    public void CheckLoadWeight()
    {
        if (typeOfWagon == "Freight")
        {
            if (train.placeWhereIAm.isTown)
                maxLoadWeight = maxLoadProduct * train.wagonSizeRatio;
            else
                maxLoadWeight = maxLoadRaw * train.wagonSizeRatio;
        }
        else
            maxLoadWeight = maxLoadPassenger * train.wagonSizeRatio;
    }
}
