using Assets.Scripts.BattleSceneScripts;
using UnityEngine;

public class AiBuildingInCastle : GameModule
{
    public Castle castle;
    public float time = 20;
    public float timeToBuildPikeman = 5;
    public float timeToBuildWarrior = 5;
    public float timeToBuildKnight = 10;
    public float timeToBuildWoodTower = 5;
    public float timeToBuildStoneTower = 5;
    public float timeToBuildGreatTower = 10;
    public float timeToNextBuild = 20;

    public override void Initialize()
    {
        castle = GetComponentInParent<Castle>();
    }

    private void Update()
    {
        if (!castle.isPlayer)
        {
            if (Global.Timer(ref time))
            {
                ChooseBuildingToBuild();
                time = timeToNextBuild;
            }

            if (Global.Timer(ref timeToBuildPikeman))
            {
                RecruitSoldier(castle.Army.pikeman);
                timeToBuildPikeman = 5;
            }

            if (Global.Timer(ref timeToBuildWarrior))
            {
                RecruitSoldier(castle.Army.warrior);
                timeToBuildWarrior = 5;
            }

            if (Global.Timer(ref timeToBuildKnight))
            {
                RecruitSoldier(castle.Army.warrior);
                timeToBuildKnight = 10;
            }

            if (Global.Timer(ref timeToBuildWoodTower))
            {
                RecruitTower(castle.Army.woodTower);
                timeToBuildWoodTower = 5;
            }

            if (Global.Timer(ref timeToBuildStoneTower))
            {
                RecruitTower(castle.Army.stoneTower);
                timeToBuildStoneTower = 5;
            }

            if (Global.Timer(ref timeToBuildGreatTower))
            {
                RecruitTower(castle.Army.greatTower);
                timeToBuildGreatTower = 10;
            }
        }
    }

    private void RecruitSoldier(Soldier soldier)
    {
        if (castle.barrack.RemoveMaterialIfisTrue(
            soldier.resources.clayToUpgradeLvl,
            soldier.resources.stoneToUpgradeLvl,
            soldier.resources.woodToUpgradeLvl))
            soldier.textInputQuantity.quantity++;
    }

    private void RecruitTower(Tower tower)
    {
        if (castle.towerWorkShop.RemoveMaterialIfisTrue(
            tower.resources.clayToUpgradeLvl,
            tower.resources.stoneToUpgradeLvl,
            tower.resources.woodToUpgradeLvl))
            tower.textInputQuantity.quantity++;
    }

    private void ChooseBuildingToBuild()
    {
        switch (Random.Range(1, 8))
        {
            case 1:
                BuildAppropriateBuilding(castle.sawmill);
                break;
            case 2:
                BuildAppropriateBuilding(castle.barrack);
                break;
            case 3:
                BuildAppropriateBuilding(castle.clayMine);
                break;
            case 4:
                BuildAppropriateBuilding(castle.quarry);
                break;
            case 5:
                BuildAppropriateBuilding(castle.townHall);
                break;
            case 6:
                BuildAppropriateBuilding(castle.towerWorkShop);
                break;
            case 7:
                BuildAppropriateBuilding(castle.smithy);
                break;
            case 8:
                BuildAppropriateBuilding(castle.wall);
                break;
        }
    }

    private void BuildAppropriateBuilding(Building building)
    {
        if (building.RemoveMaterialIfisTrue(
                  building.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                  building.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                  building.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
            building.isBuild = true;
    }
}
