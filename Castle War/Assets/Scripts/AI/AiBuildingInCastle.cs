using UnityEngine;

public class AiBuildingInCastle : MonoBehaviour
{
    public Castle castle;
    public float time = 20;
    public float timeToBuildPikeman = 5;
    public float timeToNextBuild = 20;
    public Sawmill sawmill;
    public Quarry quarry;
    public ClayMine clayMine;
    public Barrack barrack;
    public TownHall townHall;
    public TowerWorkShop towerWorkShop;
    public Smithy smithy;
    public Wall wall;

    private void Awake()
    {
        castle = GetComponentInParent<Castle>();
        sawmill = GetComponentInChildren<Sawmill>();
        quarry = GetComponentInChildren<Quarry>();
        clayMine = GetComponentInChildren<ClayMine>();
        barrack = GetComponentInChildren<Barrack>();
        townHall = GetComponentInChildren<TownHall>();
        towerWorkShop = GetComponentInChildren<TowerWorkShop>();
        smithy = GetComponentInChildren<Smithy>();
        wall = GetComponentInChildren<Wall>();
        quarry.castle = castle;
        clayMine.castle = castle;
        barrack.castle = castle;
        townHall.castle = castle;
        towerWorkShop.castle = castle;
        smithy.castle = castle;
        wall.castle = castle;
    }

    private void Update()
    {
        if (!castle.isPlayer)
        {
            if (Global.Timer(ref time))
            {
                switch (Random.Range(1, 8))
                {
                    case 1:
                        if (sawmill.RemoveMaterialIfisTrue(sawmill.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   sawmill.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   sawmill.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            sawmill.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 2:
                        if (quarry.RemoveMaterialIfisTrue(quarry.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   quarry.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   quarry.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            quarry.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 3:
                        if (clayMine.RemoveMaterialIfisTrue(clayMine.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   clayMine.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   clayMine.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            clayMine.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 4:
                        if (barrack.RemoveMaterialIfisTrue(barrack.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   barrack.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   barrack.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            barrack.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 5:
                        if (townHall.RemoveMaterialIfisTrue(townHall.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   townHall.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   townHall.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            townHall.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 6:
                        if (towerWorkShop.RemoveMaterialIfisTrue(towerWorkShop.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   towerWorkShop.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   towerWorkShop.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            towerWorkShop.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 7:
                        if (smithy.RemoveMaterialIfisTrue(smithy.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   smithy.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   smithy.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            smithy.isBuild = true;
                        time = timeToNextBuild;
                        break;
                    case 8:
                        if (wall.RemoveMaterialIfisTrue(wall.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   wall.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   wall.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                            wall.isBuild = true;
                        time = timeToNextBuild;
                        break;
                }
            }

            if (Global.Timer(ref timeToBuildPikeman))
            {
                if (barrack.RemoveMaterialIfisTrue(castle.Army.pikeman.resources.clayToUpgradeLvl, castle.Army.pikeman.resources.stoneToUpgradeLvl, castle.Army.pikeman.resources.woodToUpgradeLvl))
                    castle.Army.pikeman.textInputQuantity.quantity++;
                timeToBuildPikeman = 10;
            }

        }
    }
}
