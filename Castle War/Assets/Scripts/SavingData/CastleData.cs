[System.Serializable]
public class CastleData
{
    public int id;
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
    public CastleData(Castle castle)
    {
        id = castle.id;
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
    }
}
