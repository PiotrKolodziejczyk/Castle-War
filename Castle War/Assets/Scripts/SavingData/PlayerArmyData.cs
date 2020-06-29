
namespace Assets.Scripts.MainScene
{
    [System.Serializable]
    public class PlayerArmyData
    {
        public int pikemanQuantity;
        public int warriorQuantity;
        public int knightQuantity;
        public int woodTowerQuantity;
        public int stoneTowerQuantity;
        public int greatTowerQuantity;
        public PlayerArmyData(TakeScript takeScript)
        {
            pikemanQuantity = takeScript.player.Army.pikeman.textInputQuantity.quantity;
            warriorQuantity = takeScript.player.Army.warrior.textInputQuantity.quantity;
            knightQuantity = takeScript.player.Army.knight.textInputQuantity.quantity;
            woodTowerQuantity = takeScript.player.Army.woodTower.textInputQuantity.quantity;
            stoneTowerQuantity = takeScript.player.Army.stoneTower.textInputQuantity.quantity;
            greatTowerQuantity = takeScript.player.Army.greatTower.textInputQuantity.quantity;
        }
        public PlayerArmyData(PlayerArmyInBattle armyScript)
        {
            pikemanQuantity = armyScript.army.pikeman.textInputQuantity.quantity;
            warriorQuantity = armyScript.army.warrior.textInputQuantity.quantity;
            knightQuantity = armyScript.army.knight.textInputQuantity.quantity;
            woodTowerQuantity = armyScript.army.woodTower.textInputQuantity.quantity;
            stoneTowerQuantity = armyScript.army.stoneTower.textInputQuantity.quantity;
            greatTowerQuantity = armyScript.army.greatTower.textInputQuantity.quantity;
        }
    }
}
