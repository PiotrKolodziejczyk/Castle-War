public class ClayMine : Building
{
    private void Update()
    {
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
            isBuild = true;
        ElapsedTimeAndBuild(this);
    }
}
