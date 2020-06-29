using Assets.Scripts.HelpingClass;
using UnityEngine;

public class Initializing
{
    public static void Load(string wchichSave,LoadSavingData savingData)
    {
        TrainingManager.train = true;
        TrainingManager.firstLevelOfTrainingCastleScene = true;
        TrainingManager.firstTrainingLevelOnMainScene = true;
        TrainingManager.firstTrainingLevelOnCastleScene = true;
        TrainingManager.firstTrainingLevelOnBattleScene = true;
        Global.globalInitializingClass = new GlobalInitializingClass();
        Global.globalInitializingClass.nickName = wchichSave;
        Global.globalInitializingClass.currentSaveCastleSave = $"playerCastle{wchichSave}";
        Global.globalInitializingClass.currentSavePlayerPosition = $"playerPosition{wchichSave}";
        Global.globalInitializingClass.currentSaveAiPosition = $"aiPosition{wchichSave}";
        Global.globalInitializingClass.currentSavePlayerArmy = $"playerArmy1{wchichSave}";
        Global.globalInitializingClass.currentSaveEnemyArmy = $"enemyArmy{wchichSave}";
        SaveSystem.SaveSavingData(Global.globalInitializingClass, wchichSave);
        SaveSystem.SaveLoadData(wchichSave, savingData);
    }
   
    
  
}
