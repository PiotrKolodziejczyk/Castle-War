﻿using Assets.Scripts.CastleScene;
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
    [SerializeField] private Texture2D castleTexture;
    [SerializeField] private Texture2D normalTexture;
    [SerializeField] private Texture2D enemyTexture;
    private OptimalizeScript optimalize;
    [SerializeField] private AttackOrDefense AttackOrDefense;
    [SerializeField] private AIEngine aIEngine;
    [SerializeField] private GameObject baseCastle;
    [SerializeField] private Material baseMaterialRed;
    [SerializeField] private Material baseMaterialGreen;

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
   
    private void Start()
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("BattleSceneCastle"))
            AttackOrDefense = FindObjectOfType<AttackOrDefense>();
        if (transform.gameObject.layer == LayerMask.NameToLayer("BattleSceneCastle"))
            aIEngine = FindObjectOfType<AIEngine>();
        army = GetComponent<Army>();
        sawmill = GetComponentInChildren<Sawmill>();
        quarry = GetComponentInChildren<Quarry>();
        clayMine = GetComponentInChildren<ClayMine>();
        barrack = GetComponentInChildren<Barrack>();
        townHall = GetComponentInChildren<TownHall>();
        towerWorkShop = GetComponentInChildren<TowerWorkShop>();
        smithy = GetComponentInChildren<Smithy>();
        wall = GetComponentInChildren<Wall>();
        if (id == 300)
            id = Global.currentCastle;
        if (File.Exists(Application.persistentDataPath + $"/playerCastle{id}.fun"))
        {
            LoadPlayerCastle();
            if (AttackOrDefense != null)
                AttackOrDefense.SetCanvas();
            if (aIEngine != null)
                aIEngine.InitializeAIEngine();
        }
        else
            Debug.LogError("No Loaded Levels");
    }
    private void OnEnable()
    {
        Global.SetAppropriateCursor(normalTexture);
        if (transform.parent.name == "Castles" && isPlayer)
        {
            Transform[] layers = GetComponentsInChildren<Transform>();
            foreach (Transform item in layers)
                item.gameObject.layer = LayerMask.NameToLayer("I");
            GetComponent<OptimalizeScript>().enabled = false;
        }
        //if (transform.parent.name == "Castles" && !isPlayer)
        //    //GetComponent<OptimalizeScript>().enabled = true;
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
        if (isPlayer && transform.parent.name == "Castles")
            baseCastle.GetComponent<MeshRenderer>().material = baseMaterialGreen;
        else if (transform.parent.name == "Castles")
            baseCastle.GetComponent<MeshRenderer>().material = baseMaterialRed;
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
            Global.SetAppropriateCursor(castleTexture);
        else
            Global.SetAppropriateCursor(enemyTexture);
    }

    private void OnMouseExit()
    {
        if (transform.parent.name == "Castles")
            Global.SetAppropriateCursor(normalTexture);
    }


}
