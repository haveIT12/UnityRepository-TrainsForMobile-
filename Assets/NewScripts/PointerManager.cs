using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour
{
	[Header("Sprites")]
	public Sprite globalError;
	public Sprite rawIsNotEnough;
	public Sprite storageIsFull;
	public Sprite firstCitySelect;
	public Sprite secondCitySelect;
	public Sprite cityCanBeSelect;
	public Sprite noWagons;
	public Sprite trainIsBroken;
	public Sprite globalTrainError;
	public Sprite peopleNotEnough;
	public float InterfaceScale;
	public List<TargetPointer> pointers;
	public MainSceneScript mainScript;

	public void HideAll()
	{
		for (int i = 0; i < pointers.Count; i++)
		{
			pointers[i].Hide();
		}
	}
}
