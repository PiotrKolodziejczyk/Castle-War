using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainScene;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : GameModule, IArmy, IMaterials
{
    [SerializeField] private float time = 10;
    [SerializeField] internal bool isPlayer;
    [SerializeField] internal int Id;
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
    [SerializeField] private Materials materials;
    [SerializeField] private Texture2D castleTexture;
    [SerializeField] private Texture2D normalTexture;
    [SerializeField] private Texture2D enemyTexture;
    [SerializeField] private AttackOrDefense AttackOrDefense;
    [SerializeField] private AISoldierController aIEngine;
    [SerializeField] private AiBuildingInCastle aiBuildingInCastle;
    [SerializeField] private GameObject baseCastle;
    [SerializeField] private Material baseMaterialRed;
    [SerializeField] private Material baseMaterialGreen;
    [SerializeField] public TextMeshPro points;
    internal string nick;
    public Army Army { get => army; set => army = value; }
    public Materials Materials { get => materials; set => materials = value; }
    protected void Saving(Castle castle)
    {
        if (Global.Timer(ref time))
        {
            SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
            time = 10;
            Debug.Log("Save!");
        }
    }
    public override void Initialize()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
            points = GetComponentsInChildren<TextMeshPro>().Where(x => x.name == "Points").First();
        if (transform.gameObject.layer == LayerMask.NameToLayer("BattleSceneCastle"))
            AttackOrDefense = FindObjectOfType<AttackOrDefense>();
        if (transform.gameObject.layer == LayerMask.NameToLayer("BattleSceneCastle"))
            aIEngine = FindObjectOfType<AISoldierController>();
        army = GetComponent<Army>();
        if (army == null)
        {
            army = GetComponentInChildren<Army>();
        }
        smithy = GetComponentInChildren<Smithy>();
        smithy.Initialize();
        townHall = GetComponentInChildren<TownHall>();
        townHall.Initialize();
        sawmill = GetComponentInChildren<Sawmill>();
        sawmill.Initialize();
        quarry = GetComponentInChildren<Quarry>();
        quarry.Initialize();
        clayMine = GetComponentInChildren<ClayMine>();
        clayMine.Initialize();
        barrack = GetComponentInChildren<Barrack>();
        barrack.Initialize();
        towerWorkShop = GetComponentInChildren<TowerWorkShop>();
        towerWorkShop.Initialize();
        wall = GetComponentInChildren<Wall>();
        wall.Initialize();
        clay = GetComponent<Clay>();
        clay.Initialize();
        wood = GetComponent<Wood>();
        wood.Initialize();
        stone = GetComponent<Stone>();
        stone.Initialize();
        army.Initialize();
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            PlayerArmyData data = SaveSystem.LoadPlayerArmy(Global.globalInitializingClass.currentSavePlayerArmy);
            if (data != null)
            {
                army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
                army.warrior.textInputQuantity.quantity = data.warriorQuantity;
                army.knight.textInputQuantity.quantity = data.knightQuantity;
                army.woodTower.textInputQuantity.quantity = data.woodTowerQuantity;
                army.stoneTower.textInputQuantity.quantity = data.stoneTowerQuantity;
                army.greatTower.textInputQuantity.quantity = data.greatTowerQuantity;
            }
            else
                Army.InitializeArmyWhenFileNotExist(10, 10, 10, 10, 10, 10);
        }
        if (Id == 200)
            Id = Global.currentCastle;


        LoadPlayerCastle();
        if (AttackOrDefense != null)
            AttackOrDefense.SetCanvas();
        if (aIEngine != null)
            aIEngine.InitializeAIEngine();


        if (SceneManager.GetActiveScene().name != "CastleScene")
        {
            aiBuildingInCastle = GetComponentInChildren<AiBuildingInCastle>();
            aiBuildingInCastle.Initialize();
        }
        Transform[] layers = GetComponentsInChildren<Transform>();
        if (transform.parent.name == "Castles" && isPlayer)
        {
            foreach (Transform item in layers)
                item.gameObject.layer = LayerMask.NameToLayer("I");
        }
        else if (transform.parent.name == "Castles" && !isPlayer)
        {
            foreach (Transform item in layers)
                item.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }

    }
    private void Update()
    {
        if (points != null)
            points.text = CaluclatePoints();
        Saving(this);
    }
    public string CaluclatePoints()
    {
        int points = (barrack.level + towerWorkShop.level + townHall.level + sawmill.level + quarry.level + clayMine.level + smithy.level + wall.level) * 76;
        return points.ToString();
    }
    private void LoadPlayerCastle()
    {
        if (!File.Exists(Global.Path + $"/{Global.globalInitializingClass.currentSaveCastleSave}{Id}.fun"))
        {
            if (Global.playerCastles > 0)
                Global.FirstInitializePlayerCastle(this);
            else
                Global.FirstInitializeEnemyCastle(this);


            if (isPlayer && transform.parent.name == "Castles")
                baseCastle.GetComponent<MeshRenderer>().material = baseMaterialGreen;
            else if (transform.parent.name == "Castles")
                baseCastle.GetComponent<MeshRenderer>().material = baseMaterialRed;
            if (!Regex.Match(transform.name, @"Castle\(Clone\)(\s*\(\d+\))?").Success)
                InitializeBuildingTexts();
            SaveSystem.SaveCastle(this, Global.globalInitializingClass.currentSaveCastleSave);
        }
        else
        {
            CastleData castle = SaveSystem.LoadCastle(Id, Global.globalInitializingClass.currentSaveCastleSave);
            InitializeBuildingsAndRawMaterials(castle);
            InitializeArmy(castle);
            nick = castle.nick;
            if (!Regex.Match(transform.name, @"Castle\(Clone\)(\s*\(\d+\))?").Success)
                InitializeBuildingTexts();
            if (isPlayer && transform.parent.name == "Castles")
                baseCastle.GetComponent<MeshRenderer>().material = baseMaterialGreen;
            else if (transform.parent.name == "Castles")
                baseCastle.GetComponent<MeshRenderer>().material = baseMaterialRed;
        }
    }

    private void InitializeBuildingsAndRawMaterials(CastleData castle)
    {
        Id = castle.id;
        sawmill.timePropertiesBuilding.timeToUpgrade = castle.sawmillBuildingTime;
        clayMine.timePropertiesBuilding.timeToUpgrade = castle.clayMineBuildingTime;
        quarry.timePropertiesBuilding.timeToUpgrade = castle.quarryBuildingTime;
        townHall.timePropertiesBuilding.timeToUpgrade = castle.townHallBuildingTime;
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
        nick = castle.nick;
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
        if (transform.parent.name == "Castles" && isPlayer && SceneManager.GetActiveScene().name == "SampleScene")
            Cursor.SetCursor(castleTexture, Vector2.zero, CursorMode.ForceSoftware);
        else if (!isPlayer && SceneManager.GetActiveScene().name == "SampleScene" && transform.parent.name == "Castles")
            Cursor.SetCursor(enemyTexture, Vector2.zero, CursorMode.ForceSoftware);

    }

    private void OnMouseExit()
    {
        if (transform.parent.name == "Castles" && SceneManager.GetActiveScene().name == "SampleScene")
            Cursor.SetCursor(normalTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
