using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyArmyData
{
    public int pikemanQuantity;
    public int warriorQuantity;
    public int knightQuantity;
    public EnemyArmyData(AIEngine ai)
    {
        pikemanQuantity = ai.army.pikeman.textInputQuantity.quantity;
        warriorQuantity = ai.army.warrior.textInputQuantity.quantity;
        knightQuantity = ai.army.knight.textInputQuantity.quantity;
    }
}
