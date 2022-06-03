using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public TrainInfo tInfo;
    public string trainName;
    public float maxSpeed;
    public Sprite trainSprite;
    public Sprite firstWagonDepot;
    public Sprite secondWagonDepot;
    public Sprite thirdWagonDepot;
    public Sprite fourthWagonDepot;
    void Awake()
    {
        trainName = tInfo.trainName;
        trainSprite = tInfo.spriteTrain;
        maxSpeed = tInfo.maxSpeed;
    }
}
