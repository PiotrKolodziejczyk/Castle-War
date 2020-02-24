[System.Serializable]
public class PlayerData
{
    public float x;
    public float y;
    public float z;
    internal int pikinierQuantity;
    internal int warriorQuantity;
    internal int knightQuantity;
    internal int woodTowerQuantity;
    internal int stoneTowerQuantity;
    internal int greatTowerQuantity;
    public PlayerData(UnitManager player, TakeScript takeScript)
    {
        if (player != null)
        {
            x = player.transform.position.x;
            y = player.transform.position.y;
            z = player.transform.position.z;

        }
        if (takeScript != null)
        {
            pikinierQuantity = takeScript.pikinierQuantity;
            warriorQuantity = takeScript.warriorQuantity;
            knightQuantity = takeScript.knightQuantity;
            woodTowerQuantity = takeScript.woodTowerQuantity;
            stoneTowerQuantity = takeScript.stoneTowerQuantity;
            greatTowerQuantity = takeScript.greatTowerQuantity;
        }
    }

}
