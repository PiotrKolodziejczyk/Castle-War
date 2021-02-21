using UnityEngine.SceneManagement;

public class Wall : Building
{
    private float timeToCheck = 5;

    public void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Wall.ToString(), this, castle.townHall);
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade * level)
            isBuild = true;
    }
    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Wall, this);
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}

