using Assets.Scripts.HelpingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SavingSaveData(GlobalInitializingClass data)
        {
            this.nickName = data.nickName;
            this.currentSaveCastleSave = data.currentSaveCastleSave;
            this.currentSavePlayerPosition = data.currentSavePlayerPosition;
            this.currentSaveAiPosition = data.currentSaveAiPosition;
            this.currentSaveEnemyArmy = data.currentSaveEnemyArmy;
        }
    }
}
