using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.MainScene;
using Assets.Scripts.SavingData;
using System.IO;
using TMPro;
using UnityEngine;

public class UnitManager : GameModule, IArmy
{
    [SerializeField] private TextMeshPro namePlayer;
    private RaycastHit hit = new RaycastHit();
    private RaycastHit hit1 = new RaycastHit();
    private Ray ray;
    public Animator animator;
    public AudioSource audioSource;
    public Moving moving;
    private readonly float startTime;
    public Camera cam;
    public float x;
    public float y;
    public float z;
    private Vector3 position;
    [SerializeField] private GameObject playerArtur;
    [SerializeField] private GameObject playerKnight;
    [SerializeField] internal Army army;
    public TextMeshProUGUI pikeman;
    public TextMeshProUGUI warrior;
    public TextMeshProUGUI knight;
    public TextMeshProUGUI woodTower;
    public TextMeshProUGUI stoneTower;
    public TextMeshProUGUI greatTower;
    public Materials materials;
    private float time = 3;

    public Army Army { get => army; set => army = value; }

    public override void Initialize()
    {
        namePlayer.text = Global.actualPlayerName;
        LoadAndInitializeDataFromFile();
        LoadAndInitializeMaterialsFromFile();
        //if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerArmy}.fun"))
        //{
        //    PlayerArmyData data = SaveSystem.LoadPlayerArmy(Global.globalInitializingClass.currentSavePlayerArmy);
        //    army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
        //    army.warrior.textInputQuantity.quantity = data.warriorQuantity;
        //    army.knight.textInputQuantity.quantity = data.knightQuantity;
        //    army.woodTower.textInputQuantity.quantity = data.woodTowerQuantity;
        //    army.stoneTower.textInputQuantity.quantity = data.stoneTowerQuantity;
        //    army.greatTower.textInputQuantity.quantity = data.greatTowerQuantity;
        //}
        //else
        //{
        //    army.pikeman.textInputQuantity.quantity = 0;
        //    army.warrior.textInputQuantity.quantity = 0;
        //    army.knight.textInputQuantity.quantity = 0;
        //    army.woodTower.textInputQuantity.quantity = 0;
        //    army.stoneTower.textInputQuantity.quantity = 0;
        //    army.greatTower.textInputQuantity.quantity = 0;
        //}

        //if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerMaterials}.fun"))
        //{
        //    PlayerMaterialsData data = SaveSystem.LoadPlayerMaterials(Global.globalInitializingClass.currentSavePlayerMaterials);
        //    materials.wood.quantity = data.woodQuantity;
        //    materials.stone.quantity = data.stoneQuantity;
        //    materials.clay.quantity = data.clayQuantity;
        //}
        //else
        //{
        //    materials.wood.quantity = 0;
        //    materials.stone.quantity = 0;
        //    materials.clay.quantity = 0;
        //}

        pikeman.text = "Pikemans " + army.pikeman.textInputQuantity.quantity.ToString();
        warrior.text = "Warriors " + army.warrior.textInputQuantity.quantity.ToString();
        knight.text = "Knights " + army.knight.textInputQuantity.quantity.ToString();
        woodTower.text = "Wood Towers " + army.woodTower.textInputQuantity.quantity.ToString();
        stoneTower.text = "Stone Towers " + army.stoneTower.textInputQuantity.quantity.ToString();
        greatTower.text = "Great Towers " + army.greatTower.textInputQuantity.quantity.ToString();
        moving = new Moving();
        if (Global.isArtur)
            playerArtur.SetActive(true);
        else
            playerKnight.SetActive(true);

        if (!File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerPosition}.fun"))
        {
            transform.position = new Vector3(35, 0.09998721f, 30.9081f);
            SaveSystem.SavePlayerPosition(this, Global.globalInitializingClass.currentSavePlayerPosition);
        }
        else
        {
            PlayerPositionData data = SaveSystem.LoadPlayerPosition(Global.globalInitializingClass.currentSavePlayerPosition);
            position = new Vector3(data.x, data.y, data.z);
            transform.position = position;
        }

    }
    private void Update()
    {
        if (!Global.PAUSE)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit1);
            cam.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);

            if (!Global.treningPanelsActive && Global.active && Input.GetMouseButtonDown(0) && hit1.transform.gameObject.layer == LayerMask.NameToLayer("Grass") /*&& !moving.isMove*/)
            {
                ShotRayAndAcceptMove();
            }

            if (moving.isMove && hit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
                Move();
            SavingArmy();
        }
    }
    protected void SavingArmy()
    {
        if (Global.Timer(ref time))
        {
            SaveSystem.SavePlayerArmyData(this, Global.globalInitializingClass.currentSavePlayerArmy);
            time = 3;
            Debug.Log("SaveArmy!");
        }
    }
    private void ShotRayAndAcceptMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.transform.gameObject.layer != LayerMask.NameToLayer("UI"))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) > 0.3f)
            {
                animator.SetBool("isRun", true);
                if (!audioSource.isPlaying)
                    audioSource.Play();
                moving.AcceptMove(hit.transform.position, transform);
            }
        }
    }

    private void Move()
    {
        moving.StartMoving(hit.transform.position, transform);
        moving.StopMoving(hit.transform.position, transform.position, animator, audioSource);
        SaveSystem.SavePlayerPosition(this, Global.globalInitializingClass.currentSavePlayerPosition);
    }

    private void LoadAndInitializeDataFromFile()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerArmy}.fun"))
        {
            PlayerArmyData data = SaveSystem.LoadPlayerArmy(Global.globalInitializingClass.currentSavePlayerArmy);
            Army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
            Army.warrior.textInputQuantity.quantity = data.warriorQuantity;
            Army.knight.textInputQuantity.quantity = data.knightQuantity;
            Army.woodTower.textInputQuantity.quantity = data.woodTowerQuantity;
            Army.stoneTower.textInputQuantity.quantity = data.stoneTowerQuantity;
            Army.greatTower.textInputQuantity.quantity = data.greatTowerQuantity;
        }
        else
        {
            if (Global.isArtur)
            {
                Army.InitializeArmyWhenFileNotExist(30, 10, 5, 10, 5, 2);
            }
            else
            {
                Army.InitializeArmyWhenFileNotExist(100, 30, 10, 20, 10, 1);
            }
        }
    }
    private void LoadAndInitializeMaterialsFromFile()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerMaterials}.fun"))
        {
            PlayerMaterialsData data = SaveSystem.LoadPlayerMaterials(Global.globalInitializingClass.currentSavePlayerMaterials);
            materials.wood.quantity = data.woodQuantity;
            materials.stone.quantity = data.stoneQuantity;
            materials.clay.quantity = data.clayQuantity;
        }
        else
            materials.InitializeMaterialsWhenFileNotExist(0);
    }
}
