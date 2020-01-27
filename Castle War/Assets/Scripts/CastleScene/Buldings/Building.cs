﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour
{
    public short level;
    public TextMeshProUGUI text;
    protected GameObject panel;
    BuildingType type;

    private void Awake()
    {
        type = SetBuildingType(name);
        panel = RunAppropriatePanel(type);
    }
    private void Start()
    {
        panel.SetActive(false);
    }
    public static string SetText(string name, int lvl)
    {
        return $"{name} {lvl} Level";
    }
    public GameObject RunAppropriatePanel(BuildingType building)
    {
        switch (building)
        {
            case BuildingType.Barrack:
            case BuildingType.Smithy:
            case BuildingType.TowerWorkshop:
                return GameObject.FindGameObjectWithTag(building + "Panel");
            default:
                return GameObject.FindGameObjectWithTag("Panel");
        }
    }
    public BuildingType SetBuildingType(string name)
    {
        switch (name)
        {
            case "Barrack":
                return BuildingType.Barrack;
            case "TowerWorkshop":
                return BuildingType.TowerWorkshop;
            case "Smithy":
                return BuildingType.Smithy;
            default:
                return BuildingType.None;
        }
    }
    private void OnMouseDown()
    {
        
        foreach (Text text in panel.GetComponentsInChildren<Text>())
        {
            if (text.name == "Title")
            {
                text.text = name;
            }
        }
        panel.SetActive(true);
    }
    public void BuildPanelExit()
    {
        panel.SetActive(false);
    }
    //[SerializeField]
    //private Canvas canvas;
    //public TextMeshProUGUI[] textMeshProUGUIList;
    //protected Stone stoneSingleton;
    //protected Clay claySingleton;
    //protected Wood woodSingleton;
    //protected TextMeshProUGUI clayText;
    //protected TextMeshProUGUI stoneText;
    //protected TextMeshProUGUI woodText;
    //protected int timeToCollectStone = 2;
    //protected int timeToCollectClay = 2;
    //protected int timeToCollectWood = 2;
    //protected short sawmillLevel = 1;
    //protected short quarryLevel = 1;
    //protected short clayMineLevel = 1;
    //protected short townHallLevel = 1;
    //protected short wallLevel = 1;
    //protected short smithyLevel = 1;
    //protected short barrackLevel = 1;
    //protected short towerWorkshopLevel = 1;
    //public BuildingColliderGetList buildingColliderGetList;
    //protected TextMeshProUGUI textLvl;
    //[SerializeField]
    //protected GameObject panel;
    //[SerializeField]
    //protected BuildPanelManager buildPanelManager;
    //protected bool isWallBuilding = false;
    //protected bool isClayMineBuilding = false;
    //protected bool isBarrackBuilding = false;
    //protected bool isSmithyBuilding = false;
    //protected bool isSawmillBuilding = false;
    //protected bool isTowerWorkshopBuilding = false;
    //protected bool isTownHallBuilding = false;
    //protected bool isQuarryBuilding = false;
    //    private void Awake()
    //    {
    //        //woodSingleton = Wood.GetWood;
    //        //claySingleton = Clay.GetClay;
    //        //stoneSingleton = Stone.GetStone;
    //        textMeshProUGUIList = canvas.GetComponentsInChildren<TextMeshProUGUI>();
    //        woodText = textMeshProUGUIList.Where(x => x.name == "WoodText").First();
    //        stoneText = textMeshProUGUIList.Where(x => x.name == "StoneText").First();
    //        clayText = textMeshProUGUIList.Where(x => x.name == "ClayText").First();
    //    }

    //    protected void Build(float buildCourotine, Material material, int buildingLvl)
    //    {
    //        StartCoroutine(BuildTimerCourotine(buildCourotine, material, buildingLvl));
    //        ExitPanel();
    //    }

    //    public IEnumerator BuildTimerCourotine(float buildCourotine, Material material, int buldingLvl)
    //    {

    //        float tmp = buildCourotine;
    //        while (buildCourotine > 0)
    //        {

    //            textMeshProUGUIList.Where(x => x.name == material.ToString() + "Text").First().text = material.ToString() + " " + buldingLvl + " Level\n     " + buildCourotine + " seconds";
    //            yield return new WaitForSeconds(1.0f);
    //            buildCourotine--;

    //        }
    //        UpgradeLevel(material);
    //    }
    //    public void UpgradeLevel(Material material)
    //    {
    //        switch (material)
    //        {
    //            case Material.ClayMine:
    //                {
    //                    clayMineLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "ClayMineText").First().text = "Clay Mine " + clayMineLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + clayMineLevel;
    //                    isClayMineBuilding = false;
    //                    return;
    //                }
    //            case Material.Sawmill:
    //                {
    //                    sawmillLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "SawmillText").First().text = "Sawmill " + sawmillLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + sawmillLevel;
    //                    isSawmillBuilding = false;
    //                    return;
    //                }
    //            case Material.Quarry:
    //                {
    //                    quarryLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "QuarryText").First().text = "Quarry " + quarryLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + quarryLevel;
    //                    isQuarryBuilding = false;
    //                    return;
    //                }
    //            case Material.Barrack:
    //                {
    //                    barrackLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "BarrackText").First().text = "Barrack " + barrackLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + barrackLevel;
    //                    isBarrackBuilding = false;
    //                    return;
    //                }
    //            case Material.Smithy:
    //                {
    //                    smithyLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "SmithyText").First().text = "Smithy " + smithyLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + smithyLevel;
    //                    isSmithyBuilding = false;
    //                    return;
    //                }
    //            case Material.Wall:
    //                {
    //                    wallLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "WallText").First().text = "Wall " + wallLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + wallLevel;
    //                    isWallBuilding = false;
    //                    return;
    //                }
    //            case Material.TowerWorkshop:
    //                {
    //                    towerWorkshopLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "TowerWorkshopText").First().text = "Tower Workshop " + towerWorkshopLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + towerWorkshopLevel;
    //                    isTowerWorkshopBuilding = false;
    //                    return;
    //                }
    //            case Material.TownHall:
    //                {
    //                    townHallLevel++;
    //                    textMeshProUGUIList.Where(x => x.name == "TownHallText").First().text = "TownHall " + townHallLevel + " Level\n";
    //                    buildPanelManager.levelText.text = "Level " + townHallLevel;
    //                    isTownHallBuilding = false;

    //                    return;
    //                }
    //        }
    //    }
    //    public void ExitPanel()
    //    {
    //        panel.SetActive(false);
    //        for (int i = 0; i < buildPanelManager.canTexts.Count; i++)
    //        {
    //            buildPanelManager.canTexts[i].enabled = true;
    //        }
    //        for (int i = 0; i < buildingColliderGetList.listBulding.Count; i++)
    //        {
    //            buildingColliderGetList.listBulding[i].enabled = true;
    //        }
    //    }
    //    public void StartPanel()
    //    {

    //        panel.SetActive(true);
    //        for (int i = 0; i < buildPanelManager.canTexts.Count; i++)
    //        {
    //            buildPanelManager.canTexts[i].enabled = false;

    //        }
    //        for (int i = 0; i < buildingColliderGetList.listBulding.Count; i++)
    //        {
    //            buildingColliderGetList.listBulding[i].enabled = false;
    //        }
    //    }

    //}
    public enum BuildingType
    {
        None,
        Sawmill,
        Quarry,
        ClayMine,
        Smithy,
        TownHall,
        Wall,
        Barrack,
        TowerWorkshop
    }
}
