using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TargetPointer : MonoBehaviour
{
	public PointerManager pManager;
	public UserInterfaceScript uiScript;
	public Transform Target; // цель
	public RectTransform PointerUI; // объект Image UI
	public GameObject pref;
	public Sprite PointerIcon; // иконка когда цель в поле видимости
	public Sprite OutOfScreenIcon; // иконка когда цель за приделами экрана	
	public float InterfaceScale = 100; // масштаб интерфейса
	[Space]
	private Vector3 startPointerSize;
	public Camera mainCamera;
	public bool isTargetOn;
    private void Awake()
    {
		pManager = FindObjectOfType<PointerManager>();
		uiScript = FindObjectOfType<UserInterfaceScript>();
		mainCamera = uiScript.mainScript.cam;
    }
    private void LateUpdate()
	{
		if (isTargetOn == true)
		{ 
			Vector3 realPos = mainCamera.WorldToScreenPoint(Target.position); // получениее экранных координат объекта
			Rect rect = new Rect(0, 0, Screen.width, Screen.height);

			Vector3 outPos = realPos;

			PointerUI.GetComponent<Image>().sprite = OutOfScreenIcon;
			if (rect.Contains(realPos)) // и если цель в окне экрана
			{
				PointerUI.GetComponent<Image>().sprite = PointerIcon;
			}

			float offset = PointerUI.sizeDelta.x / 2;
			outPos.x = Mathf.Clamp(outPos.x, offset, Screen.width - offset);
			outPos.y = Mathf.Clamp(outPos.y, offset, Screen.height - offset);
			Vector3 pos = realPos - outPos; // направление к цели из PointerUI 

			PointerUI.sizeDelta = new Vector2(startPointerSize.x / 100 * InterfaceScale, startPointerSize.y / 100 * InterfaceScale);
			PointerUI.anchoredPosition = outPos;
		}
	}
	public void Hide()
	{
		if (PointerUI != null)
		{ 
			isTargetOn = false;
			Destroy(PointerUI.gameObject);
			PointerUI = null;
		}
	}
	public void Spawn(GameObject target, string reason)
	{
		PointerUI = Instantiate(pref.GetComponent<RectTransform>(), uiScript.canvasPointer.transform);
		switch (reason)
		{
			case "StorageFull":
				{
					PointerIcon = pManager.storageIsFull;
					OutOfScreenIcon = pManager.globalError;
					break;
				}
			case "RawIsNotEnough":
				{
					PointerIcon = pManager.rawIsNotEnough;
					OutOfScreenIcon = pManager.globalError;
					break;
				}
			case "FirstCitySelect":
				{
					PointerIcon = pManager.firstCitySelect;
					OutOfScreenIcon = pManager.firstCitySelect;
					break;
				}
			case "SecondCitySelect":
				{
					PointerIcon = pManager.secondCitySelect;
					OutOfScreenIcon = pManager.secondCitySelect;
					break;
				}
			case "CityCanBeSelected":
				{
					PointerIcon = pManager.cityCanBeSelect;
					OutOfScreenIcon = pManager.cityCanBeSelect;
					break;
				}
			case "NoWagons":
				{
					PointerIcon = pManager.noWagons;
					OutOfScreenIcon = pManager.globalTrainError;
					break;
				}
			case "TrainIsBroken":
				{
					PointerIcon = pManager.trainIsBroken;
					OutOfScreenIcon = pManager.globalTrainError;
					break;
				}
		}
		startPointerSize = PointerUI.sizeDelta;
		Target = target.transform;
		isTargetOn = true;
	}
}