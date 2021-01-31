using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainScene;
using Assets.Scripts.SavingData;
using System.IO;
using UnityEngine;

public class Player :GameModule, IArmy, IMaterials
{
    [SerializeField] private Army army;
    [SerializeField] private Materials materials;
    public Army Army { get => army; set => army = value; }
    public Materials Materials { get => materials; set => materials = value; }


    public override void Initialize()
    {
        LoadAndInitializeDataFromFile(Army);
        LoadAndInitializeMaterialsFromFile(Materials);
    }

    public static void LoadAndInitializeDataFromFile(Army Army)
    {
        if (File.Exists(Global.Path + $"/{Global.globalInitializingClass.currentSavePlayerArmy}.fun"))
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
        {
            if (Global.isArtur)
            {
                Army.InitializeArmyWhenFileNotExist(30, 10, 5, 10, 5, 2);
            }
            else
            {
                Army.InitializeArmyWhenFileNotExist(100, 30, 10, 20, 10, 1);
            }
        }
    }
    public static void LoadAndInitializeMaterialsFromFile(Materials materials)
    {
        if (File.Exists(Global.Path + $"/{Global.globalInitializingClass.currentSavePlayerMaterials}.fun"))
        {
            PlayerMaterialsData data = SaveSystem.LoadPlayerMaterials(Global.globalInitializingClass.currentSavePlayerMaterials);
            materials.wood.quantity = data.woodQuantity;
            materials.stone.quantity = data.stoneQuantity;
            materials.clay.quantity = data.clayQuantity;
        }
        else
            materials.InitializeMaterialsWhenFileNotExist(0);
    }
}
