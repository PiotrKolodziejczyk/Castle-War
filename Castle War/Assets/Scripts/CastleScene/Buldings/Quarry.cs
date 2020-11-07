using UnityEngine.SceneManagement;

public class Quarry : Building
{
    private float timeToCheck = 5;

    public void Start()
    {
        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Quarry.ToString(), this, castle.townHall);
    }

    private void Update()
    {
        ElapsedTimeAndBuild(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.Quarry, this);
        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}
