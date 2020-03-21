using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOrDefense : MonoBehaviour
{
    [SerializeField]Castle castle;
    [SerializeField] GameObject pikeman;
    [SerializeField] GameObject warrior;
    [SerializeField] GameObject knight;
    [SerializeField] GameObject woodTower;
    [SerializeField] GameObject stoneTower;
    [SerializeField] GameObject greatTower;
    void Start()
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

    void Update()
    {
        
    }
}
