public class Wall : Building
{
    private float timeToCheck = 5;
    private void Update()
    {
        //if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
        //    isBuild = true;
        ElapsedTimeAndBuild(this);
        SetResourcesToUpgrade(100, 120, 150, ref timeToCheck);
    }
}

