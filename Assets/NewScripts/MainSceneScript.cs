using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSceneScript : MonoBehaviour
{
    public bool isGamePaused;
    public 
    void Start()
    {
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit))
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return;
            else
            {
                if (isGamePaused == false)
                {

                }
            }
        }
    }
}
