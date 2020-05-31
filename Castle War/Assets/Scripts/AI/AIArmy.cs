using Assets.Scripts.CastleScene;
using UnityEngine;

public class AIArmy : MonoBehaviour
{
    public Army army;
    private void Awake()
    {
        army = GetComponent<Army>();
        AiArmyData data = SaveSystem.LoadEnemyArmy();
        army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
        army.warrior.textInputQuantity.quantity = data.warriorQuantity;
        army.knight.textInputQuantity.quantity = data.knightQuantity;
    }

    public void CheckAmontOfArmyInCastle(Castle castle)
    {
        int pikeman = castle.Army.pikeman.textInputQuantity.quantity;
        int warrior = castle.Army.warrior.textInputQuantity.quantity;
        int knight = castle.Army.knight.textInputQuantity.quantity;
        int takePikemanAmount;
        int takeWarriorAmount;
        int takeKnightAmount;
        if (pikeman > 0)
        {
            takePikemanAmount = Random.Range(0, pikeman);
            army.pikeman.textInputQuantity.quantity += takePikemanAmount;
        }
        if (warrior > 0)
        {
            takeWarriorAmount = Random.Range(0, warrior);
            army.warrior.textInputQuantity.quantity += takeWarriorAmount;
        }
        if (knight > 0)
        {
            takeKnightAmount = Random.Range(0, knight);
            army.knight.textInputQuantity.quantity += takeKnightAmount;
        }
        SaveSystem.SaveEnemyArmyData(this);

    }
}
