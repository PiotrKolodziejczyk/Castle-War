public class Quarry : Building
{
    private void Update()
    {
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
            isBuild = true;
        ElapsedTimeAndBuild(this);
    }
}
