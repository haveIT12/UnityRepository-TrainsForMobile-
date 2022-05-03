using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{
    public MainSceneScript mainScript;
    [Header ("TownUI")]
    public TextMeshProUGUI townNameText;
    public TextMeshProUGUI businessNameText;
    public TextMeshProUGUI rawToProductText;
    public TextMeshProUGUI productFromRawText;
    public TextMeshProUGUI newRawToProductText;
    public TextMeshProUGUI newProductFromRawText;
    public TextMeshProUGUI productCountText;
    public TextMeshProUGUI rawCountText;

    public Image publicBussinessSprite;
    public Image publicRawSprite;
    public Image publicBussinessSprite1;
    public Image publicRawSprite1;
    public Image publicBussinessSprite2;
    public Image publicRawSprite2;
    public Image productFullBar;
    public Image rawFullBar;


    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OpenTownRawInfo()
    {
        mainScript.townScript.TownRawCanvas.SetActive(true);
    }
    public void CloseTownRawInfo()
    {
        mainScript.townScript.TownRawCanvas.SetActive(false);
    }
}
