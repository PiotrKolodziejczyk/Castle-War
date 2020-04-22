using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmyInBattle : MonoBehaviour
{
    [SerializeField]
    internal Army player;
    private void Start()
    {
        player = GetComponent<Army>();
        if (Global.currentCastle < 100)
        {
            AiArmyData armyData = SaveSystem.LoadEnemyArmy();
            player.pikeman.textInputQuantity.quantity = armyData.pikemanQuantity;
            player.warrior.textInputQuantity.quantity = armyData.warriorQuantity;
            player.knight.textInputQuantity.quantity = armyData.knightQuantity;
        }
        else
        {
            PlayerArmyData armyData = SaveSystem.LoadPlayerArmy();
            player.pikeman.textInputQuantity.quantity = armyData.pikemanQuantity;
            player.warrior.textInputQuantity.quantity = armyData.warriorQuantity;
            player.knight.textInputQuantity.quantity = armyData.knightQuantity;
        }
    }
   
}
