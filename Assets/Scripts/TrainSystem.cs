using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSystem : MonoBehaviour
{
    public MainScript mScript;
    public UIScript uiS;
    public CityScript cScript;
    public GameObject[] trains;
    public GameObject[] SpawnPos;
    public GameObject trainClone;
    public TrainScript tScript;
    public Road[] road;
    public int numberTrain;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void BuyTrain()
    { 
        
    }
    public void BuyTrain1()
    {
        trainClone = Instantiate(trains[0], SpawnPos[0].transform.position, trains[0].transform.rotation);
        trainClone.gameObject.GetComponent<TrainScript>().number = numberTrain;
        trainClone.gameObject.GetComponent<TrainScript>().road = road[0];
        numberTrain++;
    }
    public void BuyTrain2()
    {
        trainClone = Instantiate(trains[1], SpawnPos[0].transform.position, trains[1].transform.rotation);
        trainClone.gameObject.GetComponent<TrainScript>().number = numberTrain;
        trainClone.gameObject.GetComponent<TrainScript>().road = road[1];
        numberTrain++;
    }
}
