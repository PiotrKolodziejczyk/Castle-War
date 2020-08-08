using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClayMine : Building
{
    private float timeToCheck = 5;


    private void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.ClayMine.ToString(), this, castle.townHall);
    }
    
    private void Update()
    {
        ElapsedTimeAndBuild();
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
