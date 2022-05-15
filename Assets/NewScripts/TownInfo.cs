using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TownInfo", menuName = "Infos/TownInfo")]
public class TownInfo : ScriptableObject
{
    [SerializeField]
    private string _townName;
    [SerializeField]
    private string _businessName;
    [SerializeField]
    private string _rawName;

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
    private float[] _upgradeCost;
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

    public string townName => this._townName;
    public string businessName => this._businessName;
    public string rawName => this._rawName;

    public Sprite rawSpriteImage => this._rawSpriteImage;
    public Sprite businessSprite => this._businessSprite;
    public Sprite rawSprite => this._rawSprite;
    public int maxStorageProduct => this._maxStorageProduct;
    public int maxStorageRaw => this._maxStorageRaw;
    public float[] newProductFromRaw => this._newProductFromRaw;
    public float[] newRawToProduct => this._newRawToProduct;
    public float[] upgradeCost => this._upgradeCost;
    public int rawToProduct => this._rawToProduct;
    public int productFromRaw => this._productFromRaw;
    public float multiplier => this._multiplier;
    public float timeForProduct => this._timeForProduct;
}
