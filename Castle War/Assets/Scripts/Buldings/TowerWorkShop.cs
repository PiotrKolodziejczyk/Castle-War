using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerWorkShop : Building
{
    float buildCourotine = 3;
    int woodToUpgradeLvl = 2;
    int stoneToUpgradeLvl = 2;
    int clayToUpgradeLvl = 2;

    private void Build()
    {

        Build(woodToUpgradeLvl, stoneToUpgradeLvl, clayToUpgradeLvl, buildCourotine, Material.TowerWorkshop,towerWorkshopLevel);

    }
    private void OnMouseDown()
    {
        
        buildPanelManager.titleText.text = "Tower Workshop";
        buildPanelManager.button.onClick.RemoveAllListeners();
        buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
        buildPanelManager.button.onClick.AddListener(Build);
        buildPanelManager.levelText.text = "Level " + towerWorkshopLevel;
        buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
        buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
        buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
        panel.SetActive(true);
    }
}
