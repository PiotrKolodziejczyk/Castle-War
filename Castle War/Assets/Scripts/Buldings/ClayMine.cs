﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Buldings
{
    class ClayMine : Building
    {
        
        float currCountdownValue;
        float buildCourotine = 3;
        int woodToUpgradeLvl = 2;
        int stoneToUpgradeLvl = 2;
        int clayToUpgradeLvl = 2;

        private void Start()
        {
           
            StartCoroutine(CollectClayCourotine(timeToCollectClay));
            
        }
       
        void GetClay()
        {
            clayText.text = "Clay : " + claySingleton.Quantity++;
        }
        public IEnumerator CollectClayCourotine(float timeToUpgradeLevel)
        {
            
            currCountdownValue = timeToUpgradeLevel;
            while (currCountdownValue > 0)
            {

                yield return new WaitForSeconds(1.0f);
                currCountdownValue--;

            }
            GetClay();
            StartCoroutine(CollectClayCourotine(timeToCollectClay));

        }
        private void Build()
        {

            Build(woodToUpgradeLvl, stoneToUpgradeLvl, clayToUpgradeLvl, buildCourotine, Material.ClayMine,clayMineLevel);

        }
        private void OnMouseDown()
        {
            
            buildPanelManager.titleText.text = "Clay Mine";
            buildPanelManager.button.onClick.RemoveAllListeners();
            buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
            buildPanelManager.button.onClick.AddListener(Build);
            buildPanelManager.levelText.text = "Level " + clayMineLevel;
            buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
            buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
            buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
            panel.SetActive(true);
        }
    }
}
