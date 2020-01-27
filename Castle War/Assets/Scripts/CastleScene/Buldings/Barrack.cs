using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Buldings
{
    public class Barrack : Building
    {

        private void Start()
        {
           
        }
        //    float buildCourotine = 3;
        //    int woodToUpgradeLvl = 10;
        //    int stoneToUpgradeLvl = 10;
        //    int clayToUpgradeLvl = 10;
        //    public GameObject barrackButton;
        //    public void Build()
        //    {
        //        barrackButton.SetActive(false);
        //        isBarrackBuilding = true;
        //        Build(buildCourotine, Material.Barrack,barrackLevel);
        //        woodSingleton.Quantity -= woodToUpgradeLvl;
        //        claySingleton.Quantity -= clayToUpgradeLvl;
        //        stoneSingleton.Quantity -= stoneToUpgradeLvl;

        //    }
        //    private void OnMouseDown()
        //    {
        //        if (!isBarrackBuilding && woodSingleton.Quantity>= woodToUpgradeLvl && claySingleton.Quantity >= clayToUpgradeLvl && stoneSingleton.Quantity >= stoneToUpgradeLvl)
        //            barrackButton.SetActive(true);
        //        buildPanelManager.titleText.text = "Barrack";
        //        buildPanelManager.timeText.text = $"00:00:0{buildCourotine}";
        //        buildPanelManager.levelText.text = "Level " + barrackLevel;
        //        buildPanelManager.woodText.text = "Wood : " + woodToUpgradeLvl;
        //        buildPanelManager.stoneText.text = "Stone : " + stoneToUpgradeLvl;
        //        buildPanelManager.clayText.text = "Clay : " + clayToUpgradeLvl;
        //        StartPanel();
        //    }

    }
}
