using System.Collections.Generic;
using UnityEngine;

public class AiBuildingTowers : MonoBehaviour
{
    float timer = 4;
    Castle castle;
    public TowerManager towerManager;

    List<Vector3> placesList = new List<Vector3> {
        new Vector3(-90, 22, -397),
        new Vector3(14, 22, -330),
        new Vector3(45, 22, -248),
        new Vector3(18, 22, -190),
        new Vector3(53, 22, -190),
        new Vector3(-81, 22, -121),
        new Vector3(-55, 22, -55),
        new Vector3(13, 22, -55),
        new Vector3(3.7f, 22, -1.4f),
        new Vector3(10, 22, -306) };

    private void Awake()
    {
        castle = GetComponentInParent<Castle>();
    }
    void Update()
    {
        if (!castle.isPlayer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                BuildStoneTower();
                timer = 4;
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
}
