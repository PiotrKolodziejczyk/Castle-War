using Assets.Scripts.CastleScene;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Castle : MonoBehaviour, IArmy
{
    [SerializeField] private float time = 10;
    [SerializeField] internal bool isPlayer;
    [SerializeField] internal int id;
    [SerializeField] internal Barrack barrack;
    [SerializeField] internal ClayMine clayMine;
    [SerializeField] internal Quarry quarry;
    [SerializeField] internal Sawmill sawmill;
    [SerializeField] internal Smithy smithy;
    [SerializeField] internal TowerWorkShop towerWorkShop;
    [SerializeField] internal TownHall townHall;
    [SerializeField] internal Wall wall;
    [SerializeField] internal Clay clay;
    [SerializeField] internal Wood wood;
    [SerializeField] internal Stone stone;
    [SerializeField] private Army army;
    [SerializeField] private readonly Texture2D texture;
    [SerializeField] private readonly Texture2D texture1;
    [SerializeField] private readonly Texture2D texture2;
    private readonly OptimalizeScript optimalize;

    public Army Army { get => army; set => army = value; }

    protected void Saving(Castle castle)
    {
        if (Global.Timer(ref time))
        {
            SaveSystem.SaveCastle(castle);
            time = 10;
            Debug.Log("Save!");
        }
    }
    private void Awake()
    {
        army = GetComponent<Army>();
        if (id == 0)
            id = Global.currentCastle;
        if (File.Exists(Application.persistentDataPath + $"/playerCastle{id}.fun"))
            LoadPlayerCastle();
        else
            Debug.LogError("No Loaded Levels");
    }
    private void OnEnable()
    {
        Global.SetAppropriateCursor(texture1);
        if (transform.parent.name == "Castles" && isPlayer)
        {
            Transform[] layers = GetComponentsInChildren<Transform>();
            foreach (Transform item in layers)
                item.gameObject.layer = LayerMask.NameToLayer("I");
            GetComponent<OptimalizeScript>().enabled = false;
        }
        if (transform.parent.name == "Castles" && !isPlayer)
            GetComponent<OptimalizeScript>().enabled = true;
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
        sawmill.timePropertiesBuilding.timeToUpgrade = castle.sawmillBuildingTime;
        clayMine.timePropertiesBuilding.timeToUpgrade = castle.clayMineBuildingTime;
        quarry.timePropertiesBuilding.timeToUpgrade = castle.quarryBuildingTime;
        townHall.timePropertiesBuilding.timeToUpgrade = castle.townHallLevel;
        smithy.timePropertiesBuilding.timeToUpgrade = castle.smithyBuildingTime;
        barrack.timePropertiesBuilding.timeToUpgrade = castle.barrackBuildingTime;
        towerWorkShop.timePropertiesBuilding.timeToUpgrade = castle.towerWorkShopBuildingTime;
        wall.timePropertiesBuilding.timeToUpgrade = castle.wallBuildingTime;
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
        isPlayer = castle.isPlayer;
        transform.tag = castle.tag;
        transform.gameObject.layer = castle.layer;
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
    private void OnMouseEnter()
    {
        if (transform.parent.name == "Castles" && isPlayer)
            Global.SetAppropriateCursor(texture);
        else
            Global.SetAppropriateCursor(texture2);
    }

    private void OnMouseExit()
    {
        if (transform.parent.name == "Castles")
            Global.SetAppropriateCursor(texture1);
    }


}
