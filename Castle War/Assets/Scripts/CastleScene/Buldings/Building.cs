using Assets.Scripts.CastleScene.Buldings;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Building : MonoBehaviour
{
    #region Fields
    [SerializeField] internal short level;
    [SerializeField] public bool isBuild;
    [SerializeField] internal TextMeshProUGUI buildingText;
    [SerializeField] internal Castle castle;
    [SerializeField] internal TakeScript take;
    [SerializeField] internal TimeProperties timePropertiesBuilding;
    ResourcesToUpgradeLvl resourcesToUpgradeBuildingLvl;
    internal Building actualBuilding;
    internal MainPanel mainPanel;
    internal bool isMainPanelOn = true;
    internal bool isSoldierPanelOn = false;
    internal bool isTowerPanelOn = false;
    #endregion
    #region Main Method
    private void Awake()
    {
        if (!Regex.Match(transform.name, @"CastleResources\d*").Success)
        {
            resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
            timePropertiesBuilding = GetComponent<TimeProperties>();
            mainPanel = GetComponent<MainPanel>();
        }
    }

    public void BuildBuilding(Transform transform)
    {
        if (RemoveMaterialIfisTrue(resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
            GetBuildingType(transform).isBuild = true;
    }
    public bool RemoveMaterialIfisTrue(int clayToUpgrade, int stoneToUpgrade, int woodToUpgrade)
    {
        if (castle.clay.quantity >= clayToUpgrade && castle.stone.quantity >= stoneToUpgrade && castle.wood.quantity >= woodToUpgrade)
        {
            castle.clay.quantity -= clayToUpgrade;
            castle.stone.quantity -= stoneToUpgrade;
            castle.wood.quantity -= woodToUpgrade;
            return true;
        }
        return false;
    }

    public void ElapsedTimeAndBuild(Building building)
    {
        if (!Regex.Match(transform.name, @"CastleResources\d*").Success)
        {
            building.buildingText.text = SetText(building.transform.name, building.level);
            if (building.isBuild)
            {
                building.timePropertiesBuilding.timeToUpgrade -= Time.deltaTime;
                if (mainPanel.panel != null)
                    building.mainPanel.timeText.text = building.timePropertiesBuilding.timeToUpgrade.ToString();
                if (building.timePropertiesBuilding.timeToUpgrade < 0)
                {
                    ++building.level;
                    building.timePropertiesBuilding.timeToUpgrade = building.timePropertiesBuilding.startTimeToUpgrade;
                    if (building.mainPanel.panel != null)
                    {
                        building.mainPanel.levelInPanel.text = SetText(building.transform.name, building.level);
                        building.mainPanel.timeText.text = building.timePropertiesBuilding.timeToUpgrade.ToString();
                    }
                    building.isBuild = false;
                }
            }
        }
    }
    public void BuildSoldierOrTower(Text textInTake, ref float timeToCollect, float firstTimeToCollect, Text timeText, ref int castleWhatBuild, string name, ref int staging, Text stagingText, ref bool isBuild)
    {
        timeToCollect -= Time.deltaTime;
        if (isSoldierPanelOn || isTowerPanelOn)
            timeText.text = timeToCollect.ToString();
        if (timeToCollect < 0)
        {
            castleWhatBuild += 1;
            timeToCollect = firstTimeToCollect;
            if (isSoldierPanelOn || isTowerPanelOn)
            {
                textInTake.text = castleWhatBuild.ToString();
                timeText.text = timeToCollect.ToString();
            }
            --staging;
            if (isSoldierPanelOn || isTowerPanelOn)
                stagingText.text = staging.ToString();
            if (staging <= 0)
                isBuild = false;
        }
    }
    public void DoWhenHaveMaterials(ref int staging, InputField label, Text stagingText, ref bool isBuild)
    {
        staging += int.Parse(label.text);
        stagingText.text = staging.ToString();
        isBuild = true; ;
        label.text = "1";
    }
    public Building GetBuildingType(Transform transform)
    {
        switch (transform.name)
        {
            case "Barrack":
                return FindObjectOfType<Barrack>();
            case "ClayMine":
                return FindObjectOfType<ClayMine>();
            case "Quarry":
                return FindObjectOfType<Quarry>();
            case "Sawmill":
                return FindObjectOfType<Sawmill>();
            case "Smithy":
                return FindObjectOfType<Smithy>();
            case "TowerWorkshop":
                return FindObjectOfType<TowerWorkShop>();
            case "Wall":
                return FindObjectOfType<Wall>();
            case "TownHall":
                return FindObjectOfType<TownHall>();
            default:
                return null;
        }
    }

    private void OnMouseDown()
    {
        if (Global.isSoldierPanelOnInCastleScene == false && Global.isTowerPanelOnInCastleScene == false)
            OnEnablePanel();
    }
    #endregion
    #region Additional Methods
    public static string SetText(string name, short level)
    {
        return $"{name} {level} Level";
    }

    public string SetLevelText(short level)
    {
        return $"{level} Level";
    }
    public void OnEnablePanel()
    {
        actualBuilding = GetBuildingType(transform);
        actualBuilding.mainPanel.InstantiatePanel();
        if (actualBuilding == FindObjectOfType<Barrack>())
            Global.isSoldierPanelOnInCastleScene = true;
        else
            mainPanel.buildSoldierButton.gameObject.SetActive(false);

        if (actualBuilding == FindObjectOfType<TowerWorkShop>())
            Global.isTowerPanelOnInCastleScene = true;
        else
            mainPanel.buildTowersButton.gameObject.SetActive(false);

        InitializeMainBuildingPanel();
    }


    public void ExitPanel()
    {
        mainPanel.buildButton.onClick.RemoveAllListeners();
        mainPanel.unlockPanel = false;
        actualBuilding = null;
        mainPanel.exitButton.onClick.RemoveAllListeners();
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        Destroy(mainPanel.panel);
    }
    private void InitializeMainBuildingPanel()
    {
        mainPanel.unlockPanel = true;
        mainPanel.levelInPanel.text = actualBuilding.buildingText.text;
        mainPanel.timeText.text = actualBuilding.timePropertiesBuilding.timeToUpgrade.ToString();
        mainPanel.buildButton.onClick.AddListener(() => BuildBuilding(transform));
        mainPanel.exitButton.onClick.AddListener(() => ExitPanel());
        isMainPanelOn = true;
    }

    #endregion
}

