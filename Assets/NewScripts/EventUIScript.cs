using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIScript : MonoBehaviour
{
    private UserInterfaceScript uiScript;
    public Animator animator;
    public void Awake()
    {
        uiScript = FindObjectOfType<UserInterfaceScript>();
        animator = GetComponent<Animator>();
    }
    public void CloseMenu()
    {
        animator.enabled = true;
        animator.Play("CloseMenuAnim");
    }
    public void OnMenuClosed()
    {
        //uiScript.CloseMenu();
    }
    public void CloseBGFB()
    {
        animator.enabled = true;
        animator.Play("CloseBgFBAnim");
    }
    public void OnMenuOpened()
    {
        animator.enabled = false;
    }
    public void OpenMenu(bool isAnim)
    {
        animator.enabled = isAnim;
    }
    public void OnPriceElementOpen()
    {
        animator.enabled = false;
    }
}
