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
    private bool canILoad;
    private bool canIUnload;
    public string productOrRaw;
    private void Update()
    {
        /*if (canILoad == true)
        {
            Debug.Log("15");
            loadWeight = Mathf.Lerp(loadWeight, newLoadWeight, speedOfLoading);
            if (newLoadWeight - loadWeight <= 0.1f)
            {
                Debug.Log("16");
                loadWeight = newLoadWeight;
                canILoad = false;
            }
        }
        if (canIUnload == true)
        {
            Debug.Log("17");
            if (typeOfWagon == "Freight")
            {
                Debug.Log("18");
                if (productOrRaw == "Raw")
                {
                    Debug.Log("19");
                }
                if (loadWeight + train.placeWhereIAm.newRaw <= train.placeWhereIAm.maxStorageRaw)
                {
                    Debug.Log("20");
                    loadWeight = Mathf.Lerp(loadWeight, 0, speedOfLoading);
                    train.placeWhereIAm.newRaw = Mathf.Lerp(train.placeWhereIAm.newRaw, train.placeWhereIAm.newRaw + loadWeight, speedOfLoading);
                }
                else
                {
                    Debug.Log("21");
                    StartCoroutine(CheckUnLoad());
                }
            }
            else if (typeOfWagon == "Passenger")
            {

            }
        }*/
    }
    public IEnumerator LoadToTheWagon(string typeWeight, float count, string productRaw)
    {
        Debug.Log("12");
        productOrRaw = productRaw;
        typeOfWeight = typeWeight;
        newLoadWeight = count;
        canILoad = true;
        yield return new WaitForSeconds(speedOfLoading);
    }
    public IEnumerator UnLoadTheWagon()
    {
        Debug.Log("13");
        if (loadWeight != 0)
        {
            Debug.Log("22");
            if (typeOfWagon == "Freight")
            {
                Debug.Log("23");
                if (productOrRaw == "Raw")
                {
                    Debug.Log("24");
                    if (train.placeWhereIAm.rawType == typeOfWeight)
                    {
                        Debug.Log("25");
                        canIUnload = true;
                        yield return new WaitForSeconds(speedOfLoading);
                    }
                }
                if (productOrRaw == "Product")
                {
                    Debug.Log("26");
                    canIUnload = true;
                    yield return new WaitForSeconds(speedOfLoading);
                }
            }     
        }
    }
    public IEnumerator CheckUnLoad()
    {
        Debug.Log("14");
        canIUnload = false;
        yield return new WaitForSeconds(2f);
        canILoad = true;
    }
}
