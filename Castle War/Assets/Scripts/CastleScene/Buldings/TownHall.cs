using UnityEngine.SceneManagement;

public class TownHall : Building
{
    private float timeToCheck = 5;

    public void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.TownHall.ToString(), this);
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade*level)
            isBuild = true;
    }
    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.TownHall, this);
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}

