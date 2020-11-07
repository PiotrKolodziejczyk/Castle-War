using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sawmill : Building
{

    float timeToCheck = 5;

    private void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Sawmill.ToString(), this, castle.townHall);
    }
    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Sawmill, this);

        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}
