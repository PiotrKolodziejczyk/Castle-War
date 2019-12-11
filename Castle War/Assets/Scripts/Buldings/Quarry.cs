using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.IO;
using TMPro;
using System.Collections;

namespace Assets.Scripts.Buldings
{
    class Quarry : Building
    {
        float currCountdownValue;
        float buildCourotine = 3;
        int woodToUpgradeLvl = 2;
        int stoneToUpgradeLvl = 2;
        int clayToUpgradeLvl = 2;
        public GameObject quarryButton;
        private void Start()
        {
            StartCoroutine(CollectStoneCourotine(timeToCollectStone));
        }
       
        void GetStone()
        {
            stoneText.text = "Stone : " + stoneSingleton.Quantity++;
        }
        public IEnumerator CollectStoneCourotine(float timeToUpgradeLevel)
        {
            
            currCountdownValue = timeToUpgradeLevel;
            while (currCountdownValue > 0)
            {

                yield return new WaitForSeconds(1.0f);
                currCountdownValue--;

            }
            GetStone();
           StartCoroutine(CollectStoneCourotine(timeToCollectStone));
        }
        public void Build()
        {
            quarryButton.SetActive(false);
            isQuarryBuilding = true;
            Build(buildCourotine, Material.Quarry,quarryLevel);
            woodSingleton.Quantity -= woodToUpgradeLvl;
            claySingleton.Quantity -= clayToUpgradeLvl;
            stoneSingleton.Quantity -= stoneToUpgradeLvl;
        }
        private void OnMouseDown()
        {
            if (!isQuarryBuilding && woodSingleton.Quantity >= woodToUpgradeLvl && claySingleton.Quantity >= clayToUpgradeLvl && stoneSingleton.Quantity >= stoneToUpgradeLvl)
                quarryButton.SetActive(true);
            buildPanelManager.titleText.text = "Quarry";
            buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
            buildPanelManager.levelText.text = "Level " + quarryLevel;
            buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
            buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
            buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
            StartPanel();
        }


    }
}
