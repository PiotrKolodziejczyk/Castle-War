using Assets.Scripts.CastleScene.Buldings;
using System.Text.RegularExpressions;

public class TowerWorkShop : Building
{
    internal BuildTowerPanel towersPanel;
    internal bool isBuildWoodTower;
    internal bool isBuildStoneTower;
    internal bool isBuildGreatTower;
    private void Start()
    {
        towersPanel = GetComponent<BuildTowerPanel>();
    }

    private void Update()
    {
        if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
            isBuild = true;
        if (!Regex.Match(transform.name, @"CastleResources\d*").Success)
        {
            if (mainPanel.panel != null && isMainPanelOn)
            {
                mainPanel.buildTowersButton.onClick.AddListener(() => EnableTowerPanel());
                isMainPanelOn = false;
            }
            ElapsedTimeAndBuild(this);
            if (isBuildWoodTower)
                BuildSoldierOrTower(take.castle.Army.woodTower.textInputQuantity.text, ref towersPanel.woodTowerTimeProperties.timeToUpgrade, towersPanel.woodTowerTimeProperties.startTimeToUpgrade, towersPanel.woodTowerTimeProperties.text, ref castle.Army.woodTower.textInputQuantity.quantity, "WoodTower", ref towersPanel.woodTowerStaging, towersPanel.woodTowerStagingText, ref isBuildWoodTower);
            if (isBuildStoneTower)
                BuildSoldierOrTower(take.castle.Army.stoneTower.textInputQuantity.text, ref towersPanel.stoneTowerTimeProperties.timeToUpgrade, towersPanel.stoneTowerTimeProperties.startTimeToUpgrade, towersPanel.stoneTowerTimeProperties.text, ref castle.Army.stoneTower.textInputQuantity.quantity, "StoneTower", ref towersPanel.stoneTowerStaging, towersPanel.stoneTowerStagingText, ref isBuildStoneTower);
            if (isBuildGreatTower)
                BuildSoldierOrTower(take.castle.Army.greatTower.textInputQuantity.text, ref towersPanel.greatTowerTimeProperties.timeToUpgrade, towersPanel.greatTowerTimeProperties.startTimeToUpgrade, towersPanel.greatTowerTimeProperties.text, ref castle.Army.greatTower.textInputQuantity.quantity, "GreatTower", ref towersPanel.greatTowerStaging, towersPanel.greatTowerStagingText, ref isBuildGreatTower);
        }
    }
    public void EnableTowerPanel()
    {
        ExitPanel();
        isTowerPanelOn = true;
        Global.isTowerPanelOnInCastleScene = true;
        towersPanel.Instantiate();
        towersPanel.buildWoodTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(towersPanel.woodTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text),
                                       towersPanel.woodTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text),
                                       towersPanel.woodTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref towersPanel.woodTowerStaging, towersPanel.woodTowerLabel, towersPanel.woodTowerStagingText, ref isBuildWoodTower);
            }
        });
        towersPanel.buildStoneTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(towersPanel.stoneTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text),
                                       towersPanel.stoneTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text),
                                       towersPanel.stoneTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref towersPanel.stoneTowerStaging, towersPanel.stoneTowerLabel, towersPanel.stoneTowerStagingText, ref isBuildStoneTower);
            }
        });
        towersPanel.buildGreatTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(towersPanel.greatTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text),
                                       towersPanel.greatTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text),
                                       towersPanel.greatTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref towersPanel.greatTowerStaging, towersPanel.greatTowerLabel, towersPanel.greatTowerStagingText, ref isBuildGreatTower);
            }
        });
        towersPanel.exitTowerBuildButton.onClick.AddListener(() => ExitTowerPanel());
    }
    public void ExitTowerPanel()
    {
        OnEnablePanel();
        isTowerPanelOn = false;
        Destroy(towersPanel.towerPanel);
    }
}

