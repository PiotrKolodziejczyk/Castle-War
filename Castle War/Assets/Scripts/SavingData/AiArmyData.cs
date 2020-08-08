using Assets.Scripts.CastleScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AiArmyData
{
    public int pikemanQuantity;
    public int warriorQuantity;
    public int knightQuantity;
    public int woodTowerQuantity;
    public int stoneTowerQuantity;
    public int greatTowerQuantity;
    public AiArmyData(IArmy aiEngine)
    {
        pikemanQuantity = aiEngine.Army.pikeman.textInputQuantity.quantity;
        warriorQuantity = aiEngine.Army.warrior.textInputQuantity.quantity;
        knightQuantity = aiEngine.Army.knight.textInputQuantity.quantity;
        woodTowerQuantity = aiEngine.Army.woodTower.textInputQuantity.quantity;
        stoneTowerQuantity = aiEngine.Army.stoneTower.textInputQuantity.quantity;
        greatTowerQuantity = aiEngine.Army.greatTower.textInputQuantity.quantity;
    }
}
