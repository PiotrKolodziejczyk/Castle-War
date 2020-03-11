using Assets.Scripts.CastleScene;
using UnityEngine;

public abstract class Castle : MonoBehaviour, IArmy
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
    [SerializeField] Army army;

    public Army Army { get => army; set => army = value; }

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

