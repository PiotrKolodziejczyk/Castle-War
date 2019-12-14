using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Buldings
{
    class Wall : Building
    {
        float buildCourotine = 3;
        int woodToUpgradeLvl = 2;
        int stoneToUpgradeLvl = 2;
        int clayToUpgradeLvl = 2;
        public GameObject wallButton;
        public void Build()
        {
            wallButton.SetActive(false);
            isWallBuilding = true;
            Build(buildCourotine, Material.Wall,wallLevel);
            woodSingleton.Quantity -= woodToUpgradeLvl;
            claySingleton.Quantity -= clayToUpgradeLvl;
            stoneSingleton.Quantity -= stoneToUpgradeLvl;
        }
        
        private void OnMouseDown()
        {
            if (!isWallBuilding && woodSingleton.Quantity >= woodToUpgradeLvl && claySingleton.Quantity >= clayToUpgradeLvl && stoneSingleton.Quantity >= stoneToUpgradeLvl)
                wallButton.SetActive(true);
            buildPanelManager.titleText.text = "Wall";
            buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
            buildPanelManager.levelText.text = "Level " + wallLevel;
            buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
            buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
            buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
            StartPanel();
        }
    }
}
