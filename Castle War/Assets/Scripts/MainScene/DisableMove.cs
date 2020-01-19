﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMove : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D curentCursor;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(curentCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
