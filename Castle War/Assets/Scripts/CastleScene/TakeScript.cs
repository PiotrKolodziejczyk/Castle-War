using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using UnityEngine;
using UnityEngine.UI;

public class TakeScript : MonoBehaviour
{
    [SerializeField] internal Player player;
    [SerializeField] internal Castle castle;
    [SerializeField] GameObject takePanel;
    public void EnablePanel()
    {
        Global.isSoldierPanelOnInCastleScene = true;
        takePanel.SetActive(true);
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
        SaveSystem.SavePlayerArmyData(this);
    }
    private void SoldierOrTowerSwitching(ref int from, InputField fromInput, ref int to)
    {
        if (from >= int.Parse(fromInput.text))
        {
            from -= int.Parse(fromInput.text);
            to += int.Parse(fromInput.text);
        }
    }
}
