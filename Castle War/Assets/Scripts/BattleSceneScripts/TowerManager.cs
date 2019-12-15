using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;
    private bool isDraggingTower = false;
    internal bool building;
    public MeshRenderer[] meshes;
    internal bool mightBuilding = true;
    public Collider[] hitColliders;

    private void Awake()
    {
        if (transform.name == "TowerManagerGameObject")
        {
            meshes = GetComponentsInChildren<MeshRenderer>();
        }
    }

    private void Update()
    {

        if (transform.name == "TowerB(Clone)")
        {
            hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
           
        }

        if (isDraggingTower)
        {
            MoveTowerToMouse();
            if (Input.GetMouseButtonDown(0) && tower.GetComponent<TowerManager>().building&& tower.GetComponent<TowerManager>().mightBuilding)
            {
                StopDragging();

            }
        }
        if (GetComponent<TowerManager>().building && GetComponent<TowerManager>().mightBuilding&&GetComponent<TowerManager>().name=="TowerB(Clone)")
        {
            var meshList = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.white;
            }
        }
        else if(GetComponent<TowerManager>().name == "TowerB(Clone)")
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
        tower.transform.position = new Vector3(mousePos.x, 0, mousePos.z);
    }

    public void InstantiateTower()
    {
        tower = Instantiate(towerPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
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
        if (other.gameObject.name == "Tower" &&gameObject.name == "TowerB(Clone)")
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









