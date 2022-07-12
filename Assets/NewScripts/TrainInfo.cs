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
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private string _typeTrain;
    [SerializeField]
    private float _chanceBroke;
    [SerializeField]
    private float _loadingSpeed;


    public string trainName => this._trainName;
    public Sprite spriteTrain => this._spriteTrain;
    public float maxSpeed => this._maxSpeed;
    public float priceTrain => this._priceTrain;
    public float maxHealth => this._maxHealth;
    public string typeTrain => this._typeTrain;
    public float chanceBroke => this._chanceBroke;
    public float loadingSpeed => this._loadingSpeed;
}
