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
    private Sprite _businessSprite;
    [SerializeField]
    private Sprite _rawSprite;

    [SerializeField]
    private int _maxStorageProduct;
    [SerializeField]
    private int _maxStorageRaw;
    [SerializeField]
    private int[] _upgradeCost;
    [SerializeField]
    private int _rawToProduct;
    [SerializeField]
    private int _productFromRaw;
    [SerializeField]
    private float _multiplier;

    public string townName => this._townName;
    public string businessName => this._businessName;
    public string rawName => this._rawName;

    public Sprite businessSprite => this._businessSprite;
    public Sprite rawSprite => this._rawSprite;
    public int maxStorageProduct => this._maxStorageProduct;
    public int maxStorageRaw => this._maxStorageRaw;
    public int[] upgradeCost => this._upgradeCost;
    public int rawToProduct => this._rawToProduct;
    public int productFromRaw => this._productFromRaw;
    public float multiplier => this._multiplier;
}
