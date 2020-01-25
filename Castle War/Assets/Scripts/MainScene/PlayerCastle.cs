using Assets.Scripts;
using Assets.Scripts.Buldings;
using System.IO;
using UnityEngine;

public class PlayerCastle : Castle
{
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + $"/playerCastle{Global.currentCastle}.fun"))
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
        CastleData castle = SaveSystem.LoadCastle();
        InitializeBuildingsAndRawMaterials(castle);
        InitializeBuildingTexts();
    }

    private void InitializeBuildingsAndRawMaterials(CastleData castle)
    {
        sawmill = GetComponent<Sawmill>();
        clayMine = GetComponent<ClayMine>();
        quarry = GetComponent<Quarry>();
        townHall = GetComponent<TownHall>();
        barrack = GetComponent<Barrack>();
        towerWorkShop = GetComponent<TowerWorkShop>();
        smithy = GetComponent<Smithy>();
        wall = GetComponent<Wall>();
        clay = GetComponent<Clay>();
        stone = GetComponent<Stone>();
        wood = GetComponent<Wood>();
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

    private void InitializeBuildingTexts()
    {
        quarry.text.text = Building.SetText("Quarry", quarry.level);
        sawmill.text.text = Building.SetText("Sawmill", sawmill.level);
        clayMine.text.text = Building.SetText("Clay Mine", clayMine.level);
        barrack.text.text = Building.SetText("Barrack", barrack.level);
        townHall.text.text = Building.SetText("Town Hall", townHall.level);
        smithy.text.text = Building.SetText("Smithy", smithy.level);
        towerWorkShop.text.text = Building.SetText("Tower Workshop", towerWorkShop.level);
        wall.text.text = Building.SetText("Wall", towerWorkShop.level);
        wood.text.text = RawMaterial.SeText("Wood", wood.quantity);
        stone.text.text = RawMaterial.SeText("Stone", stone.quantity);
        clay.text.text = RawMaterial.SeText("Clay", clay.quantity);
    }
}
