using Assets.Scripts.CastleScene.Buldings;
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
    [SerializeField] internal TimeProperties timePropertiesBuilding;
    [SerializeField] internal ResourcesToUpgradeLvl resourcesToUpgradeBuildingLvl;
    internal Building actualBuilding;
    internal MainPanel mainPanel;
    internal bool isMainPanelOn = true;
    internal bool isSoldierPanelOn = false;
    internal bool isTowerPanelOn = false;
    [SerializeField] internal TownHall townHall;
    [SerializeField] internal Texture2D normalCursor;
    [SerializeField] internal Texture2D buildCursor;
    public float youNeedTimeMain = 0;
    public bool isYouNeedMain = false;
    #endregion
    #region Main Method
    //private void Awake()
    //{

    //    if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
    //    {
    //        mainPanel = GetComponent<MainPanel>();
    //    }
    //    resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
    //    timePropertiesBuilding = GetComponent<TimeProperties>();
    //    townHall = transform.parent.GetComponentInChildren<TownHall>();
    //}
    //private void Start()
    //{
    //    Global.SetAppropriateCursor(normalCursor);
    //}
 

    public override void Initialize()
    {
        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
        {
            mainPanel = GetComponent<MainPanel>();
        }
        resourcesToUpgradeBuildingLvl = GetComponent<ResourcesToUpgradeLvl>();
        timePropertiesBuilding = GetComponent<TimeProperties>();
        townHall = transform.parent.GetComponentInChildren<TownHall>();
        if (SceneManager.GetActiveScene().name == "CastleScene")
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);

    }
    public void BuildBuilding(Transform transform)
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
            GetBuildingType(transform).isBuild = true;
        else
        {
            var youNeedMore = mainPanel.youNeedMore.GetComponentInChildren<TextMeshProUGUI>();
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

    public void ElapsedTimeAndBuild(Building building)
    {

        if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
            building.buildingText.text = SetText(building.transform.name, building.level);
        if (building.isBuild)
        {
            if (mainPanel != null && mainPanel.buildButton != null)
                mainPanel.buildButton.interactable = false;
            building.timePropertiesBuilding.timeToUpgrade -= Time.deltaTime;
            if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
                if (mainPanel.panel != null)
                    building.mainPanel.timeText.text = building.timePropertiesBuilding.timeToUpgrade.ToString();
            if (building.timePropertiesBuilding.timeToUpgrade < 0)
            {
                ++building.level;
                building.timePropertiesBuilding.timeToUpgrade = building.timePropertiesBuilding.startTimeToUpgrade;

                if (!Regex.Match(transform.parent.name, @"CastleResources\d*").Success)
                    if (building.mainPanel.panel != null)
                    {
                        building.mainPanel.levelInPanel.text = SetText(building.transform.name, building.level);
                        building.mainPanel.timeText.text = building.timePropertiesBuilding.timeToUpgrade.ToString();
                    }
                building.isBuild = false;
                if (mainPanel != null && mainPanel.buildButton != null)
                    mainPanel.buildButton.interactable = true;
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
        if (!Global.mainPanelActive && Global.isSoldierPanelOnInCastleScene == false && Global.isTowerPanelOnInCastleScene == false)
        {
            OnEnablePanel();
        }
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
    public void OnEnablePanel()
    {
        Global.mainPanelActive = true;

        actualBuilding = GetBuildingType(transform);
        if (TrainingManager.firstLevelOfTrainingCastleScene && actualBuilding == FindObjectOfType<Smithy>())
        {
            TrainingManager.firstTrainingLevelOnCastleScene = false;
            TrainingManager.secondTrainingLevelOnCastleScene = true;
            if (TrainingManager.thirdTrainingLevelOnCastleScene)
            {
                TrainingManager.thirdTrainingLevelOnCastleScene = false;
                TrainingManager.fourTrainingLevelOnCastleScene = true;
            }
        }
        if (TrainingManager.firstLevelOfTrainingCastleScene && actualBuilding == FindObjectOfType<Barrack>())
        {
            if (TrainingManager.thirdTrainingLevelOnCastleScene)
            {
                TrainingManager.thirdTrainingLevelOnCastleScene = false;
                TrainingManager.fourTrainingLevelOnCastleScene = true;
            }
        }
        if (TrainingManager.secondLevelOfTrainingCastleScene && actualBuilding == FindObjectOfType<TowerWorkShop>())
        {
            TrainingManager.nineTrainingLevelOnCastleScene = false;
            TrainingManager.tenTrainingLevelOnCastleScene = true;
        }
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
        if (TrainingManager.train)
            TrainingManager.exitTrening = false;
        mainPanel.buildButton.onClick.RemoveAllListeners();
        mainPanel.unlockPanel = false;
        actualBuilding = null;
        mainPanel.exitButton.onClick.RemoveAllListeners();
        Global.isSoldierPanelOnInCastleScene = false;
        Global.isTowerPanelOnInCastleScene = false;
        Global.mainPanelActive = false;
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
    internal void SetResourcesToUpgrade(int multipleClay, int multipleWood, int multipleStone, ref float time)
    {
        if (Global.Timer(ref time))
        {
            resourcesToUpgradeBuildingLvl.clayToUpgradeLvl = (multipleClay * level) - (townHall.level * level);
            resourcesToUpgradeBuildingLvl.woodToUpgradeLvl = (multipleWood * level) - (townHall.level * level);
            resourcesToUpgradeBuildingLvl.stoneToUpgradeLvl = (multipleStone * level) - (townHall.level * level);
            time = 5;
        }
    }

    #endregion
}

