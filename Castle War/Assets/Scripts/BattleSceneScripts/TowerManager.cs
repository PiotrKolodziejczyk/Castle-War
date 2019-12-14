using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    Vector3 offset;
    float mZCoord;
    Vector3 pos;
    public GameObject tower;
    
    bool isTowerMove = true;
    private void Awake()
    {
        //pos = GetMouseWorldPos() + offset;

    }
    private void Update()
    {
        //Debug.Log(Input.mousePosition);
        //if (Input.GetMouseButtonUp(1))
        // {
        //     isTowerMove = false;
        // }
        //if (isTowerMove)
        //{
        //    pos = GetMouseWorldPos() + offset;
        //    tower.transform.position = new Vector3(pos.x, 0, pos.z);

        //}

        MovwTowerToMouse();

    }
    private void OnMouseDrag()
    {
        //MovwTowerToMouse();
    }

    private void MovwTowerToMouse()
    {
        pos = GetMouseWorldPos() + offset;
        tower.transform.position = new Vector3(pos.x, 0, pos.z);
    }

    public void InstantiateTower()
    {
        Instantiate(tower,new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
        mZCoord = Camera.main.WorldToScreenPoint(tower.transform.position).z;
        offset = tower.transform.position - GetMouseWorldPos();
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(tower.transform.position).z;
        offset = tower.transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
