using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Buldings
{
    class TownHall : Building
    {
        float buildCourotine = 3;
        int woodToUpgradeLvl = 2;
        int stoneToUpgradeLvl = 2;
        int clayToUpgradeLvl = 2;

        private void Build()
        {

            Build(woodToUpgradeLvl, stoneToUpgradeLvl, clayToUpgradeLvl, buildCourotine, Material.TownHall,townHallLevel);

        }
        private void OnMouseDown()
        {
            
            buildPanelManager.titleText.text = "TownHall";
            buildPanelManager.button.onClick.RemoveAllListeners();
            buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
            buildPanelManager.button.onClick.AddListener(Build);
            buildPanelManager.levelText.text = "Level " + townHallLevel;
            buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
            buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
            buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
            panel.SetActive(true);
        }
    }
}
