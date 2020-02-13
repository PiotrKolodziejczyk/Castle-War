using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public float x;
    public float y;
    public float z;
    public PlayerData(UnitManager player)
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;
    }
}
