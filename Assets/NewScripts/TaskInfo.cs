using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskInfo", menuName = "Infos/TaskInfo")]
public class TaskInfo : ScriptableObject
{
    [SerializeField] private string _type;
    [SerializeField] private float _count;
    [SerializeField] private string _nameTask;
    [SerializeField] private string _info;
    [SerializeField] private float _price;
    [SerializeField] private bool _isTicket;
    [SerializeField] private bool _isGeneral;
    [SerializeField] private Sprite _spriteTask;

    public string type => this._type;
    public float count => this._count;
    public string nameTask => this._nameTask;
    public string info => this._info;
    public float price => this._price;
    public bool isTicket => this._isTicket;
    public bool isGeneral => this._isGeneral;
    public Sprite spriteTask => this._spriteTask;
}
