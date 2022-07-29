using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneScript : MonoBehaviour
{
    public TasksSystemScript taskSystem;
    public PlayerData pData;
    public UserInterfaceScript uiScript;
    public TownRawScript townRawScript;
    public RailRoadSystemScript rsScript;
    public GameObject town;
    public Camera cam;
    public CameraController camController;
    public GameObject camRig;
    public PointerManager pManager;
    public PriceListScript plScript;
    public float timeOfLevel;
    public List<TownRawScript> trScript;
    public List<TownRawScript> allTowns;
    public TimerScript timerS;
    public float timeForLvl;
    public float timeForPriceUpdate;
    [Space]
    [Header("SettingsOfLevel")]
    [SerializeField] private float _damageFromRail;
    [SerializeField] private float _chanceDamageFromRail;
    [SerializeField] private float _extraSpeed;
    [SerializeField] private float _extraWagonSize;
    [SerializeField] private float _extraProductionTime;
    [SerializeField] private float _chanceToGetTicket;
    [Space]
    public bool isGamePaused;
    public bool isTownRawOpened;
    public bool isTownRawInfoOpened;
    public bool isNewGame = true;
    public bool isBuildRailOpen;
    public bool isDepotOpen;
    public bool isTrainShopOpen;
    public bool isTrainMenuOpen;
    public bool isSelectWayOpen;
    public IEnumerator camToTargetCoroutine;
    // EXPERIENCE
    [SerializeField] private Image bar_exp;
    [SerializeField] private int lvl;
    [SerializeField] private float _exp;
    [SerializeField] private float _newExp;
    [SerializeField] private float[] _nextExp;//9max +1(0) = 10lvls
    [SerializeField] private float elapsedTimeExp;
    [SerializeField] private float timer = 2f;
    [Space]
    [Header("Shop")]
    [SerializeField] private ShopScript sScript;
    private void Awake()
    {
        uiScript.exp.text = Mathf.RoundToInt(_exp) + "/" + _nextExp[lvl];
    }
    private void Update()
    {
        if (uiScript.idMenu == 999)
        {
            if (_exp != _newExp)
            {
                elapsedTimeExp += Time.deltaTime;
                float perc = elapsedTimeExp / timer;
                _exp = Mathf.Lerp(_exp, _newExp, Mathf.SmoothStep(0, 1, perc));
                uiScript.exp.text = Mathf.RoundToInt(_exp) + "/" + _nextExp[lvl];
            }
            uiScript.fullbarExp.fillAmount = _exp / _nextExp[lvl];
        }
    }
    /*public float GetWagonSize()
    {
        return _extraWagonSize;
    }*/
    /*public float GetChanceBroke()
    {
        return _chanceDamageFromRail;
    }
    public float GetProductionTime()
    {
        return _extraProductionTime;
    }
    public float GetSpeed()
    {
        return _extraSpeed;
    }
    public float GetDamage()
    {
        return _damageFromRail;
    }*/
    public void GamePause()
    { 
    
    }
    public float GetChanceForTicket()
    {
        return _chanceToGetTicket;
    }
    public void GameOver(string name)
    {
        Debug.Log("gameover" + name);
    }
    public void GetDataShop(string name, float count)
    {
        switch (name)
        {
            case "Damage":
                {
                    _damageFromRail = count;
                    break;
                }
            case "ChanceDamage":
                {
                    _chanceDamageFromRail = count;
                    break;
                }
            case "ExtraSpeed":
                {
                    _extraSpeed = count;
                    break;
                }
            case "ExtraWagonsSize":
                {
                    _extraWagonSize = count;
                    break;
                }
            case "ExtraProductionTime":
                {
                    _extraProductionTime = count;
                    break;
                }
        }
    }
    public void ChangeExp(float value)
    {
        _newExp += value;
        if (_newExp >= _nextExp[lvl])
        {
            if(_nextExp.Length > lvl)
                lvl++;
        }
        elapsedTimeExp = 0;
    }
    public void Upgrade() => townRawScript.Upgrade();
    public void OpenTownRaw() => uiScript.OpenTownRaw();
    public IEnumerator CamToTarget(GameObject target, bool isZoom, float zoom)
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 gotopos = new Vector3(target.transform.position.x, camRig.transform.position.y, target.transform.position.z);

        while (elapsedTime < waitTime)
        {
            if (elapsedTime >= 0.2f)
            {
                if (camController.touchZero.phase == TouchPhase.Moved)
                {
                    StopCoroutine(camToTargetCoroutine);
                    yield return null;
                }
            }
            if (isZoom == true)
            {
                camController.newZoom = Mathf.Lerp(camController.newZoom, zoom, (elapsedTime / waitTime));
            }
            camController.newPosition = Vector3.Lerp(camController.newPosition, gotopos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        camController.newPosition = gotopos;
        if(isZoom == true)
            camController.newZoom = zoom;
        yield return null;
    }
}
