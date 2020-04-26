public class Sawmill : Building
{
    private void Update()
    {
        //if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
        //    isBuild = true;
        ElapsedTimeAndBuild(this);
    }
}
