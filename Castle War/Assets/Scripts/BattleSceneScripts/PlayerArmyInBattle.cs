using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using UnityEngine;

public class PlayerArmyInBattle : GameModule, IArmy
{
    [SerializeField]
    internal Army army;
    public Castle castle;

    public Army Army { get => army; set => army = value; }

    public override void Initialize()
    {
        if (!castle.isPlayer)
        {
            army = transform.parent.GetComponentInChildren<Army>();
            PlayerArmyData armyData = SaveSystem.LoadPlayerArmy(Global.globalInitializingClass.currentSavePlayerArmy);
            army.pikeman.textInputQuantity.quantity = armyData.pikemanQuantity;
            army.warrior.textInputQuantity.quantity = armyData.warriorQuantity;
            army.knight.textInputQuantity.quantity = armyData.knightQuantity;
            army.woodTower.textInputQuantity.quantity = armyData.woodTowerQuantity;
            army.stoneTower.textInputQuantity.quantity = armyData.stoneTowerQuantity;
            army.greatTower.textInputQuantity.quantity = armyData.greatTowerQuantity;
        }

    }

}
