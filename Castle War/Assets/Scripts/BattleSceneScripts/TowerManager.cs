using System.Text.RegularExpressions;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;
    private GameObject tower;
    private bool isDraggingTower = false;
    internal bool building;
    public MeshRenderer[] meshes;
    internal bool mightBuilding = true;
    public Collider[] hitColliders;
    Regex regex;

    float y;
    private void Awake()
    {
        regex = new Regex(@"Tower[ABC]\(Clone\)");
        if (transform.name == "TowerManagerGameObject")
        {
            meshes = GetComponentsInChildren<MeshRenderer>();
        }
        if (transform.tag != "Zero")
        {
            y = 0;
        }
        else
        {
            y = 16;
        }
        Debug.Log(transform.name + y);
    }

    private void Update()
    {

        

        if (isDraggingTower)
        {
            MoveTowerToMouse();
            if (Input.GetMouseButtonDown(0) && tower.GetComponent<TowerManager>().building&& tower.GetComponent<TowerManager>().mightBuilding)
            {
                StopDragging();

            }
        }
        if (GetComponent<TowerManager>().building && GetComponent<TowerManager>().mightBuilding&&regex.IsMatch(GetComponent<TowerManager>().name))
        {
            var meshList = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.white;
            }
        }
        else if(regex.IsMatch(GetComponent<TowerManager>().name))
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


        tower.GetComponent<BoxCollider>().size = new Vector3(4, 2, 4);
        tower.gameObject.name = "Tower";

    }

    private void MoveTowerToMouse()
    {
        Vector3 mousePos = GetMouseWorldPos();
        tower.transform.position = new Vector3(mousePos.x, y, mousePos.z);
    }

    public void InstantiateTowerB()
    {
        tower = Instantiate(towerPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }
    public void InstantiateTowerA()
    {
        tower = Instantiate(towerPrefab1, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        isDraggingTower = true;
        Cursor.visible = false;
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].enabled = true;
        }
    }
    public void InstantiateTowerC()
    {
        tower = Instantiate(towerPrefab2, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
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
        if (other.gameObject.name == "Tower" && regex.IsMatch(GetComponent<TowerManager>().name))
        {
            //var meshList = GetComponentsInChildren<MeshRenderer>();
            //for (int i = 0; i < meshList.Length; i++)
            //{
            //    meshList[i].material.color = Color.red;
            //}
            GetComponent<TowerManager>().mightBuilding = false;
        }




    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tower" )
        {

            //var meshList = GetComponentsInChildren<MeshRenderer>();
            //for (int i = 0; i < meshList.Length; i++)
            //{
            //    meshList[i].material.color = Color.white;
            //}
            GetComponent<TowerManager>().mightBuilding = true;
        }
    }
}









