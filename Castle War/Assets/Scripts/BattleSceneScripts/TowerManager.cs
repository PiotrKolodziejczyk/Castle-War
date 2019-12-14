using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    GameObject tower;
    bool isDraggingTower = false;
    public bool building;

    void Update()
    {
        if (isDraggingTower)
        {
            MoveTowerToMouse();
            if (Input.GetMouseButtonDown(0) && tower.GetComponent<TowerManager>().building)
            {
                StopDragging();

            }
        }
    }
    void StopDragging()
    {

        isDraggingTower = false;
        Cursor.visible = true;
    }
    void MoveTowerToMouse()
    {
        var mousePos = GetMouseWorldPos();
        tower.transform.position = new Vector3(mousePos.x, 0, mousePos.z);
    }

    public void InstantiateTower()
    {
        tower = Instantiate(towerPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
    }
    Vector3 GetMouseWorldPos()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = 95;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}









