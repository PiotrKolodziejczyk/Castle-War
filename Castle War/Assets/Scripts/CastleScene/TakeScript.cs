using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class TakeScript : MonoBehaviour, IArmy, IMaterials
{
    [SerializeField] internal Player player;
    [SerializeField] internal Castle castle;
    [SerializeField] private GameObject takePanel;

    public Army Army { get => player.Army; set => player.Army = value; }
    public Materials Materials { get => player.Materials; set => player.Materials = value; }

    public void EnablePanel()
    {
        Global.isSoldierPanelOnInCastleScene = true;
        takePanel.SetActive(true);

        castle.Army.pikeman.textInputQuantity.input.text = "0";
        castle.Army.warrior.textInputQuantity.input.text = "0";
        castle.Army.knight.textInputQuantity.input.text = "0";
        castle.Army.woodTower.textInputQuantity.input.text = "0";
        castle.Army.stoneTower.textInputQuantity.input.text = "0";
        castle.Army.greatTower.textInputQuantity.input.text = "0";


        player.Army.pikeman.textInputQuantity.input.text = "0";
        player.Army.warrior.textInputQuantity.input.text = "0";
        player.Army.knight.textInputQuantity.input.text = "0";
        player.Army.woodTower.textInputQuantity.input.text = "0";
        player.Army.stoneTower.textInputQuantity.input.text = "0";
        player.Army.greatTower.textInputQuantity.input.text = "0";
    }
    public void ExitPanel()
    {
        Global.isSoldierPanelOnInCastleScene = false;
        takePanel.SetActive(false);
    }

    public void SwitchToPlayer()
    {
        SwitchingAllArmy(castle, player);
    }
    public void SwitchToCastle()
    {
        SwitchingAllArmy(player, castle);
    }
    public void SwitchingAllArmy(IArmy from, IArmy to)
    {
        SoldierOrTowerSwitching(ref from.Army.pikeman.textInputQuantity.quantity,
                                    from.Army.pikeman.textInputQuantity.input,
                                ref to.Army.pikeman.textInputQuantity.quantity);
        SoldierOrTowerSwitching(ref from.Army.warrior.textInputQuantity.quantity,
                                    from.Army.warrior.textInputQuantity.input,
                                ref to.Army.warrior.textInputQuantity.quantity);
        SoldierOrTowerSwitching(ref from.Army.knight.textInputQuantity.quantity,
                                    from.Army.knight.textInputQuantity.input,
                                ref to.Army.knight.textInputQuantity.quantity);
        SoldierOrTowerSwitching(ref from.Army.woodTower.textInputQuantity.quantity,
                                    from.Army.woodTower.textInputQuantity.input,
                                ref to.Army.woodTower.textInputQuantity.quantity);
        SoldierOrTowerSwitching(ref from.Army.stoneTower.textInputQuantity.quantity,
                                    from.Army.stoneTower.textInputQuantity.input,
                                ref to.Army.stoneTower.textInputQuantity.quantity);
        SoldierOrTowerSwitching(ref from.Army.greatTower.textInputQuantity.quantity,
                                    from.Army.greatTower.textInputQuantity.input,
                                ref to.Army.greatTower.textInputQuantity.quantity);
        SaveSystem.SavePlayerArmyData(this, Global.globalInitializingClass.currentSavePlayerArmy);
        SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
    }
    private void SoldierOrTowerSwitching(ref int from, InputField fromInput, ref int to)
    {
        if (from >= int.Parse(fromInput.text))
        {
            from -= int.Parse(fromInput.text);
            to += int.Parse(fromInput.text);
        }
        else
        {
            to += from;
            from = 0;
        }
    }

    public void SetAll()
    {
        castle.Army.pikeman.textInputQuantity.input.text = castle.Army.pikeman.textInputQuantity.quantity.ToString();
        castle.Army.warrior.textInputQuantity.input.text = castle.Army.warrior.textInputQuantity.quantity.ToString();
        castle.Army.knight.textInputQuantity.input.text = castle.Army.knight.textInputQuantity.quantity.ToString();
        castle.Army.woodTower.textInputQuantity.input.text = castle.Army.woodTower.textInputQuantity.quantity.ToString();
        castle.Army.stoneTower.textInputQuantity.input.text = castle.Army.stoneTower.textInputQuantity.quantity.ToString();
        castle.Army.greatTower.textInputQuantity.input.text = castle.Army.greatTower.textInputQuantity.quantity.ToString();

        player.Army.woodTower.textInputQuantity.input.text = player.Army.woodTower.textInputQuantity.quantity.ToString();
        player.Army.stoneTower.textInputQuantity.input.text = player.Army.stoneTower.textInputQuantity.quantity.ToString();
        player.Army.greatTower.textInputQuantity.input.text = player.Army.greatTower.textInputQuantity.quantity.ToString();
        player.Army.pikeman.textInputQuantity.input.text = player.Army.pikeman.textInputQuantity.quantity.ToString();
        player.Army.warrior.textInputQuantity.input.text = player.Army.warrior.textInputQuantity.quantity.ToString();
        player.Army.knight.textInputQuantity.input.text = player.Army.knight.textInputQuantity.quantity.ToString();
    }
}
