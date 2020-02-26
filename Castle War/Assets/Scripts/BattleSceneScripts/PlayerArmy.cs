using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmy : MonoBehaviour
{
    [SerializeField]
    internal int pikinierQuantity;
    internal int warriorQuantity;
    internal int knightQuantity;
    internal int woodTowerQuantity;
    internal int stoneTowerQuantity;
    internal int greatTowerQuantity;
    [SerializeField]
    internal Text pikinierText;
    private void Awake()
    {
        PlayerArmyData army = SaveSystem.LoadPlayerArmy();
        pikinierQuantity = army.pikinierQuantity;
        pikinierText.text = pikinierQuantity.ToString();
    }
    public void MinusPikeman()
    {
        --pikinierQuantity;
        pikinierText.text = pikinierQuantity.ToString();
        SaveSystem.SavePlayerArmyData(this);
    }
}
