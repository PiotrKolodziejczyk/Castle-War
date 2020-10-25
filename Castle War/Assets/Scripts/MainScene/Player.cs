using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainScene;
using Assets.Scripts.SavingData;
using System.IO;
using TMPro;
using UnityEngine;

public class Player : GameModule, IArmy, IMaterials
{
    [SerializeField] private Army army;
    [SerializeField] private Materials materials;
    public Army Army { get => army; set => army = value; }
    public Materials Materials { get => materials; set => materials = value; }

    public override void Initialize()
    {
        LoadAndInitializeDataFromFile();
        LoadAndInitializeMaterialsFromFile();
    }
    private void LoadAndInitializeDataFromFile()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerArmy}.fun"))
        {
            PlayerArmyData data = SaveSystem.LoadPlayerArmy(Global.globalInitializingClass.currentSavePlayerArmy);
            Army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
            Army.warrior.textInputQuantity.quantity = data.warriorQuantity;
            Army.knight.textInputQuantity.quantity = data.knightQuantity;
            Army.woodTower.textInputQuantity.quantity = data.woodTowerQuantity;
            Army.stoneTower.textInputQuantity.quantity = data.stoneTowerQuantity;
            Army.greatTower.textInputQuantity.quantity = data.greatTowerQuantity;
        }
        else
            Army.InitializeArmyWhenFileNotExist(0);
    }
    private void LoadAndInitializeMaterialsFromFile()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Global.globalInitializingClass.currentSavePlayerMaterials}.fun"))
        {
            PlayerMaterialsData data = SaveSystem.LoadPlayerMaterials(Global.globalInitializingClass.currentSavePlayerMaterials);
            Materials.wood.quantity = data.woodQuantity;
            Materials.stone.quantity = data.stoneQuantity;
            Materials.clay.quantity = data.clayQuantity;
        }
        else
            Materials.InitializeMaterialsWhenFileNotExist(0);
    }
}
