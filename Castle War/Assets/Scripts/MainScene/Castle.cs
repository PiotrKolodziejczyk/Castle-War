using UnityEngine;

public abstract class Castle : MonoBehaviour
{
    float time = 10;
    [SerializeField]
    internal int id;
    [SerializeField]
    internal Barrack barrack;
    [SerializeField]
    internal ClayMine clayMine;
    [SerializeField]
    internal Quarry quarry;
    [SerializeField]
    internal Sawmill sawmill;
    [SerializeField]
    internal Smithy smithy;
    [SerializeField]
    internal TowerWorkShop towerWorkShop;
    [SerializeField]
    internal TownHall townHall;
    [SerializeField]
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
        time -= Time.deltaTime;
        if (time < 0)
        {
            SaveSystem.SaveCastle(castle);
            time = 10;
            Debug.Log("Save!");
        }
    }
}

