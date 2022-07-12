using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCargoInfo : MonoBehaviour
{
    public GameObject canvas;
    private TextMeshProUGUI text;
    public TrainScript tScript;
    public void ShowInfoTrain(TrainScript train, float price)
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "+" + price + "$";
    }
    public void HideInfo()
    {
        canvas.SetActive(false);
    }
}
