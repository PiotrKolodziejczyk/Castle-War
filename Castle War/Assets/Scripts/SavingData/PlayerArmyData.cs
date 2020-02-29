
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
            
            pikemanQuantity = takeScript.army.pikemanInPlayer.quantity;
            warriorQuantity = takeScript.army.warriorInPlayer.quantity;
            knightQuantity = takeScript.army.knightInPlayer.quantity;
            woodTowerQuantity = takeScript.army.woodTowerInPlayer.quantity;
            stoneTowerQuantity = takeScript.army.stoneTowerInPlayer.quantity;
            greatTowerQuantity = takeScript.army.greatTowerInPlayer.quantity;
        }
        public PlayerArmyData(PlayerArmy armyScript)
        {
            pikemanQuantity = armyScript.army.pikemanInPlayer.quantity;
            warriorQuantity = armyScript.army.warriorInPlayer.quantity;
            knightQuantity = armyScript.army.knightInPlayer.quantity;
            woodTowerQuantity = armyScript.army.woodTowerInPlayer.quantity;
            stoneTowerQuantity = armyScript.army.stoneTowerInPlayer.quantity;
            greatTowerQuantity = armyScript.army.greatTowerInPlayer.quantity;
        }
    }
}
