using Assets.Scripts.CastleScene;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Castle : MonoBehaviour, IArmy
{
    float time = 10;
    internal bool isPlayer;
    [SerializeField]
    internal int id;
    [SerializeField]
    internal Barrack barrack;
    [SerializeField]
    internal ClayMine clayMine;
    [SerializeField]
    internal Quarry quarry;
    [SerializeField]
    internal Sawmill sawmill;
    [SerializeField]
    internal Smithy smithy;
    [SerializeField]
    internal TowerWorkShop towerWorkShop;
    [SerializeField]
    internal TownHall townHall;
    [SerializeField]
    internal Wall wall;
    [SerializeField]
    internal Clay clay;
    [SerializeField]
    internal Wood wood;
    [SerializeField]
    internal Stone stone;
    [SerializeField] Army army;

    public Army Army { get => army; set => army = value; }

    protected void Saving(Castle castle)
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            SaveSystem.SaveCastle(castle);
            time = 10;
            Debug.Log("Save!");
        }
    }

    private void Awake()
    {
        if (id == 0)
            id = Global.currentCastle;
        if (id < 100)
            isPlayer = true;
        else
            isPlayer = false;
        army = GetComponent<Army>();
    }

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + $"/playerCastle{id}.fun"))
            LoadPlayerCastle();
        else
            Debug.LogError("No Loaded Levels");
    }

    private void Update()
    {
        Saving(this);
    }

    private void LoadPlayerCastle()
    {
        CastleData castle = SaveSystem.LoadCastle(id);
        InitializeBuildingsAndRawMaterials(castle);
        InitializeArmy(castle);
        if (!Regex.Match(transform.name, @"Castle\(Clone\)(\s*\(\d+\))?").Success)
            InitializeBuildingTexts();
    }

    private void InitializeBuildingsAndRawMaterials(CastleData castle)
    {
        id = castle.id;
        sawmill.level = castle.sawmillLevel;
        clayMine.level = castle.clayMineLevel;
        quarry.level = castle.quarryLevel;
        townHall.level = castle.townHallLevel;
        barrack.level = castle.barrackLevel;
        towerWorkShop.level = castle.towerWorkshopLevel;
        smithy.level = castle.smithyLevel;
        wall.level = castle.wallLevel;
        clay.quantity = castle.clay;
        stone.quantity = castle.stone;
        wood.quantity = castle.wood;
    }

    private void InitializeArmy(CastleData castle)
    {
        Army.pikeman.textInputQuantity.quantity = castle.pikeman;
        Army.warrior.textInputQuantity.quantity = castle.warrior;
        Army.knight.textInputQuantity.quantity = castle.knight;
        Army.woodTower.textInputQuantity.quantity = castle.woodTower;
        Army.stoneTower.textInputQuantity.quantity = castle.stoneTower;
        Army.greatTower.textInputQuantity.quantity = castle.greatTower;
    }

    private void InitializeBuildingTexts()
    {
        quarry.buildingText.text = Building.SetText("Quarry", quarry.level);
        sawmill.buildingText.text = Building.SetText("Sawmill", sawmill.level);
        clayMine.buildingText.text = Building.SetText("Clay Mine", clayMine.level);
        barrack.buildingText.text = Building.SetText("Barrack", barrack.level);
        townHall.buildingText.text = Building.SetText("Town Hall", townHall.level);
        smithy.buildingText.text = Building.SetText("Smithy", smithy.level);
        towerWorkShop.buildingText.text = Building.SetText("Tower Workshop", towerWorkShop.level);
        wall.buildingText.text = Building.SetText("Wall", towerWorkShop.level);
        wood.text.text = RawMaterial.SeText("Wood", wood.quantity);
        stone.text.text = RawMaterial.SeText("Stone", stone.quantity);
        clay.text.text = RawMaterial.SeText("Clay", clay.quantity);
    }
}
