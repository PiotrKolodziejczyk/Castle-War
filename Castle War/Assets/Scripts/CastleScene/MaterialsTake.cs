using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsTake : MonoBehaviour
{
    [SerializeField] internal Player player;
    [SerializeField] internal Castle castle;
    [SerializeField] private GameObject materialsPanel;


    public void EnablePanel()
    {
        Global.isSoldierPanelOnInCastleScene = true;
        materialsPanel.SetActive(true);
    }
    public void ExitPanel()
    {
        materialsPanel.SetActive(false);
        Global.isSoldierPanelOnInCastleScene = false;
    }

    public void SwitchToPlayer()
    {
        SwitchingAllMaterials(castle, player);
    }
    public void SwitchToCastle()
    {
        SwitchingAllMaterials(player, castle);
    }
    public void SwitchingAllMaterials(IMaterials from, IMaterials to)
    {
        MaterialsSwitching(ref from.Materials.wood.quantity,
                                    from.Materials.wood.input,
                                ref to.Materials.wood.quantity);
        MaterialsSwitching(ref from.Materials.stone.quantity,
                                    from.Materials.stone.input,
                                ref to.Materials.stone.quantity);
        MaterialsSwitching(ref from.Materials.clay.quantity,
                                    from.Materials.clay.input,
                                ref to.Materials.clay.quantity);
        SaveSystem.SavePlayerMaterialsData(this, Global.globalInitializingClass.currentSavePlayerMaterials);
        SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
    }
    private void MaterialsSwitching(ref int from, InputField fromInput, ref int to)
    {
        if (from >= int.Parse(fromInput.text))
        {
            from -= int.Parse(fromInput.text);
            to += int.Parse(fromInput.text);
        }
    }
    public void SetAll()
    {
        castle.Materials.wood.input.text = castle.Materials.wood.quantity.ToString();
        castle.Materials.stone.input.text = castle.Materials.stone.quantity.ToString();
        castle.Materials.clay.input.text = castle.Materials.clay.quantity.ToString();

        player.Materials.wood.input.text = player.Materials.wood.quantity.ToString();
        player.Materials.stone.input.text = player.Materials.stone.quantity.ToString();
        player.Materials.clay.input.text = player.Materials.clay.quantity.ToString();
    }
}
