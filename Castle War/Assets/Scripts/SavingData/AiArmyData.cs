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
    public AiArmyData(AIEngine aiEngine)
    {
        pikemanQuantity = aiEngine.army.pikeman.textInputQuantity.quantity;
        warriorQuantity = aiEngine.army.warrior.textInputQuantity.quantity;
        knightQuantity = aiEngine.army.knight.textInputQuantity.quantity;
        //woodTowerQuantity = aiEngine.army.woodTower.textInputQuantity.quantity;
        //stoneTowerQuantity = aiEngine.army.stoneTower.textInputQuantity.quantity;
        //greatTowerQuantity = aiEngine.army.greatTower.textInputQuantity.quantity;
    }
    public AiArmyData(AIArmy aiArmy)
    {
        pikemanQuantity = aiArmy.army.pikeman.textInputQuantity.quantity;
        warriorQuantity = aiArmy.army.warrior.textInputQuantity.quantity;
        knightQuantity = aiArmy.army.knight.textInputQuantity.quantity;
        //woodTowerQuantity = aiEngine.army.woodTower.textInputQuantity.quantity;
        //stoneTowerQuantity = aiEngine.army.stoneTower.textInputQuantity.quantity;
        //greatTowerQuantity = aiEngine.army.greatTower.textInputQuantity.quantity;
    }

}
