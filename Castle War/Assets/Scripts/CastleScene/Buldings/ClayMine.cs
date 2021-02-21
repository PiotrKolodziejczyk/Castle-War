using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using Assets.Scripts.GameController;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClayMine : Building
{
    private float timeToCheck = 5;


    private void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.ClayMine.ToString(), this, castle.townHall);
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade * level)
            isBuild = true;
    }
   
    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.ClayMine, this);
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            if (panelMain.youNeedMore != null)
            {
                panelMain.youNeedMore.gameObject.SetActive(false);
                isYouNeedMain = false;
            }
        }
    }
   

}
