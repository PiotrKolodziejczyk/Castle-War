using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using UnityEngine;

public class PlayerArmyInBattle : MonoBehaviour
{
    [SerializeField]
    internal Army army;
    private void Start()
    {
        army = GetComponent<Army>();
        PlayerArmyData armyData = SaveSystem.LoadPlayerArmy();
        army.pikeman.textInputQuantity.quantity = armyData.pikemanQuantity;
        army.warrior.textInputQuantity.quantity = armyData.warriorQuantity;
        army.knight.textInputQuantity.quantity = armyData.knightQuantity;
    }

}
