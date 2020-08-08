﻿using Assets.Scripts.SavingData;

[System.Serializable]
public class CastleData
{
    public string nick;
    public int id;
    public float sawmillBuildingTime;
    public float clayMineBuildingTime;
    public float quarryBuildingTime;
    public float barrackBuildingTime;
    public float towerWorkShopBuildingTime;
    public float smithyBuildingTime;
    public float townHallBuildingTime;
    public float wallBuildingTime;
    public short sawmillLevel;
    public short clayMineLevel;
    public short quarryLevel;
    public short barrackLevel;
    public short townHallLevel;
    public short wallLevel;
    public short towerWorkshopLevel;
    public short smithyLevel;
    public int clay;
    public int stone;
    public int wood;
    internal int pikeman;
    internal int warrior;
    internal int knight;
    internal int woodTower;
    internal int stoneTower;
    internal int greatTower;
    internal bool isPlayer;
    internal string tag;
    internal int layer;
    public CastleData(Castle castle)
    {
        id = castle.Id;
        nick = castle.nick;
        sawmillBuildingTime = castle.sawmill.timePropertiesBuilding.timeToUpgrade;
        clayMineBuildingTime = castle.clayMine.timePropertiesBuilding.timeToUpgrade;
        quarryBuildingTime = castle.quarry.timePropertiesBuilding.timeToUpgrade;
        barrackBuildingTime = castle.barrack.timePropertiesBuilding.timeToUpgrade;
        towerWorkShopBuildingTime = castle.towerWorkShop.timePropertiesBuilding.timeToUpgrade;
        smithyBuildingTime = castle.smithy.timePropertiesBuilding.timeToUpgrade;
        townHallBuildingTime = castle.townHall.timePropertiesBuilding.timeToUpgrade;
        wallBuildingTime = castle.wall.timePropertiesBuilding.timeToUpgrade;
        sawmillLevel = castle.sawmill.level;
        clayMineLevel = castle.clayMine.level;
        quarryLevel = castle.quarry.level;
        barrackLevel = castle.barrack.level;
        townHallLevel = castle.townHall.level;
        wallLevel = castle.wall.level;
        towerWorkshopLevel = castle.towerWorkShop.level;
        smithyLevel = castle.smithy.level;
        clay = castle.clay.quantity;
        stone = castle.stone.quantity;
        wood = castle.wood.quantity;
        pikeman = castle.Army.pikeman.textInputQuantity.quantity;
        warrior = castle.Army.warrior.textInputQuantity.quantity;
        knight = castle.Army.knight.textInputQuantity.quantity;
        woodTower = castle.Army.woodTower.textInputQuantity.quantity;
        stoneTower = castle.Army.stoneTower.textInputQuantity.quantity;
        greatTower = castle.Army.greatTower.textInputQuantity.quantity;
        isPlayer = castle.isPlayer;
        tag = castle.transform.tag;
        layer = castle.transform.gameObject.layer;
    }
}
