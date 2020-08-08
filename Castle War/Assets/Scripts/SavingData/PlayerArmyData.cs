
using Assets.Scripts.CastleScene;

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
        public PlayerArmyData(IArmy army)
        {
            pikemanQuantity = army.Army.pikeman.textInputQuantity.quantity;
            warriorQuantity = army.Army.warrior.textInputQuantity.quantity;
            knightQuantity = army.Army.knight.textInputQuantity.quantity;
            woodTowerQuantity = army.Army.woodTower.textInputQuantity.quantity;
            stoneTowerQuantity = army.Army.stoneTower.textInputQuantity.quantity;
            greatTowerQuantity = army.Army.greatTower.textInputQuantity.quantity;
        }
    }
}
