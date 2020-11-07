using Assets.Scripts.HelpingClass;
using UnityEngine;

public class AttackOrDefense : MonoBehaviour
{
    [SerializeField] private Castle castle;
    [SerializeField] private GameObject pikeman;
    [SerializeField] private GameObject warrior;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject woodTower;
    [SerializeField] private GameObject stoneTower;
    [SerializeField] private GameObject greatTower;
    [SerializeField] private GameObject pikemanEnemy;
    [SerializeField] private GameObject warriorEnemy;
    [SerializeField] private GameObject knightEnemy;
    [SerializeField] private GameObject woodTowerEnemy;
    [SerializeField] private GameObject stoneTowerEnemy;
    [SerializeField] private GameObject greatTowerEnemy;

    public void SetCanvas()
    {
        if (!castle.isPlayer)
        {
            woodTower.SetActive(false);
            stoneTower.SetActive(false);
            greatTower.SetActive(false);
            pikemanEnemy.SetActive(false);
            warriorEnemy.SetActive(false);
            knightEnemy.SetActive(false);
        }
        else
        {
            pikeman.SetActive(false);
            warrior.SetActive(false);
            knight.SetActive(false);
            woodTowerEnemy.SetActive(false);
            stoneTowerEnemy.SetActive(false);
            greatTowerEnemy.SetActive(false);
        }
    }
}
