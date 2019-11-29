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
        public GameObject townHallButton;
        public void Build()
        {
            townHallButton.SetActive(false);
            isTownHallBuilding = true;
            Build(woodToUpgradeLvl, stoneToUpgradeLvl, clayToUpgradeLvl, buildCourotine, Material.TownHall,townHallLevel);

        }
        private void OnMouseDown()
        {
            if (!isTownHallBuilding)
                townHallButton.SetActive(true);
            buildPanelManager.titleText.text = "TownHall";
            buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
            buildPanelManager.levelText.text = "Level " + townHallLevel;
            buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
            buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
            buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
            panel.SetActive(true);
        }
    }
}
