using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointerObjectScript : MonoBehaviour
{
    public TargetPointer tPointer;
    public void Close()
    {
        tPointer.Destroy();
    }
    public void This()
    {
        if (tPointer.isCamTarget == true)
        {
            if (tPointer.pManager.mainScript.isTownRawInfoOpened == false)
            {
                if (tPointer.pManager.mainScript.camToTargetCoroutine != null)
                    tPointer.pManager.mainScript.StopCoroutine(tPointer.pManager.mainScript.camToTargetCoroutine);
                tPointer.pManager.mainScript.camToTargetCoroutine = tPointer.pManager.mainScript.CamToTarget(tPointer.gameObject, false, tPointer.pManager.mainScript.camController.newZoom);
                tPointer.pManager.mainScript.StartCoroutine(tPointer.pManager.mainScript.camToTargetCoroutine);
            }
        }
    }
}
