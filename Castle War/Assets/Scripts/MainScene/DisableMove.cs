using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMove : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D curentCursor;
    private void Start()
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            transform.name = "NameDisable";
    }
    private void OnMouseEnter()
    {
        Global.SetAppropriateCursor(cursor);
    }
    private void OnMouseExit()
    {
        Global.SetAppropriateCursor(curentCursor);
    }
}
