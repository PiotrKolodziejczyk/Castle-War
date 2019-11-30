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
    bool isBuild = false;
    public GameObject sawmillButton;
    private void Start()
    {
       
        StartCoroutine(CollectWoodCourotine(timeToCollectWood));
    }

    public void Build()
    {
        sawmillButton.SetActive(false);
        isSawmillBuilding = true;
        Build(buildCourotine, Material.Sawmill,sawmillLevel);
        woodSingleton.Quantity -= woodToUpgradeLvl;
        claySingleton.Quantity -= clayToUpgradeLvl;
        stoneSingleton.Quantity -= stoneToUpgradeLvl;
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
        if (!isSawmillBuilding && woodSingleton.Quantity >= woodToUpgradeLvl && claySingleton.Quantity >= clayToUpgradeLvl && stoneSingleton.Quantity >= stoneToUpgradeLvl)
            sawmillButton.SetActive(true);
        
        buildPanelManager.titleText.text = "Sawmill";
        buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
        buildPanelManager.levelText.text = "Level " + sawmillLevel;
        buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
        buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
        buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
        panel.SetActive(true);

    }
   
}
