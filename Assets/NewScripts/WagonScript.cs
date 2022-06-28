using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonScript : MonoBehaviour
{
    public TrainScript train;
    public float price;
    public string typeOfWagon;
    public string typeOfWeight;
    public float loadWeight;
    public float newLoadWeight;
    public float maxLoadWeight;
    public float speedOfLoading;
    public bool canILoad;
    public bool canIUnload;
    public bool loaded;
    public bool unLoaded;
    public string productOrRaw;

    public int target;
    private int wagonNum;
    public GameObject touchPlace;
    public GameObject secondPlace;
    public float sp;
    public float trnsp;
    private void FixedUpdate()
    {
        if (train.canIMove == true)
        {
            if (wagonNum == 0)
            {
                Vector3 direction = (train.dir.transform.position - secondPlace.transform.position).normalized;
                gameObject.transform.forward = direction;
                gameObject.transform.position += gameObject.transform.forward * (train.speed / sp) * Time.fixedDeltaTime;
                Quaternion lookOnLook = Quaternion.LookRotation(direction);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookOnLook, (train.speed / trnsp) * Time.fixedDeltaTime);
            }
            else
            {
                Vector3 direction = (train.wagon[wagonNum-1].secondPlace.transform.position - secondPlace.transform.position).normalized;
                gameObject.transform.forward = direction;
                gameObject.transform.position += gameObject.transform.forward * (train.speed / sp) * Time.fixedDeltaTime;
                Quaternion lookOnLook = Quaternion.LookRotation(direction);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookOnLook, (train.speed / trnsp) * Time.fixedDeltaTime);
            }
        }
    }
    private void Update()
    {
        if (canILoad == true)
        {
            loadWeight = Mathf.Lerp(loadWeight, newLoadWeight, speedOfLoading);
            if (newLoadWeight - loadWeight <= 0.1f)
            {
                Debug.Log("1");
                loadWeight = newLoadWeight;
                canILoad = false;
            }
        }
    }
    public void Spawn()
    {
        GetWagonNumber();
        gameObject.transform.SetParent(train.transform);
        if(wagonNum == 0)
            gameObject.transform.position = train.touchPlace.transform.position;
        else
            gameObject.transform.position = train.wagon[wagonNum-1].touchPlace.transform.position;
        gameObject.transform.SetParent(train.tsScript.transform);
        if (train.canILoad == true)
            StartCoroutine(CheckLoad());
    }
    public void Hide()
    {
        Debug.Log("Hide " + this);
        gameObject.SetActive(false);
    }
    public void GetWagonNumber()
    {
        for (int i = 0; i < train.wagon.Count; i++)
        {
            if (train.wagon[i] == this)
                wagonNum = i;
        }
    }
    public IEnumerator LoadToTheWagon(string typeWeight, float count, string productRaw)
    {
        productOrRaw = productRaw;
        typeOfWeight = typeWeight;
        newLoadWeight = count;
        canILoad = true;
        yield return new WaitForSeconds(speedOfLoading);
    }
    private IEnumerator UnLoad()
    {
        Debug.Log("kl");
        if (train.placeWhereIAm.isTown == true)
        {
            if (typeOfWagon == "Freight")
            {
                if (productOrRaw == "Raw")
                {
                    if (loadWeight + train.placeWhereIAm.newRaw <= train.placeWhereIAm.maxStorageRaw)
                    {
                        for (int i = 0; i < loadWeight; loadWeight -= 1)
                        {
                            train.placeWhereIAm.ChangeRaw(1);
                            yield return new WaitForSeconds(speedOfLoading / 100);
                        }
                        if (loadWeight == 0)
                        {
                            train.placeWhereIAm.newRaw = Mathf.RoundToInt(train.placeWhereIAm.newRaw);
                            train.placeWhereIAm.rawCount = train.placeWhereIAm.newRaw;
                            unLoaded = true;
                            train.IsWagonsUnLoaded();
                            Debug.Log(train.IsWagonsUnLoaded());
                        }
                    }
                    else
                        StartCoroutine(CheckUnload());
                }
                else if (productOrRaw == "Product")
                {
                    if (loadWeight != 0)
                    {
                        for (int i = 0; i < loadWeight; loadWeight -= 1)
                        {
                            train.tsScript.mainScript.pData.ChangeMoney(gameObject, 1000);
                            yield return new WaitForSeconds(speedOfLoading / 100);
                        }
                        if (loadWeight == 0)
                        {
                            unLoaded = true;
                            train.IsWagonsUnLoaded();
                            Debug.Log(train.IsWagonsUnLoaded());
                        }
                    }
                }
            }
            else if (typeOfWagon == "Passenger")
            {

            }
        }
        else
        {
            unLoaded = true;
            train.IsWagonsUnLoaded();
        }
        StopCoroutine(UnLoad());
    }
    private IEnumerator Load()
    {
        if (train.placeWhereIAm.isTown == true)
        {
            if (typeOfWagon == "Freight")
            {
                if (train.placeWhereIAm.productCount != 0)
                {
                    if (loadWeight <= maxLoadWeight)
                    {
                        if (loadWeight == maxLoadWeight)
                        {
                            typeOfWeight = train.placeWhereIAm.productType;
                            productOrRaw = "Product";
                            loaded = true;
                            train.IsWagonsLoaded();
                            Debug.Log(train.IsWagonsLoaded());
                        }
                        if (train.placeWhereIAm.productCount >= 1)
                        {
                            for (int i = 0; i < maxLoadWeight; i++)
                            {
                                loadWeight += 1;
                                train.placeWhereIAm.ChangeProduct(-1);
                                yield return new WaitForSeconds(speedOfLoading / 100);
                            }
                        }
                    }
                }
                else if (train.placeWhereIAm.productCount == 0 && loadWeight != 0)
                {
                    typeOfWeight = train.placeWhereIAm.productType;
                    productOrRaw = "Product";
                    loaded = true;
                    train.IsWagonsLoaded();
                    Debug.Log(train.IsWagonsLoaded());
                }

            }
            else if (typeOfWagon == "Passenger")
            {

            }
        }
        else
        {
            if (train.placeWhereIAm.newRaw != 0)
            {
                if (loadWeight <= maxLoadWeight)
                {
                    for (int i = 0; i < maxLoadWeight; i++)
                    {
                        if (train.placeWhereIAm.rawCount >= 1)
                        {
                            loadWeight += 1;
                            train.placeWhereIAm.ChangeRaw(-1);
                            yield return new WaitForSeconds(speedOfLoading / 100);
                        }
                    }
                    if (loadWeight == maxLoadWeight)
                    {
                        typeOfWeight = train.placeWhereIAm.rawType;
                        productOrRaw = "Raw";
                        loaded = true;
                        train.IsWagonsLoaded();
                        Debug.Log(train.IsWagonsLoaded());
                    }
                    else if (loadWeight < maxLoadWeight && train.placeWhereIAm.rawCount != 0)
                    {
                        StartCoroutine(Load());
                    }
                    if (train.placeWhereIAm.productCount == 0 && loadWeight != 0)
                    {
                        typeOfWeight = train.placeWhereIAm.productType;
                        productOrRaw = "Product";
                        loaded = true;
                        train.IsWagonsLoaded();
                        Debug.Log(train.IsWagonsLoaded());
                    }
                }
            }
            else if (train.placeWhereIAm.productCount == 0 && loadWeight != 0)
            {
                typeOfWeight = train.placeWhereIAm.productType;
                productOrRaw = "Product";
                loaded = true;
                train.IsWagonsLoaded();
                Debug.Log(train.IsWagonsLoaded());
            }
            else if(train.placeWhereIAm.productCount == 0)
                StartCoroutine(CheckLoad());
        }
    }
    public IEnumerator CheckLoad()
    {
        train.CheckPlace();
        if (typeOfWagon == "Freight")
        {
            if (train.placeWhereIAmGoing.isTown == true)
            {
                if (train.placeWhereIAm.isTown == true)
                    productOrRaw = "Product";
                else
                    productOrRaw = "Raw";

                if (productOrRaw == "Raw")
                {
                    if (train.placeWhereIAm.rawCount != 0)
                        StartCoroutine(Load());
                    else
                    {
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(CheckLoad());
                    }
                }
                else if (productOrRaw == "Product")
                {
                    if (train.placeWhereIAm.newProduct != 0)
                    {
                        StartCoroutine(Load());
                    }
                    else
                    {
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(CheckLoad());
                    }
                }
            }
            else
            {
                StartCoroutine(UnLoad());
            }
        }
        else if (typeOfWagon == "Passenger")
        {

        }
    }
    public IEnumerator CheckUnload()
    {
        canIUnload = false;
        if (typeOfWagon == "Freight")
        {
            if (productOrRaw == "Raw")
            {
                if (train.placeWhereIAm.rawCount + loadWeight <= train.placeWhereIAm.maxStorageRaw)
                    StartCoroutine(UnLoad());
                else
                {
                    yield return new WaitForSeconds(2f);
                    StartCoroutine(CheckUnload());
                }
            }
            else if (productOrRaw == "Product")
            {
                
            }
        }
        else if (typeOfWagon == "Passenger")
        { 
        
        }
    }
}
