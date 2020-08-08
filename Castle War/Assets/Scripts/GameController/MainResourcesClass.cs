using Assets.Scripts.CastleScene.Buldings;

public static class MainResourcesClass
{
    public static void InitializeResources(ref ResourcesToUpgradeLvl resources, string resourcesEnum, params Building[] buildings)
    {
        switch (resourcesEnum)
        {
            case "Pikeman":
                resources.clayToUpgradeLvl = 101 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 101 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 51 - buildings[0].level * buildings[1].level;
                break;
            case "Warrior":
                resources.clayToUpgradeLvl = 251 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 201 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 251 - buildings[0].level * buildings[1].level;
                break;
            case "Knight":
                resources.clayToUpgradeLvl = 701 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 501 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 601 - buildings[0].level * buildings[1].level;
                break;
            case "WoodTower":
                resources.clayToUpgradeLvl = 201 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 701 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 101 - buildings[0].level * buildings[1].level;
                break;
            case "StoneTower":
                resources.clayToUpgradeLvl = 301 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 201 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 701 - buildings[0].level * buildings[1].level;
                break;
            case "GreatTower":
                resources.clayToUpgradeLvl = 1001 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 501 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 2001 - buildings[0].level * buildings[1].level;
                break;
            case "Barrack":
                resources.clayToUpgradeLvl = 301 * buildings[0].level - (buildings[1].level/2);
                resources.woodToUpgradeLvl = 201 * buildings[0].level - (buildings[1].level / 2);
                resources.stoneToUpgradeLvl = 701 * buildings[0].level - (buildings[1].level / 2);
                break;
            case "TownHall":
                resources.clayToUpgradeLvl = 10101 * buildings[0].level;
                resources.woodToUpgradeLvl = 5101 * buildings[0].level;
                resources.stoneToUpgradeLvl = 10000 * buildings[0].level;
                break;
        }
    }

}
