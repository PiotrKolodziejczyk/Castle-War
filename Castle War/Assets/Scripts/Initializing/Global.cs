using Assets.Scripts.GameController;
using Assets.Scripts.HelpingClass;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global
{
    public static string Path = Application.dataPath;
    public static bool PAUSE = false;
    public static string actualPlayerName;
    public static int currentCastle;
    public static string whichScene = Scenes.SampleScene.ToString();
    public static bool isSoldierPanelOnInCastleScene = false;
    public static bool isTowerPanelOnInCastleScene = false;
    public static bool mainPanelActive = false;
    public static bool isCursorOn = false;
    public static bool isArtur;
    public static GlobalInitializingClass globalInitializingClass;
    public static int playerCastles = 1;
    public static bool active = true;
    public static bool treningPanelsActive = false;
    public static bool aiActive = true;
    public static bool isAttackEnemy = false;
    public static Castle currentCastleObject;
    public static void LoadAppropriateSceneTroughtTheLoadingScene(Scenes whichScene, int id)
    {
        Global.currentCastle = id;
        Global.whichScene = whichScene.ToString();
        Global.active = true;
        SceneManager.LoadScene("LoadingScene");
    }
    public static bool Timer(ref float time)
    {
        time -= Time.deltaTime;
        if (time < 0)
            return true;
        return false;
    }
    public static void FirstInitializePlayerCastle(Castle castle)
    {
        castle.sawmill.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("SawMill");
        castle.clayMine.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("clayMine");
        castle.quarry.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("quarry");
        castle.barrack.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("barrack");
        castle.towerWorkShop.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("towerWorkShop");
        castle.smithy.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("smithy");
        castle.townHall.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("townHall");
        castle.wall.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("wall");
        castle.sawmill.level = 1;
        castle.clayMine.level = 1;
        castle.quarry.level = 1;
        castle.barrack.level = 1;
        castle.townHall.level = 1;
        castle.wall.level = 1;
        castle.towerWorkShop.level = 1;
        castle.smithy.level = 1;
        castle.Army.pikeman.textInputQuantity.quantity = 20;
        castle.Army.warrior.textInputQuantity.quantity = 0;
        castle.Army.knight.textInputQuantity.quantity = 0;

        if (castle.Army.pikeman.timeProperties != null)
            castle.Army.pikeman.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("pikeman");
        
        if (castle.Army.warrior.timeProperties != null)
            castle.Army.warrior.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("warrior");
        
        if (castle.Army.knight.timeProperties != null)
            castle.Army.knight.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("knight");

        if (castle.Army.woodTower.timeProperties != null)
            castle.Army.woodTower.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("woodTower");

        if (castle.Army.stoneTower.timeProperties != null)
            castle.Army.stoneTower.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("stoneTower");

        if (castle.Army.greatTower.timeProperties != null)
            castle.Army.greatTower.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("greatTower");

        castle.Army.woodTower.textInputQuantity.quantity = 10;
        castle.Army.stoneTower.textInputQuantity.quantity = 0;
        castle.Army.greatTower.textInputQuantity.quantity = 0;
        castle.isPlayer = true;
        castle.transform.tag = "PlayerCastle";
        castle.transform.gameObject.layer = LayerMask.NameToLayer("I");
        castle.clay.quantity = 2000;
        castle.wood.quantity = 2000;
        castle.stone.quantity = 2000;
        playerCastles--;
    }
    public static void FirstInitializeEnemyCastle(Castle castle)
    {
        castle.sawmill.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("sawmill");
        castle.clayMine.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("clayMine");
        castle.quarry.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("quarry");
        castle.barrack.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("barrack");
        castle.towerWorkShop.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("towerWorkShop");
        castle.smithy.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("smithy");
        castle.townHall.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("townHall");
        castle.wall.timePropertiesBuilding.timeToUpgrade = TimesToUpgrade.GetTime("wall");
        castle.sawmill.level = 1;
        castle.clayMine.level = 1;
        castle.quarry.level = 1;
        castle.barrack.level = 1;
        castle.townHall.level = 1;
        castle.wall.level = 1;
        castle.towerWorkShop.level = 1;
        castle.smithy.level = 1;
        castle.clay.quantity = 2000;
        castle.stone.quantity = 2000;
        castle.wood.quantity = 2000;
        castle.Army.pikeman.textInputQuantity.quantity = 10;
        castle.Army.warrior.textInputQuantity.quantity = 0;
        castle.Army.knight.textInputQuantity.quantity = 0;
        castle.Army.woodTower.textInputQuantity.quantity = 5;
        castle.Army.stoneTower.textInputQuantity.quantity = 2;
        castle.Army.greatTower.textInputQuantity.quantity = 2;

        if (castle.Army.pikeman.timeProperties != null)
            castle.Army.pikeman.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("pikeman");

        if (castle.Army.warrior.timeProperties != null)
            castle.Army.warrior.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("warrior");

        if (castle.Army.knight.timeProperties != null)
            castle.Army.knight.timeProperties.timeToUpgrade = TimesToUpgrade.GetTime("knight");
        castle.isPlayer = false;
        castle.transform.tag = "Untagged";
        castle.transform.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    public static void FirstInitializePlayerPosition(string savingPath)
    {
        UnitManager unitManager = new UnitManager();
        unitManager.transform.position = new Vector3(35, 0.91f, 15);
        SaveSystem.SavePlayerPosition(unitManager, savingPath);
    }
}
public enum Scenes
{
    MenuScene,
    SampleScene,
    BattleScene,
    CastleScene
}
public enum ResourcesEnum
{
    Pikeman,
    Warrior,
    Knight,
    WoodTower,
    StoneTower,
    GreatTower,
    TownHall,
    Barrack,
    TowerWorkShop,
    ClayMine,
    Quarry,
    Sawmill,
    Wall,
    Smithy
}