using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerManager : MonoBehaviour
{
    public GameObject stoneTower;
    public GameObject woodTower;
    public GameObject greatTower;
    public Texture2D texture1;
    public Collider[] hitColliders;
    public GameObject tower;
    private MeshRenderer[] meshes;
    private SphereCollider sphere;
    private BoxCollider box;
    private Regex regex;
    [SerializeField] internal bool building;
    [SerializeField] internal bool mightBuilding = true;
    private bool isDraggingTower = false;
    [SerializeField] private Castle castle;
    private float y;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
            Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
        regex = new Regex(@"Tower[ABC]\(Clone\)");
        if (transform.name == "TowerManager")
        {
            meshes = GetComponentsInChildren<MeshRenderer>();
        }
    }

    private void Update()
    {
        if (!Global.PAUSE)
        {
            if (isDraggingTower)
            {
                MoveTowerToMouse();
                if (Input.GetMouseButtonDown(0) && tower.GetComponent<TowerManager>().building && tower.GetComponent<TowerManager>().mightBuilding)
                {
                    StopDragging();
                }
            }
            if (building && mightBuilding && regex.IsMatch(name) && gameObject.layer == 11)
            {
                MeshRenderer[] meshList = GetComponentsInChildren<MeshRenderer>();
                for (int i = 0; i < meshList.Length; i++)
                {
                    meshList[i].material.color = Color.white;
                }
            }
            else if (regex.IsMatch(name) && gameObject.layer == 11)
            {
                MeshRenderer[] meshList = GetComponentsInChildren<MeshRenderer>();
                for (int i = 0; i < meshList.Length; i++)
                {
                    meshList[i].material.color = Color.red;
                }
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
        if (SceneManager.GetActiveScene().name == "BattleScene")
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

    public void InstantiateWoodTower()
    {
        if (!isDraggingTower && castle.Army.woodTower.textInputQuantity.quantity > 0)
        {
            castle.Army.woodTower.textInputQuantity.quantity--;
            y = 22;
            tower = Instantiate(woodTower, Vector3.zero, new Quaternion(0, 0, 0, 0));
            isDraggingTower = true;
            Cursor.visible = false;
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = true;
            }
        }
    }
    public void InstantiateStoneTower()
    {
        if (!isDraggingTower && castle.Army.stoneTower.textInputQuantity.quantity > 0)
        {
            castle.Army.stoneTower.textInputQuantity.quantity--;
            y = 22;
            tower = Instantiate(stoneTower, Vector3.zero, new Quaternion(0, 0, 0, 0));
            isDraggingTower = true;
            Cursor.visible = false;
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = true;
            }
        }
    }
    public void InstantiateGreatTower()
    {
        if (!isDraggingTower && castle.Army.greatTower.textInputQuantity.quantity > 0)
        {
            castle.Army.greatTower.textInputQuantity.quantity--;
            y = 0;
            tower = Instantiate(greatTower, Vector3.zero, new Quaternion(0, 0, 0, 0));
            isDraggingTower = true;
            Cursor.visible = false;
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = true;
            }
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
        if (other.gameObject.name == "Tower" && regex.IsMatch(name) && other.gameObject.layer == 12)
        {
            mightBuilding = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tower" && other.gameObject.layer == 12)
        {
            mightBuilding = true;
        }
    }
}









