using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Building : GameModule
{
    #region Fields
    [SerializeField] internal short level;
    [SerializeField] public bool isBuild;
    [SerializeField] internal TextMeshProUGUI buildingText;
    [SerializeField] internal Castle castle;
    [SerializeField] internal TakeScript take;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeBuildingLvl;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradePikeman;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeWarrior;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeKnight;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeWoodTower;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeStoneTower;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeGreatTower;
    internal bool isMainPanelOn = true;
    internal bool isSoldierPanelOn = false;
    internal bool isTowerPanelOn = false;
    [SerializeField] internal Texture2D normalCursor;
    [SerializeField] internal Texture2D buildCursor;
    public float youNeedTimeMain = 0;
    public bool isYouNeedMain = false;
    public MainPanel panelMain;
    [SerializeField] internal TimeProperties timePropertiesBuilding;
    [SerializeField] private Sprite image;
    [SerializeField] private TextMeshProUGUI textInMainPanel;
    #endregion
    #region Main Method

    public override void Initialize()
    {
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            panelMain = GetComponentInParent<MainPanel>();
        }
        resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
        timePropertiesBuilding = GetComponent<TimeProperties>();
        if (SceneManager.GetActiveScene().name == "CastleScene")
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
        }

    }

    public void BuildBuilding()
    {
        if (RemoveMaterialIfisTrue(resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
        {
            isBuild = true;
        }
        else
        {
            var youNeedMore = panelMain.youNeedMore.GetComponentInChildren<TextMeshProUGUI>();
            youNeedMore.transform.parent.gameObject.SetActive(true);
            youNeedMore.text = "You Need More Materials";
            isYouNeedMain = true;
            youNeedTimeMain = 1f;
        }
    }
    public bool RemoveMaterialIfisTrue(int clayToUpgrade, int stoneToUpgrade, int woodToUpgrade)
    {
        if (level < 20 && castle.clay.quantity >= clayToUpgrade && castle.stone.quantity >= stoneToUpgrade && castle.wood.quantity >= woodToUpgrade)
        {
            castle.clay.quantity -= clayToUpgrade;
            castle.stone.quantity -= stoneToUpgrade;
            castle.wood.quantity -= woodToUpgrade;
            return true;
        }
        return false;
    }

    public void ElapsedTimeAndBuild(ref ResourcesToUpgradeLvl res, ResourcesEnum enume, Building building)
    {
        CheckButtonInteractable();
        if (isBuild)
        {
            timePropertiesBuilding.timeToUpgrade -= Time.deltaTime;
            if (timePropertiesBuilding.timeToUpgrade < 0)
            {
                level++;
                timePropertiesBuilding.timeToUpgrade = timePropertiesBuilding.startTimeToUpgrade * level;
                MainResourcesClass.InitializeResources(ref res, enume.ToString(), building, castle.townHall);
                if (panelMain != null && panelMain.levelInPanel.text.Contains(transform.name))
                    panelMain.levelInPanel.text = SetText(transform.name, level);

                if (SceneManager.GetActiveScene().name == "CastleScene")
                {
                    buildingText.text = SetText(transform.name, level);
                    if (panelMain != null && panelMain.levelInPanel.text.Contains(transform.name))
                    {
                        panelMain.buildingResourcesToUpgrade.stoneToUpgradeLvl = resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl;
                        panelMain.buildingResourcesToUpgrade.woodToUpgradeLvl = resourcesToUpgradeBuildingLvl.woodToUpgradeLvl;
                        panelMain.buildingResourcesToUpgrade.clayToUpgradeLvl = resourcesToUpgradeBuildingLvl.clayToUpgradeLvl;
                    }
                    if (enume == ResourcesEnum.Barrack || enume == ResourcesEnum.TownHall)
                    {
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradePikeman, ResourcesEnum.Pikeman.ToString(), castle.barrack, castle.townHall);
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradeWarrior, ResourcesEnum.Warrior.ToString(), castle.barrack, castle.townHall);
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradeKnight, ResourcesEnum.Knight.ToString(), castle.barrack, castle.townHall);
                    }
                    if (enume == ResourcesEnum.TowerWorkShop || enume == ResourcesEnum.TownHall)
                    {
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradeWoodTower, ResourcesEnum.WoodTower.ToString(), castle.towerWorkShop, castle.townHall);
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradeStoneTower, ResourcesEnum.StoneTower.ToString(), castle.towerWorkShop, castle.townHall);
                        MainResourcesClass.InitializeResources(ref resourcesToUpgradeGreatTower, ResourcesEnum.GreatTower.ToString(), castle.towerWorkShop, castle.townHall);
                    }
                }


                isBuild = false;
                SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
            }
        }
    }

    private void CheckButtonInteractable()
    {
        if (SceneManager.GetActiveScene().name == "CastleScene" && panelMain.levelInPanel.text.Contains(transform.name))
        {
            if (isBuild)
            {
                panelMain.buildButton.interactable = false;
            }
            else if (!panelMain.buildButton.interactable)
            {
                panelMain.buildButton.interactable = true;
            }
        }
    }

    public void BuildSoldierOrTower(Text textInTake, ref float timeToCollect, float firstTimeToCollect, Text timeText, ref int castleWhatBuild, string name, ref int staging, Text stagingText, ref bool isBuild)
    {
        timeToCollect -= Time.deltaTime;
        if (isSoldierPanelOn || isTowerPanelOn)
        {
            timeText.text = timeToCollect.ToString();
        }

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
            stagingText.text = staging.ToString();
            if (staging <= 0)
            {
                isBuild = false;
            }
        }
    }
    public void DoWhenHaveMaterials(ref int staging, InputField label, Text stagingText, ref bool isBuild)
    {
        staging += int.Parse(label.text);
        stagingText.text = staging.ToString();
        isBuild = true; ;
        label.text = "1";
    }

    private void OnMouseDown()
    {
        Global.currentCastleObject = castle;
        if (!Global.mainPanelActive && Global.isSoldierPanelOnInCastleScene == false && Global.isTowerPanelOnInCastleScene == false)
        {
            OnEnablePanel();
        }
    }

    private void OnMouseEnter()
    {
        if (transform.parent.name == "Buldings" && SceneManager.GetActiveScene().name == "CastleScene")
        {
            Cursor.SetCursor(buildCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void OnMouseExit()
    {
        if (transform.parent.name == "Buldings" && SceneManager.GetActiveScene().name == "CastleScene")
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
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
        Global.mainPanelActive = true;
        panelMain.panel.SetActive(true);
        panelMain.mainImage.sprite = image;
        panelMain.textInMainPanel.text = textInMainPanel.text;
        if (this == FindObjectOfType<Barrack>())
        {
            panelMain.buildSoldierButton.gameObject.SetActive(true);
            Global.isSoldierPanelOnInCastleScene = true;
        }
        else
        {
            panelMain.buildSoldierButton.gameObject.SetActive(false);
        }

        if (this == FindObjectOfType<TowerWorkShop>())
        {
            panelMain.buildTowersButton.gameObject.SetActive(true);
            Global.isTowerPanelOnInCastleScene = true;
        }
        else
        {
            panelMain.buildTowersButton.gameObject.SetActive(false);
        }

        InitializeMainBuildingPanel();
    }

    public void ExitPanel()
    {
        panelMain.buildButton.onClick.RemoveAllListeners();
        panelMain.unlockPanel = false;
        panelMain.exitButton.onClick.RemoveAllListeners();
        timePropertiesBuilding.text = null;
        panelMain.levelInPanel.text = "";
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        Global.mainPanelActive = false;
        panelMain.panel.SetActive(false);
        SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
    }


    private void InitializeMainBuildingPanel()
    {
        panelMain.unlockPanel = true;
        panelMain.levelInPanel.text = buildingText.text;
        panelMain.buildingResourcesToUpgrade.stoneToUpgradeLvl = resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl;
        panelMain.buildingResourcesToUpgrade.woodToUpgradeLvl = resourcesToUpgradeBuildingLvl.woodToUpgradeLvl;
        panelMain.buildingResourcesToUpgrade.clayToUpgradeLvl = resourcesToUpgradeBuildingLvl.clayToUpgradeLvl;
        timePropertiesBuilding.text = panelMain.timeText;
        panelMain.levelInPanel.text = buildingText.text;
        panelMain.buildButton.onClick.AddListener(() => BuildBuilding());
        panelMain.exitButton.onClick.AddListener(() => ExitPanel());
        isMainPanelOn = true;
    }


    #endregion
}

