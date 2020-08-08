using System.Collections.Generic;
using UnityEngine;

public class AiBuildingTowers : GameModule
{
    private float timerToBuildWoodTower = 4;
    private float timerToBuildStoneTower = 6;
    private float timerToBuildGreatTower = 10;
    public Castle castle;
    public TowerManager towerManager;
    private readonly List<Vector3> placesList = new List<Vector3> {
        new Vector3(-90, 22, -397),
        new Vector3(14, 22, -330),
        new Vector3(45, 22, -248),
        new Vector3(18, 22, -190),
        new Vector3(70.7f, 22, -190),
        new Vector3(-81, 22, -121),
        new Vector3(-55, 22, -55),
        new Vector3(13, 22, -55),
        new Vector3(3.7f, 22, -1.4f),
        new Vector3(10, 22, -306) };


    private void Update()
    {
        if (!castle.isPlayer && Global.aiActive)
        {
            if (Global.Timer(ref timerToBuildWoodTower))
            {
                BuildWoodTower();
                timerToBuildWoodTower = 4;
            }
            if (Global.Timer(ref timerToBuildStoneTower))
            {
                BuildStoneTower();
                timerToBuildStoneTower = 6;
            }
            if (Global.Timer(ref timerToBuildGreatTower))
            {
                BuildGreatTower();
                timerToBuildGreatTower = 10;
            }
        }
    }
    public void BuildStoneTower()
    {
        if (castle.Army.stoneTower.textInputQuantity.quantity > 0 && placesList.Count > 0)
        {
            int vec = Random.Range(0, placesList.Count);
            castle.Army.stoneTower.textInputQuantity.quantity--;
            towerManager.tower = Instantiate(towerManager.stoneTower, placesList[vec], new Quaternion(0, 0, 0, 0));
            towerManager.tower.GetComponentInChildren<SphereCollider>().enabled = true;
            placesList.RemoveAt(vec);
        }
    }
    public void BuildWoodTower()
    {
        if (castle.Army.woodTower.textInputQuantity.quantity > 0 && placesList.Count > 0)
        {
            int vec = Random.Range(0, placesList.Count);
            castle.Army.woodTower.textInputQuantity.quantity--;
            towerManager.tower = Instantiate(towerManager.woodTower, placesList[vec], new Quaternion(0, 0, 0, 0));
            towerManager.tower.GetComponentInChildren<SphereCollider>().enabled = true;
            placesList.RemoveAt(vec);
        }
    }
    public void BuildGreatTower()
    {
        if (castle.Army.greatTower.textInputQuantity.quantity > 0 && placesList.Count > 0)
        {
            int vec = Random.Range(0, placesList.Count);
            castle.Army.greatTower.textInputQuantity.quantity--;
            towerManager.tower = Instantiate(towerManager.greatTower, new Vector3(placesList[vec].x, 0, placesList[vec].z), new Quaternion(0, 0, 0, 0));
            towerManager.tower.GetComponentInChildren<SphereCollider>().enabled = true;
            placesList.RemoveAt(vec);
        }
    }
}
