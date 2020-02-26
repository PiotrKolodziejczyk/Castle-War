namespace Assets.Scripts.MainScene
{
    [System.Serializable]
    public class PlayerArmyData
    {
        internal int pikinierQuantity;
        //internal int warriorQuantity;
        //internal int knightQuantity;
        //internal int woodTowerQuantity;
        //internal int stoneTowerQuantity;
        //internal int greatTowerQuantity;
        public PlayerArmyData(TakeScript takeScript)
        {
            pikinierQuantity = takeScript.pikinierQuantity;
            //warriorQuantity = takeScript.warriorQuantity;
            //knightQuantity = takeScript.knightQuantity;
            //woodTowerQuantity = takeScript.woodTowerQuantity;
            //stoneTowerQuantity = takeScript.stoneTowerQuantity;
            //greatTowerQuantity = takeScript.greatTowerQuantity;
        }
        public PlayerArmyData(PlayerArmy armyScript)
        {
            pikinierQuantity = armyScript.pikinierQuantity;
            //warriorQuantity = takeScript.warriorQuantity;
            //knightQuantity = takeScript.knightQuantity;
            //woodTowerQuantity = takeScript.woodTowerQuantity;
            //stoneTowerQuantity = takeScript.stoneTowerQuantity;
            //greatTowerQuantity = takeScript.greatTowerQuantity;
        }
    }
}
