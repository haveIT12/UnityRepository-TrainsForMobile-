using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TownInfo", menuName = "Infos/TownInfo")]
public class TownInfo : ScriptableObject
{
    [SerializeField]
    private string _townName;
    [SerializeField]
    private string _businessName;
    [SerializeField]
    private string _rawName;
    [SerializeField]
    private string _typeRaw;
    [SerializeField]
    private string _typeProduct;

    [SerializeField]
    private Sprite _rawSpriteImage;
    [SerializeField]
    private Sprite _businessSprite;
    [SerializeField]
    private Sprite _rawSprite;

    [SerializeField]
    private int _maxStorageProduct;
    [SerializeField]
    private int _maxStorageRaw;
    [SerializeField]
    private float[] _maxStorageProductNew;
    [SerializeField]
    private float[] _maxStorageRawNew;
    [SerializeField]
    private float[] _upgradeCost;
    [SerializeField]
    private bool[] _isUpgradeTicket;
    [SerializeField]
    private int _rawToProduct;
    [SerializeField]
    private int _productFromRaw;
    [SerializeField]
    private float _multiplier;
    [SerializeField]
    private float _timeForProduct;
    [SerializeField]
    private float[] _newProductFromRaw;
    [SerializeField]
    private float[] _newRawToProduct;
    [SerializeField]
    private float[] _newTimeForProduct;
    [SerializeField]
    private float _timeForPeople;
    [SerializeField]
    private float[] _timeForPeopleNext;
    [SerializeField]
    private float[] _maxPeopleNext;
    [SerializeField]
    private float _maxPeople;
    [SerializeField]
    private float _peopleForTime;
    [SerializeField]
    private float[] _peopleForTimeNext;
    //RAW PEOPLE
    [SerializeField]
    private float _peopleToRaw;
    [SerializeField]
    private float[] _newPeopleToRaw;
    [SerializeField]
    private float _timeForRaw;
    [SerializeField]
    private float[] _newTimeForRaw;
    [SerializeField]
    private float _rawFromPeople;
    [SerializeField]
    private float[] _newRawFromPeople;
    [SerializeField]
    private Sprite _resourceToRaw;
    [SerializeField]
    private int _lvlOpenSecondStorage;

    public string townName => this._townName;
    public string businessName => this._businessName;
    public string rawName => this._rawName;
    public string typeRaw => this._typeRaw;
    public string typeProduct => this._typeProduct;
    public Sprite rawSpriteImage => this._rawSpriteImage;
    public Sprite businessSprite => this._businessSprite;
    public Sprite rawSprite => this._rawSprite;
    public float maxStorageProduct => this._maxStorageProduct;
    public float maxStorageRaw => this._maxStorageRaw;
    public float[] maxStorageProductNew => this._maxStorageProductNew;
    public float[] maxStorageRawNew => this._maxStorageRawNew;
    public float[] newProductFromRaw => this._newProductFromRaw;
    public float[] newRawToProduct => this._newRawToProduct;
    public float[] upgradeCost => this._upgradeCost;
    public bool[] isUpggradeTicket => this._isUpgradeTicket;
    public int rawToProduct => this._rawToProduct;
    public int productFromRaw => this._productFromRaw;
    public float multiplier => this._multiplier;
    public float timeForProduct => this._timeForProduct;
    public float[] newTimeForProduct => this._newTimeForProduct;
    public float timeForPeople => this._timeForPeople;
    public float[] timeForPeopleNext => this._timeForPeopleNext;
    public float peopleForTime => this._peopleForTime;
    public float[] peopleForTimeNext => this._peopleForTimeNext;


    public float[] maxPeopleNext => this._maxPeopleNext;
    public float maxPeople => this._maxPeople;

    //RAW PEOPLE
    public float peopleToRaw => this._peopleToRaw;
    public float[] newPeopleToRaw => this._newPeopleToRaw;
    public float timeForRaw => this._timeForRaw;
    public float[] newTimeForRaw => this._newTimeForRaw;
    public float rawFromPeople => this._rawFromPeople;
    public float[] newRawFromPeople => this._newRawFromPeople;
    public Sprite resourceToRaw => this._resourceToRaw;
    public int lvlOpenSecondStorage => this._lvlOpenSecondStorage;
}
