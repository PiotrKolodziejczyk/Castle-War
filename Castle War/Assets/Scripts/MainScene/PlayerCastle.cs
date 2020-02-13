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
        sawmill = GetComponentInChildren<Sawmill>();
        clayMine = GetComponentInChildren<ClayMine>();
        quarry = GetComponentInChildren<Quarry>();
        townHall = GetComponentInChildren<TownHall>();
        barrack = GetComponentInChildren<Barrack>();
        towerWorkShop = GetComponentInChildren<TowerWorkShop>();
        smithy = GetComponentInChildren<Smithy>();
        wall = GetComponentInChildren<Wall>();
        clay = GetComponentInChildren<Clay>();
        stone = GetComponentInChildren<Stone>();
        wood = GetComponentInChildren<Wood>();
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
