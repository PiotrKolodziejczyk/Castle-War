using UnityEngine;

public abstract class Castle : MonoBehaviour
{
    float time = 20;
    [SerializeField]
    internal int id;
    internal Barrack barrack;
    internal ClayMine clayMine;
    internal Quarry quarry;
    internal Sawmill sawmill;
    internal Smithy smithy;
    internal TowerWorkShop towerWorkShop;
    internal TownHall townHall;
    internal Wall wall;
    [SerializeField]
    internal Clay clay;
    [SerializeField]
    internal Wood wood;
    [SerializeField]
    internal Stone stone;
    [SerializeField]
    internal int pikeman;
    [SerializeField]
    internal int warrior;
    [SerializeField]
    internal int knight;
    [SerializeField]
    internal int woodTower;
    [SerializeField]
    internal int stoneTower;
    [SerializeField]
    internal int greatTower;
    protected void Saving(PlayerCastle castle)
    {
        //time -= Time.deltaTime;
        //if (time < 0)
        //{
        //    SaveSystem.SaveCastle(castle);
        //    time = 20;
        //    Debug.Log("Save!");
        //}
    }
}

