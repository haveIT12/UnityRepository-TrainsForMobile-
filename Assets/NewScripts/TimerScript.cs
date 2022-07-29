using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private MainSceneScript mainScript;
    public float priceUpdateTime;
    public float timeOfLevel;
    public float currentTimer;
    private void Awake()
    {
        GetTimeOfLevel();
        // load currenttimer
    }
    private void GetTimeOfLevel()
    {
        priceUpdateTime = mainScript.plScript.timeToMode[mainScript.plScript.timesOfUpdate];
        timeOfLevel = mainScript.timeOfLevel;
    }
    private void Update()
    {
        if (!mainScript.isGamePaused)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= timeOfLevel)
            {
                mainScript.GameOver("Fail");
                //stop;
            }
            else if (currentTimer >= priceUpdateTime)
            { 
                //signal pricelist
            }
        }
    }
}
