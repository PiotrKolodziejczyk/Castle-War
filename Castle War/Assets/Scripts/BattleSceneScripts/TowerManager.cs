using System.Text.RegularExpressions;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;
    public Texture2D texture1;
    public Collider[] hitColliders;
    GameObject tower;
    MeshRenderer[] meshes;
    SphereCollider sphere;
    BoxCollider box;
    Regex regex;
    internal bool building;
    internal bool mightBuilding = true;
    bool isDraggingTower = false;
    float y;

    private void Awake()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
        regex = new Regex(@"Tower[ABC]\(Clone\)");
        if (transform.name == "TowerManagerGameObject")
        {
            meshes = GetComponentsInChildren<MeshRenderer>();
        }
    }

    private void Update()
    {
        if (isDraggingTower)
        {
            MoveTowerToMouse();
            if (Input.GetMouseButtonDown(0) && tower.GetComponent<TowerManager>().building && tower.GetComponent<TowerManager>().mightBuilding)
            {
                StopDragging();
            }
        }
        if (GetComponent<TowerManager>().building && GetComponent<TowerManager>().mightBuilding && regex.IsMatch(GetComponent<TowerManager>().name) && gameObject.layer == 11)
        {
            var meshList = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.white;
            }
        }
        else if (regex.IsMatch(GetComponent<TowerManager>().name) && gameObject.layer == 11)
        {
            var meshList = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.red;
            }
        }
    }

    private void StopDragging()
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = false;
        }
        isDraggingTower = false;
        Cursor.visible = true;
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
        if (tower.gameObject.tag == "Zero")
            tower.GetComponent<BoxCollider>().size = new Vector3(15, 2, 15);
        else
            tower.GetComponent<BoxCollider>().size = new Vector3(7, 2, 7);

        tower.gameObject.name = "Tower";
        tower.gameObject.layer = 12;
        tower.GetComponentInChildren<SphereCollider>().enabled = true;
    }

    private void MoveTowerToMouse()
    {
        Vector3 mousePos = GetMouseWorldPos();
        tower.transform.position = new Vector3(mousePos.x, y, mousePos.z);
    }

    public void InstantiateTowerB()
    {
        y = 12;
        tower = Instantiate(towerPrefab, Vector3.zero, new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }
    public void InstantiateTowerA()
    {
        y = 16;
        tower = Instantiate(towerPrefab1, Vector3.zero, new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }
    public void InstantiateTowerC()
    {
        y = 0;
        tower = Instantiate(towerPrefab2, Vector3.zero, new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 250;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Tower" && regex.IsMatch(GetComponent<TowerManager>().name) && other.gameObject.layer == 12)
        {
            GetComponent<TowerManager>().mightBuilding = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tower" && other.gameObject.layer == 12)
        {
            GetComponent<TowerManager>().mightBuilding = true;
        }
    }
}









