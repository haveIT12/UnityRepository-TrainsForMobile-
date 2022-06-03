using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrainInfo", menuName = "Infos/TrainInfo")]
public class TrainInfo : ScriptableObject
{
    [SerializeField]
    private string _trainName;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private Sprite _spriteTrain;
    [SerializeField]
    private float _priceTrain;

    public string trainName => this._trainName;
    public Sprite spriteTrain => this._spriteTrain;
    public float maxSpeed => this._maxSpeed;
    public float priceTrain => this._priceTrain;
}
