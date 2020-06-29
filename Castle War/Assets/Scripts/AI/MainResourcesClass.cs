using Assets.Scripts.CastleScene.Buldings;
using System.Linq;

public static class MainResourcesClass
{
    public static void InitializeResources(ref ResourcesToUpgradeLvl resources,ResourcesEnum resourcesEnum, params Building[] buildings)
    {
        switch (resourcesEnum.ToString())
        {
            case "Pikeman":
                resources.clayToUpgradeLvl = 500 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 500 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 500 - buildings[0].level * buildings[1].level;
                break;
            case "Warrior":
                resources.clayToUpgradeLvl = 700 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 700 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 600 - buildings[0].level * buildings[1].level;
                break;
            case "Knight":
                resources.clayToUpgradeLvl = 1000 - buildings[0].level * buildings[1].level;
                resources.woodToUpgradeLvl = 8000 - buildings[0].level * buildings[1].level;
                resources.stoneToUpgradeLvl = 700 - buildings[0].level * buildings[1].level;
                break;
        }
        
    }

}
