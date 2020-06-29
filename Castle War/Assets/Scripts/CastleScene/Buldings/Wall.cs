using UnityEngine.SceneManagement;

public class Wall : Building
{
    private float timeToCheck = 5;
    private void Update()
    {
        //if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
        //    isBuild = true;
        ElapsedTimeAndBuild(this);
        SetResourcesToUpgrade(100, 120, 150, ref timeToCheck);
        if (mainPanel != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            mainPanel.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
    }
}

