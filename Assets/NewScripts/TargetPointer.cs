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
	public float InterfaceScale; // масштаб интерфейса
	private Animator animator;
	private PointerObjectScript pScript;
	private string _reason;
	private bool ict;
	public bool isCamTarget;
	[Space]
	private Vector3 startPointerSize;
	public Camera mainCamera;
	public bool isTargetOn;
    private void Awake()
	{
		pManager = FindObjectOfType<PointerManager>();
		uiScript = FindObjectOfType<UserInterfaceScript>();
		InterfaceScale = pManager.InterfaceScale;
		mainCamera = uiScript.mainScript.cam;
    }
    private void LateUpdate()
	{
		if (isTargetOn == true)
		{ 
			Vector3 realPos = mainCamera.WorldToScreenPoint(Target.position); // получениее экранных координат объекта
			Rect rect = new Rect(0, 0, Screen.width, Screen.height);

			Vector3 outPos = realPos;
			isCamTarget = ict;
			PointerUI.GetComponent<Image>().sprite = OutOfScreenIcon;
			if (rect.Contains(realPos)) // и если цель в окне экрана
			{
				isCamTarget = false;
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
			switch (_reason)
			{
				case "StorageFull":
					{
						animator.SetTrigger("GlobalErrorClose");
						break;
					}
				case "RawIsNotEnough":
					{
						animator.SetTrigger("GlobalErrorClose");
						break;
					}
				case "FirstCitySelect":
					{
						Destroy();
						break;
					}
				case "SecondCitySelect":
					{
						Destroy();
						break;
					}
				case "CityCanBeSelected":
					{
						Destroy();
						break;
					}
				case "NoWagons":
					{
						animator.SetTrigger("GlobalErrorClose");
						break;
					}
				case "TrainIsBroken":
					{
						animator.SetTrigger("GlobalErrorClose");
						break;
					}
				case "PeopleNotEnough":
					{
						animator.SetTrigger("GlobalErrorClose");
						break;
					}
			}
		}
	}
	public void Destroy()
	{
		if (PointerUI != null)
		{
			isTargetOn = false;
			pManager.pointers.Remove(this);
			Destroy(PointerUI.gameObject);
		}
	}
	public void Spawn(GameObject target, string reason, bool isCamToTarget)
	{
		ict = isCamToTarget;
		PointerUI = Instantiate(pref.GetComponent<RectTransform>(), uiScript.canvasPointer.transform);
		pManager.pointers.Add(this);
		pScript = PointerUI.gameObject.GetComponent<PointerObjectScript>();
		animator = PointerUI.gameObject.GetComponent<Animator>();
		pScript.tPointer = this;
		_reason = reason;
		switch (reason)
		{
			case "StorageFull":
				{
					PointerIcon = pManager.storageIsFull;
					OutOfScreenIcon = pManager.globalError;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "RawIsNotEnough":
				{
					PointerIcon = pManager.rawIsNotEnough;
					OutOfScreenIcon = pManager.globalError;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "FirstCitySelect":
				{
					PointerIcon = pManager.firstCitySelect;
					OutOfScreenIcon = pManager.firstCitySelect;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "SecondCitySelect":
				{
					PointerIcon = pManager.secondCitySelect;
					OutOfScreenIcon = pManager.secondCitySelect;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "CityCanBeSelected":
				{
					PointerIcon = pManager.cityCanBeSelect;
					OutOfScreenIcon = pManager.cityCanBeSelect;
					animator.SetTrigger("SelectPointOpen");
					break;
				}
			case "NoWagons":
				{
					PointerIcon = pManager.noWagons;
					OutOfScreenIcon = pManager.noWagons;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "TrainIsBroken":
				{
					PointerIcon = pManager.trainIsBroken;
					OutOfScreenIcon = pManager.globalTrainError;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
			case "PeopleNotEnough":
				{
					PointerIcon = pManager.peopleNotEnough;
					OutOfScreenIcon = pManager.globalError;
					animator.SetTrigger("GlobalErrorOpen");
					break;
				}
		}
		startPointerSize = PointerUI.sizeDelta;
		Target = target.transform;
		isTargetOn = true;
	}
}