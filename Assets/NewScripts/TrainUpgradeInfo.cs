using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrainUpgradeInfo", menuName = "Infos/TrainUpgradeInfo")]
public class TrainUpgradeInfo : ScriptableObject
{
    [SerializeField]
    private string _upgradeName;
    [SerializeField]
    private string _upgradeInfo;
    [SerializeField]
    private float _upgradeCount;
    [SerializeField]
    private float _upgradeCost;
    [SerializeField]
    private bool _isTickets;
    [SerializeField]
    private float _breakSpeed;

    public string upgradeName => this._upgradeName;
    public string upgradeInfo => this._upgradeInfo;
    public float upgradeCount => this._upgradeCount;
    public float upgradeCost => this._upgradeCost;
    public bool isTickets => this._isTickets;
    public float breakSpeed => this._breakSpeed;
}
