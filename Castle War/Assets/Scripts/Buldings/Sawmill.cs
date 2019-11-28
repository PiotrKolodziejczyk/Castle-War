using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Sawmill : Building
{
    float currCountdownValue;
    float buildCourotine = 3;
    int woodToUpgradeLvl = 2;
    int stoneToUpgradeLvl = 2;
    int clayToUpgradeLvl = 2;


    private void Start()
    {
        StartCoroutine(CollectWoodCourotine(timeToCollectWood));
    }

    private void Build()
    {
        
        Build(woodToUpgradeLvl, stoneToUpgradeLvl, clayToUpgradeLvl,buildCourotine, Material.Sawmill,sawmillLevel);
        
    }

    void GetWood()
    {
        woodText.text = "Wood : " + woodSingleton.Quantity++;
    }
    public IEnumerator CollectWoodCourotine(float timeToUpgradeLevel)
    {
        currCountdownValue = timeToUpgradeLevel;
        while (currCountdownValue > 0)
        {

            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

        }
        GetWood();
        StartCoroutine(CollectWoodCourotine(timeToCollectWood));
    }
    private void OnMouseDown()
    {
        
        buildPanelManager.titleText.text = "Sawmill";
        buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
        buildPanelManager.button.onClick.RemoveAllListeners();
        buildPanelManager.button.onClick.AddListener(Build);
        buildPanelManager.levelText.text = "Level " + sawmillLevel;
        buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
        buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
        buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
        panel.SetActive(true);

    }
   
}
