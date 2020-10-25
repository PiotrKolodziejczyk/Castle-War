using Assets.Scripts.HelpingClass;
using UnityEngine;

public class Initializing
{
    public static void Load(string wchichSave,LoadSavingData savingData)
    {
        Global.actualPlayerName = wchichSave;
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

    public static void Load(string wchichSave)
    {
        Global.actualPlayerName = wchichSave;
        Global.globalInitializingClass = new GlobalInitializingClass();
        Global.globalInitializingClass.nickName = wchichSave;
        Global.globalInitializingClass.currentSaveCastleSave = $"playerCastle{wchichSave}";
        Global.globalInitializingClass.currentSavePlayerPosition = $"playerPosition{wchichSave}";
        Global.globalInitializingClass.currentSaveAiPosition = $"aiPosition{wchichSave}";
        Global.globalInitializingClass.currentSavePlayerArmy = $"playerArmy1{wchichSave}";
        Global.globalInitializingClass.currentSaveEnemyArmy = $"enemyArmy{wchichSave}";
        Global.globalInitializingClass.currentSavePlayerMaterials = $"playerMaterials{wchichSave}";
        SaveSystem.SaveSavingData(Global.globalInitializingClass, wchichSave);
    }
}
