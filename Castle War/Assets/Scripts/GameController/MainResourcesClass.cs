using Assets.Scripts.CastleScene.Buldings;

public static class MainResourcesClass
{
    public static void InitializeResources(ref ResourcesToUpgradeLvl resources, string resourcesEnum, params Building[] buildings)
    {
        switch (resourcesEnum)
        {
            case "Pikeman":
                resources.clayToUpgradeLvl = 101 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 124 - buildings[0].level * buildings[1].level;
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
                resources.clayToUpgradeLvl = 101 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 501 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 201 - buildings[0].level * buildings[1].level;
                break;
            case "Barrack":
                resources.clayToUpgradeLvl = 301 * buildings[0].level - (buildings[1].level /2);
                resources.woodToUpgradeLvl = 201 * buildings[0].level - (buildings[1].level / 2);
                resources.stoneToUpgradeLvl = 701 * buildings[0].level - (buildings[1].level / 2);
                break;
            case "TownHall":
                resources.clayToUpgradeLvl = 101 * buildings[0].level;
                resources.woodToUpgradeLvl = 501 * buildings[0].level;
                resources.stoneToUpgradeLvl = 100 * buildings[0].level;
                break;
            case "ClayMine":
                resources.clayToUpgradeLvl = 301 * buildings[0].level - (buildings[1].level / 2);
                resources.woodToUpgradeLvl = 201 * buildings[0].level - (buildings[1].level / 2);
                resources.stoneToUpgradeLvl = 701 * buildings[0].level - (buildings[1].level / 2);
                break;
            case "Wall":
                resources.clayToUpgradeLvl = 101 * buildings[0].level - (buildings[1].level / 2); ;
                resources.woodToUpgradeLvl = 511 * buildings[0].level - (buildings[1].level / 2); ;
                resources.stoneToUpgradeLvl = 100 * buildings[0].level - (buildings[1].level / 2); ;
                break;
            case "Quarry":
                resources.clayToUpgradeLvl = 301 * buildings[0].level - (buildings[1].level / 2);
                resources.woodToUpgradeLvl = 201 * buildings[0].level - (buildings[1].level / 2);
                resources.stoneToUpgradeLvl = 701 * buildings[0].level - (buildings[1].level / 2);
                break;
            case "TowerWorkShop":
                resources.clayToUpgradeLvl = 101 * buildings[0].level - (buildings[1].level / 2); ;
                resources.woodToUpgradeLvl = 501 * buildings[0].level - (buildings[1].level / 2); ;
                resources.stoneToUpgradeLvl = 111 * buildings[0].level - (buildings[1].level / 2); ;
                break;
            case "Sawmill":
                resources.clayToUpgradeLvl = 101 * buildings[0].level - (buildings[1].level / 2); ;
                resources.woodToUpgradeLvl = 501 * buildings[0].level - (buildings[1].level / 2); ;
                resources.stoneToUpgradeLvl = 111 * buildings[0].level - (buildings[1].level / 2); ;
                break;
            case "Smithy":
                resources.clayToUpgradeLvl = 101 * buildings[0].level - (buildings[1].level / 2); ;
                resources.woodToUpgradeLvl = 501 * buildings[0].level - (buildings[1].level / 2); ;
                resources.stoneToUpgradeLvl = 111 * buildings[0].level - (buildings[1].level / 2); ;
                break;
        }
    }

}
