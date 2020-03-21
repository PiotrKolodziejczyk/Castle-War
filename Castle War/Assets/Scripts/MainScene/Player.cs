using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using UnityEngine;

public class Player : MonoBehaviour, IArmy
{
    [SerializeField] Army army;
    public Army Army { get => army; set => army = value; }

    private void Start()
    {
        LoadAndInitializeDataFromFile();
    }

    private void LoadAndInitializeDataFromFile()
    {
        PlayerArmyData data = SaveSystem.LoadPlayerArmy();
        Army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
        Army.warrior.textInputQuantity.quantity = data.warriorQuantity;
        Army.knight.textInputQuantity.quantity = data.knightQuantity;
        Army.woodTower.textInputQuantity.quantity = data.woodTowerQuantity;
        Army.stoneTower.textInputQuantity.quantity = data.stoneTowerQuantity;
        Army.greatTower.textInputQuantity.quantity = data.greatTowerQuantity;
    }
}
