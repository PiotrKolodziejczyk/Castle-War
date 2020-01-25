using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Camera cam;
    public bool isEnabled = false;
    public UnitManager unitManager;
    public bool isMove = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isEnabled&&!isMove)
            {
                cam.enabled = true;
                isEnabled = true;
            }
            else
            {
                cam.enabled = false;
                isEnabled = false;
            }
        }
    }
}
