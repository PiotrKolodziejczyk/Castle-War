using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmy : MonoBehaviour
{
    [SerializeField]
    internal Army army;
    private void Awake()
    {
        army = new Army();
        PlayerArmyData armyData = SaveSystem.LoadPlayerArmy();
        army.pikemanInPlayer.quantity = armyData.pikemanQuantity;
        army.warriorInPlayer.quantity = armyData.warriorQuantity;
        army.knightInPlayer.quantity = armyData.knightQuantity;
        army.woodTowerInPlayer.quantity = armyData.woodTowerQuantity;
        army.stoneTowerInPlayer.quantity = armyData.stoneTowerQuantity;
        army.greatTowerInPlayer.quantity = armyData.greatTowerQuantity;
        army.pikemanInPlayer.text.text = army.pikemanInPlayer.quantity.ToString();
        army.warriorInPlayer.text.text = army.warriorInPlayer.quantity.ToString();
        army.knightInPlayer.text.text = army.knightInPlayer.quantity.ToString();
        army.woodTowerInPlayer.text.text = army.woodTowerInPlayer.quantity.ToString();
        army.stoneTowerInPlayer.text.text = army.stoneTowerInPlayer.quantity.ToString();
        army.greatTowerInPlayer.text.text = army.greatTowerInPlayer.quantity.ToString();
    }
    public void MinusPikeman()
    {
        --army.pikemanInPlayer.quantity;
        army.pikemanInPlayer.text.text = army.pikemanInPlayer.quantity.ToString();
        SaveSystem.SavePlayerArmyData(this);
    }
}
