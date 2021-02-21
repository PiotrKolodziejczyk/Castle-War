using Assets.Scripts.CastleScene;
using System.IO;
using UnityEngine;

public class AIArmy : MonoBehaviour, IArmy
{
    Army army;
    public Army Army { get => army; set => army = value; }

    private void Awake()
    {
        army = GetComponent<Army>();

        if (!File.Exists(Global.Path + $"/{Global.globalInitializingClass.currentSaveEnemyArmy}.fun"))
        {
            army.pikeman.textInputQuantity.quantity = 30;
            army.warrior.textInputQuantity.quantity = 30;
            army.knight.textInputQuantity.quantity = 30;
            SaveSystem.SaveEnemyArmyData(this, Global.globalInitializingClass.currentSaveEnemyArmy);
        }
        else
        {
            AiArmyData data = SaveSystem.LoadEnemyArmy(Global.globalInitializingClass.currentSaveEnemyArmy);
            army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
            army.warrior.textInputQuantity.quantity = data.warriorQuantity;
            army.knight.textInputQuantity.quantity = data.knightQuantity;
        }
    }

    //AI sprawdza ilosc wojsk w zamku i jezeli jest wieksza od 0 to je zabiera
    public void CheckAmontOfArmyInCastle(Castle castle)
    {
        int pikeman = castle.Army.pikeman.textInputQuantity.quantity;
        int warrior = castle.Army.warrior.textInputQuantity.quantity;
        int knight = castle.Army.knight.textInputQuantity.quantity;
        int takePikemanAmount;
        int takeWarriorAmount;
        int takeKnightAmount;
        if (pikeman > Random.Range(0,50))
        {
            takePikemanAmount = Random.Range(0, pikeman);
            army.pikeman.textInputQuantity.quantity += takePikemanAmount;
        }
        if (warrior > Random.Range(0, 50))
        {
            takeWarriorAmount = Random.Range(0, warrior);
            army.warrior.textInputQuantity.quantity += takeWarriorAmount;
        }
        if (knight > Random.Range(0, 50))
        {
            takeKnightAmount = Random.Range(0, knight);
            army.knight.textInputQuantity.quantity += takeKnightAmount;
        }
        SaveSystem.SaveEnemyArmyData(this, Global.globalInitializingClass.currentSaveEnemyArmy);
    }
}
