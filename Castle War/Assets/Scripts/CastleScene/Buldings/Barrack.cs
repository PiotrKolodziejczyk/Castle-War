using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.HelpingClass;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrack : Building
{
    internal BuildSoldierPanel soldierPanel;
    [SerializeField] internal bool isBuildPikeman;
    internal bool isBuildWarrior;
    internal bool isBuildKnight;
    private float timeToCheck = 5;
    [SerializeField] internal Smithy smithy;
    private float youNeedTime = 0;
    private bool isYouNeed = false;
    //private void Start()
    //{
    //    smithy = transform.parent.GetComponentInChildren<Smithy>();

    //    if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
    //    {
    //        soldierPanel = GetComponent<BuildSoldierPanel>();
    //    }
    //}
    public override void Initialize()
    {
        smithy = transform.parent.GetComponentInChildren<Smithy>();
        resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
        timePropertiesBuilding = GetComponent<TimeProperties>();
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            soldierPanel = GetComponent<BuildSoldierPanel>();
        }
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            mainPanel = GetComponent<MainPanel>();
        }
        townHall = transform.parent.GetComponentInChildren<TownHall>();

        if (SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);

    }

    private void Update()
    {
        if (mainPanel != null &&SceneManager.GetActiveScene().name == "CastleScene" && isYouNeedMain && Global.Timer(ref youNeedTimeMain))
        {
                mainPanel.youNeedMore.gameObject.SetActive(false);
                isYouNeedMain = false;
        }
        //if (timePropertiesBuilding.timeToUpgrade != timePropertiesBuilding.startTimeToUpgrade)
        //    isBuild = true;
        if (isYouNeed && Global.Timer(ref youNeedTime))
        {
            soldierPanel.youNeedMorePikeman.gameObject.SetActive(false);
            soldierPanel.youNeedMoreWarrior.gameObject.SetActive(false);
            soldierPanel.youNeedMoreKnight.gameObject.SetActive(false);
            isYouNeed = false;
        }
        ElapsedTimeAndBuild(this);
        SetResourcesToUpgrade(100, 120, 150, ref timeToCheck);
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            if (mainPanel.panel != null && isMainPanelOn)
            {
                mainPanel.buildSoldierButton.onClick.AddListener(() => EnableSoldierPanel());
                isMainPanelOn = false;
            }
            if (isBuildPikeman)
            {
                BuildSoldierOrTower(take.castle.Army.pikeman.textInputQuantity.text,
                                    ref soldierPanel.pikemanTimeProperties.timeToUpgrade,
                                    soldierPanel.pikemanTimeProperties.startTimeToUpgrade,
                                    soldierPanel.pikemanTimeProperties.text,
                                    ref castle.Army.pikeman.textInputQuantity.quantity,
                                    "Pikeman",
                                    ref soldierPanel.pikemanStaging,
                                    soldierPanel.pikemanStagingText,
                                    ref isBuildPikeman);
            }

            if (isBuildWarrior)
            {
                BuildSoldierOrTower(take.castle.Army.warrior.textInputQuantity.text,
                                    ref soldierPanel.warriorTimeProperties.timeToUpgrade,
                                    soldierPanel.warriorTimeProperties.startTimeToUpgrade,
                                    soldierPanel.warriorTimeProperties.text,
                                    ref castle.Army.warrior.textInputQuantity.quantity,
                                    "Warrior",
                                    ref soldierPanel.warriorStaging,
                                    soldierPanel.warriorStagingText,
                                    ref isBuildWarrior);
            }

            if (isBuildKnight)
            {
                BuildSoldierOrTower(take.castle.Army.knight.textInputQuantity.text,
                                    ref soldierPanel.knightTimeProperties.timeToUpgrade,
                                    soldierPanel.knightTimeProperties.startTimeToUpgrade,
                                    soldierPanel.knightTimeProperties.text,
                                    ref castle.Army.knight.textInputQuantity.quantity,
                                    "Knight",
                                    ref soldierPanel.knightStaging,
                                    soldierPanel.knightStagingText,
                                    ref isBuildKnight);
            }
        }
    }
    public void EnableSoldierPanel()
    {
        if (TrainingManager.firstLevelOfTrainingCastleScene)
        {
            TrainingManager.fourTrainingLevelOnCastleScene = false;
            TrainingManager.fiveTrainingLevelOnCastleScene = true;
        }
        ExitPanel();
        isSoldierPanelOn = true;
        Global.isSoldierPanelOnInCastleScene = true;
        soldierPanel.Instantiate();
        soldierPanel.buildPikeman.onClick.AddListener(() =>
        {
            if (smithy.level >= 2)
                if (RemoveMaterialIfisTrue(soldierPanel.pikemanResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text),
                                       soldierPanel.pikemanResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text),
                                       soldierPanel.pikemanResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text)))
                {
                    DoWhenHaveMaterials(ref soldierPanel.pikemanStaging, soldierPanel.pikemanLabel, soldierPanel.pikemanStagingText, ref isBuildPikeman);
                    if (TrainingManager.firstLevelOfTrainingCastleScene)
                    {
                        TrainingManager.sixTrainingLevelOnCastleScene = true;
                        TrainingManager.fiveTrainingLevelOnCastleScene = false;
                    }
                }
                else
                {
                    var youNeedMore = soldierPanel.youNeedMorePikeman.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = soldierPanel.youNeedMorePikeman.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 2";
                isYouNeed = true;
                youNeedTime = 1f;
            }
        });
        soldierPanel.buildWarrior.onClick.AddListener(() =>
        {
            if (smithy.level >= 8)
                if (RemoveMaterialIfisTrue(soldierPanel.warriorResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text),
                                           soldierPanel.warriorResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text),
                                           soldierPanel.warriorResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text)))
                {
                    DoWhenHaveMaterials(ref soldierPanel.warriorStaging, soldierPanel.warriorLabel, soldierPanel.warriorStagingText, ref isBuildWarrior);
                }
                else
                {
                    var youNeedMore = soldierPanel.youNeedMoreWarrior.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = soldierPanel.youNeedMoreWarrior.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 8";
                isYouNeed = true;
                youNeedTime = 1f;
            }
        });
        soldierPanel.buildKnight.onClick.AddListener(() =>
        {
            if (smithy.level >= 15)
                if (RemoveMaterialIfisTrue(soldierPanel.knightResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text),
                                       soldierPanel.knightResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text),
                                       soldierPanel.knightResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text)))
                {
                    DoWhenHaveMaterials(ref soldierPanel.knightStaging, soldierPanel.knightLabel, soldierPanel.knightStagingText, ref isBuildKnight);
                }
                else
                {
                    var youNeedMore = soldierPanel.youNeedMoreKnight.GetComponentInChildren<TextMeshProUGUI>();
                    youNeedMore.transform.parent.gameObject.SetActive(true);
                    youNeedMore.text = "You Need More Materials";
                    isYouNeed = true;
                    youNeedTime = 1f;
                }
            else
            {
                var youNeedMore = soldierPanel.youNeedMoreKnight.GetComponentInChildren<TextMeshProUGUI>();
                youNeedMore.transform.parent.gameObject.SetActive(true);
                youNeedMore.text = "You Need Smithy Level 15";
                isYouNeed = true;
                youNeedTime = 1f;
            }
        });
        soldierPanel.exitSoldierBuildButton.onClick.AddListener(() => ExitSoldierPanel());
    }
    public void ExitSoldierPanel()
    {
        // OnEnablePanel();
        Global.mainPanelActive = false;
        mainPanel.unlockPanel = false;
        mainPanel.exitButton.onClick.RemoveAllListeners();
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        isSoldierPanelOn = false;
        Destroy(soldierPanel.soldierPanel);
    }
}
