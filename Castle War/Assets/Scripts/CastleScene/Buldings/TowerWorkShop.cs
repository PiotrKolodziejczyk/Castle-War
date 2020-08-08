using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using Assets.Scripts.HelpingClass;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerWorkShop : Building
{
    internal BuildTowerPanel towersPanel;
    internal bool isBuildWoodTower;
    internal bool isBuildStoneTower;
    internal bool isBuildGreatTower;
    [SerializeField] internal Smithy smithy;
    private float timeToCheck = 5;
    private float youNeedTime = 0;
    private bool isYouNeed = false;
    //private void Start()
    //{
    //    smithy = transform.parent.GetComponentInChildren<Smithy>();
    //    towersPanel = GetComponent<BuildTowerPanel>();
    //}
    public override void Initialize()
    {
        smithy = transform.parent.GetComponentInChildren<Smithy>();
        resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
        timePropertiesBuilding = GetComponent<TimeProperties>();
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            panelMain = GetComponentInParent<MainPanel1>();
            towersPanel = GetComponent<BuildTowerPanel>();
        }
        if (SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);

        MainResourcesClass.InitializeResources(ref resourcesToUpgradeBuildingLvl, ResourcesEnum.TowerWorkShop.ToString(), this, castle.townHall);
    }

    private void Update()
    {

        if (panelMain != null && SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
            panelMain.youNeedMore.gameObject.SetActive(false);
            isYouNeedMain = false;
        }
        if (isYouNeed && Global.Timer(ref youNeedTime))
        {
            towersPanel.youNeedMoreWoodTower.gameObject.SetActive(false);
            towersPanel.youNeedMoreStoneTower.gameObject.SetActive(false);
            towersPanel.youNeedMoreGreatTower.gameObject.SetActive(false);
            isYouNeed = false;
        }
        ElapsedTimeAndBuild();

        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            if (panelMain.panel != null && isMainPanelOn)
            {
                panelMain.buildTowersButton.onClick.RemoveAllListeners();
                panelMain.buildTowersButton.onClick.AddListener(() => EnableTowerPanel());
                isMainPanelOn = false;
            }
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
        if (TrainingManager.secondLevelOfTrainingCastleScene)
        {
            TrainingManager.tenTrainingLevelOnCastleScene = false;
            TrainingManager.buildTowers = true;
        }
        isTowerPanelOn = true;
        Global.isTowerPanelOnInCastleScene = true;
        towersPanel.Instantiate();
        towersPanel.buildWoodTower.onClick.AddListener(() =>
        {
            if (smithy.level >= 3 || TrainingManager.secondLevelOfTrainingCastleScene)
                if (RemoveMaterialIfisTrue(towersPanel.woodTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text),
                                       towersPanel.woodTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text),
                                       towersPanel.woodTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.woodTowerLabel.text)))
                {
                    DoWhenHaveMaterials(ref towersPanel.woodTowerStaging, towersPanel.woodTowerLabel, towersPanel.woodTowerStagingText, ref isBuildWoodTower);
                    if (TrainingManager.secondLevelOfTrainingCastleScene)
                    {
                        TrainingManager.buildTowers = false;
                        TrainingManager.elevenTrainingLevelOnCastleScene = true;
                    }
                }
                else
                {
                    var youNeedMore = towersPanel.youNeedMoreWoodTower.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = towersPanel.youNeedMoreWoodTower.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 3";
                isYouNeed = true;
                youNeedTime = 1f;
            }

        });
        towersPanel.buildStoneTower.onClick.AddListener(() =>
        {
            if (smithy.level >= 10)
                if (RemoveMaterialIfisTrue(towersPanel.stoneTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text),
                                       towersPanel.stoneTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text),
                                       towersPanel.stoneTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.stoneTowerLabel.text)))
                {
                    DoWhenHaveMaterials(ref towersPanel.stoneTowerStaging, towersPanel.stoneTowerLabel, towersPanel.stoneTowerStagingText, ref isBuildStoneTower);
                }
                else
                {
                    var youNeedMore = towersPanel.youNeedMoreStoneTower.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = towersPanel.youNeedMoreStoneTower.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 10";
                isYouNeed = true;
                youNeedTime = 1f;
            }
        });
        towersPanel.buildGreatTower.onClick.AddListener(() =>
        {
            if (smithy.level >= 20)
                if (RemoveMaterialIfisTrue(towersPanel.greatTowerResourcesToUpgrade.clayToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text),
                                       towersPanel.greatTowerResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text),
                                       towersPanel.greatTowerResourcesToUpgrade.woodToUpgradeLvl * int.Parse(towersPanel.greatTowerLabel.text)))
                {
                    DoWhenHaveMaterials(ref towersPanel.greatTowerStaging, towersPanel.greatTowerLabel, towersPanel.greatTowerStagingText, ref isBuildGreatTower);
                }
                else
                {
                    var youNeedMore = towersPanel.youNeedMoreGreatTower.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = towersPanel.youNeedMoreGreatTower.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 20";
                isYouNeed = true;
                youNeedTime = 1f;
            }
        });
        towersPanel.exitTowerBuildButton.onClick.AddListener(() => ExitTowerPanel());
    }
    public void ExitTowerPanel()
    {
        Global.mainPanelActive = false;
        panelMain.unlockPanel = false;
        panelMain.exitButton.onClick.RemoveAllListeners();
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        isTowerPanelOn = false;
        Destroy(towersPanel.towerPanel);
    }
}

