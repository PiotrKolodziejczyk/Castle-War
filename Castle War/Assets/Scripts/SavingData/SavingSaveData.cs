using Assets.Scripts.HelpingClass;

namespace Assets.Scripts.SavingData
{
    [System.Serializable]
    public class SavingSaveData
    {
        public string nickName;
        public string currentSaveCastleSave;
        public string currentSavePlayerPosition;
        public string currentSaveAiPosition;
        public string currentSavePlayerArmy;
        public string currentSaveEnemyArmy;
        public string currentSavePlayerMaterials;

        public SavingSaveData(GlobalInitializingClass data)
        {
            nickName = data.nickName;
            currentSaveCastleSave = data.currentSaveCastleSave;
            currentSavePlayerPosition = data.currentSavePlayerPosition;
            currentSaveAiPosition = data.currentSaveAiPosition;
            currentSavePlayerArmy = data.currentSavePlayerArmy;
            currentSaveEnemyArmy = data.currentSaveEnemyArmy;
            currentSavePlayerMaterials = data.currentSavePlayerMaterials;
        }
    }
}
