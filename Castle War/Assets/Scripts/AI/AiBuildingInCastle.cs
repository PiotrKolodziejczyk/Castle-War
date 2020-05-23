using Assets.Scripts.CastleScene.Buldings;
using UnityEngine;

public class AiBuildingInCastle : MonoBehaviour
{
    public Castle castle;
    public float time = 20;
    public Sawmill sawmill;
    void Update()
    {
        if (!castle.isPlayer)
        {
            if (Global.Timer(ref time))
            {
                if (sawmill.RemoveMaterialIfisTrue(sawmill.resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   sawmill.resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   sawmill.resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
                    sawmill.isBuild = true;
                    time = 10000;
            }
        }
    }
}
