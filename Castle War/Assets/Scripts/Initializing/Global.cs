using Assets.Scripts.HelpingClass;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global
{
    public static int currentCastle;
    public static string whichScene = Scenes.SampleScene.ToString();
    public static bool isSoldierPanelOnInCastleScene = false;
    public static bool isTowerPanelOnInCastleScene = false;
    public static bool mainPanelActive = false;
    public static bool isCursorOn = false;
    public static bool isArtur;
    public static GlobalInitializingClass globalInitializingClass;
    public static int playerCastles = 1;
    public static bool addSoldiers = true;
    public static bool active = true;
    public static bool treningPanelsActive = false;
    public static bool aiActive = true;
    public static bool isAttackEnemy = false;

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
        castle.sawmill.timePropertiesBuilding.timeToUpgrade = 3;
        castle.clayMine.timePropertiesBuilding.timeToUpgrade = 3;
        castle.quarry.timePropertiesBuilding.timeToUpgrade = 3;
        castle.barrack.timePropertiesBuilding.timeToUpgrade = 3;
        castle.towerWorkShop.timePropertiesBuilding.timeToUpgrade = 3;
        castle.smithy.timePropertiesBuilding.timeToUpgrade = 3;
        castle.townHall.timePropertiesBuilding.timeToUpgrade = 3;
        castle.wall.timePropertiesBuilding.timeToUpgrade = 3;
        castle.sawmill.level = 1;
        castle.clayMine.level = 1;
        castle.quarry.level = 1;
        castle.barrack.level = 1;
        castle.townHall.level = 1;
        castle.wall.level = 1;
        castle.towerWorkShop.level = 1;
        castle.smithy.level = 1;
        castle.clay.quantity = 1;
        castle.stone.quantity = 1;
        castle.wood.quantity = 0;
        castle.Army.pikeman.textInputQuantity.quantity = 0;
        castle.Army.warrior.textInputQuantity.quantity = 0;
        castle.Army.knight.textInputQuantity.quantity = 0;
        castle.Army.woodTower.textInputQuantity.quantity = 0;
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
        castle.sawmill.timePropertiesBuilding.timeToUpgrade = 3;
        castle.clayMine.timePropertiesBuilding.timeToUpgrade = 3;
        castle.quarry.timePropertiesBuilding.timeToUpgrade = 3;
        castle.barrack.timePropertiesBuilding.timeToUpgrade = 3;
        castle.towerWorkShop.timePropertiesBuilding.timeToUpgrade = 3;
        castle.smithy.timePropertiesBuilding.timeToUpgrade = 3;
        castle.townHall.timePropertiesBuilding.timeToUpgrade = 3;
        castle.wall.timePropertiesBuilding.timeToUpgrade = 3;
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
    Knight
}