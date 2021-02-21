using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using Assets.Scripts.GameController;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smithy : Building
{
    private float timeToCheck = 5;

    private void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Smithy.ToString(), this, castle.townHall);
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade * level)
            isBuild = true;
    }
    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Smithy, this);
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }

    private void OnMouseDown()
    {
        if (!Global.mainPanelActive && Global.isSoldierPanelOnInCastleScene == false && Global.isTowerPanelOnInCastleScene == false)
            OnEnablePanel();
    }
}

