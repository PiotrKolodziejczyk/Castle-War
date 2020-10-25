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
    [SerializeField] private GameObject training1;
    [SerializeField] private GameObject trainin2;
    [SerializeField] private GameObject trainin3;
    public void SetCanvas()
    {
        if (!castle.isPlayer)
        {
            woodTower.SetActive(false);
            stoneTower.SetActive(false);
            greatTower.SetActive(false);
        }
        else
        {
            pikeman.SetActive(false);
            warrior.SetActive(false);
            knight.SetActive(false);
        }
    }
}
