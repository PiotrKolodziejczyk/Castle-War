using Assets.Scripts.CastleScene.Buldings;
using Assets.Scripts.CastleScene.Panels;
using Assets.Scripts.HelpingClass;
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
    internal bool isMainPanelOn = true;
    internal bool isSoldierPanelOn = false;
    internal bool isTowerPanelOn = false;
    [SerializeField] internal Texture2D normalCursor;
    [SerializeField] internal Texture2D buildCursor;
    public float youNeedTimeMain = 0;
    public bool isYouNeedMain = false;
    public MainPanel1 panelMain;
    [SerializeField] internal TimeProperties timePropertiesBuilding;
    #endregion
    #region Main Method

    public override void Initialize()
    {
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            panelMain = GetComponentInParent<MainPanel1>();
        }
        resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
        timePropertiesBuilding = GetComponent<TimeProperties>();
        if (SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void BuildBuilding()
    {
        if (TrainingManager.firstLevelOfTrainingCastleScene)
        {
            TrainingManager.secondTrainingLevelOnCastleScene = false;
            TrainingManager.exitTrening = true;
            TrainingManager.thirdTrainingLevelOnCastleScene = true;
        }

        if (RemoveMaterialIfisTrue(resourcesToUpgradeBuildingLvl.clayToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl,
                                   resourcesToUpgradeBuildingLvl.woodToUpgradeLvl))
            isBuild = true;
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

    public void ElapsedTimeAndBuild()
    {
        CheckButtonInteractable();
        if (isBuild)
        {
            timePropertiesBuilding.timeToUpgrade -= Time.deltaTime;
            if (timePropertiesBuilding.timeToUpgrade < 0)
            {
                level++;
                timePropertiesBuilding.timeToUpgrade = timePropertiesBuilding.startTimeToUpgrade;
                isBuild = false;
            }
        }
    }

    private void CheckButtonInteractable()
    {
        if (SceneManager.GetActiveScene().name == "CastleScene" && panelMain.levelInPanel.text.Contains(transform.name))
        {
            if (isBuild)
                panelMain.buildButton.interactable = false;
            else if (!panelMain.buildButton.interactable)
                panelMain.buildButton.interactable = true;
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

    private void OnMouseDown()
    {
        if (!Global.mainPanelActive && Global.isSoldierPanelOnInCastleScene == false && Global.isTowerPanelOnInCastleScene == false)
            OnEnablePanel1();
    }

    private void OnMouseEnter()
    {
        if (transform.parent.name == "Buldings" && SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(buildCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        if (transform.parent.name == "Buldings" && SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
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

    public void OnEnablePanel1()
    {
        Global.mainPanelActive = true;
        panelMain.panel.SetActive(true);

        if (this == FindObjectOfType<Barrack>())
        {
            panelMain.buildSoldierButton.gameObject.SetActive(true);
            Global.isSoldierPanelOnInCastleScene = true;
        }
        else
            panelMain.buildSoldierButton.gameObject.SetActive(false);

        if (this == FindObjectOfType<TowerWorkShop>())
        {
            panelMain.buildTowersButton.gameObject.SetActive(true);
            Global.isTowerPanelOnInCastleScene = true;
        }
        else
            panelMain.buildTowersButton.gameObject.SetActive(false);

        InitializeMainBuildingPanel();
    }

    public void ExitPanel()
    {
        panelMain.buildButton.onClick.RemoveAllListeners();
        panelMain.unlockPanel = false;
        panelMain.exitButton.onClick.RemoveAllListeners();
        timePropertiesBuilding.text = null;
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        Global.mainPanelActive = false;
        panelMain.panel.SetActive(false);
    }


    private void InitializeMainBuildingPanel()
    {
        panelMain.unlockPanel = true;
        panelMain.levelInPanel.text = buildingText.text;
        panelMain.buildingResourcesToUpgrade.stoneToUpgradeLvl = resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl;
        panelMain.buildingResourcesToUpgrade.woodToUpgradeLvl = resourcesToUpgradeBuildingLvl.woodToUpgradeLvl;
        panelMain.buildingResourcesToUpgrade.clayToUpgradeLvl = resourcesToUpgradeBuildingLvl.clayToUpgradeLvl;
        timePropertiesBuilding.text = panelMain.timeText;
        panelMain.buildButton.onClick.AddListener(() => BuildBuilding());
        panelMain.exitButton.onClick.AddListener(() => ExitPanel());
        isMainPanelOn = true;
    }


    #endregion
}

