[System.Serializable]
public class PlayerPositionData
{
    public float x;
    public float y;
    public float z;

    public PlayerPositionData(UnitManager player)
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;
    }

}
