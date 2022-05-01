using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUIScript : MonoBehaviour
{
    public UIScript uS;
    public EdgeCollider2D coll;
    private void Start()
    {
        coll = gameObject.GetComponent<EdgeCollider2D>();
    }
    private void OnMouseDown()
    {
        if (gameObject.name == "Rail")
        {
            uS.OpenBuild();
        }
        if (gameObject.name == "Train")
        {
            Debug.Log("Train");
        }
    }
}
