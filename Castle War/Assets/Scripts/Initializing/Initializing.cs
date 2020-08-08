using Assets.Scripts.HelpingClass;
using Assets.Scripts.Trening;
using UnityEngine;

public class Initializing
{
    public static void Load(string wchichSave,LoadSavingData savingData)
    {
        Tutorial.tutorialOn = true;
        Global.actualPlayerName = wchichSave;
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
        Global.globalInitializingClass.currentSavePlayerMaterials = $"playerMaterials{wchichSave}";
        SaveSystem.SaveSavingData(Global.globalInitializingClass, wchichSave);
        SaveSystem.SaveLoadData(wchichSave, savingData);
    }
   
    
  
}
