using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerPointerObject : MonoBehaviour
{
    private PointerObjectScript pScript;
    private void Start()
    {
        pScript = GetComponentInParent<PointerObjectScript>();
    }
    private void OnMouseDown()
    {
        pScript.This();
    }
}
