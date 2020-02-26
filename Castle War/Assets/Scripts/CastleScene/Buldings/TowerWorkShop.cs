using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerWorkShop : Building
{
    [SerializeField]
    UnityEngine.UI.Button exitTowerBuildButton;
    [SerializeField]
    GameObject TowerPanel;
    [SerializeField]
    UnityEngine.UI.Button buildTowerButton;
    [SerializeField]
    Text buildTowerButtonText;
    public TextMeshProUGUI woodTowerText;
    public TextMeshProUGUI stoneTowerText;
    public TextMeshProUGUI greatTowerText;
    public float timeToCollectWoodTower;
    public float timeToCollectStoneTower;
    public float timeToCollectGreatTower;
    public float firstTimeToCollectWoodTower;
    public float firstTimeToCollectStoneTower;
    public float firstTimeToCollectGreatTower;
    public UnityEngine.UI.Button buildWoodTower;
    public UnityEngine.UI.Button buildStoneTower;
    public UnityEngine.UI.Button buildGreatTower;
    public Text timeTextWoodTower;
    public Text timeTextStoneTower;
    public Text timeTextGreatTower;
    bool isBuildWoodTower;
    bool isBuildStoneTower;
    bool isBuildGreatTower;
    [SerializeField]
    InputField woodTowerLabel;
    [SerializeField]
    InputField stoneTowerLabel;
    [SerializeField]
    InputField greatTowerLabel;
    [SerializeField]
    Text woodTowerStagingText;
    [SerializeField]
    Text stoneTowerStagingText;
    [SerializeField]
    Text greatTowerStagingText;
    [SerializeField]
    int woodTowerStaging;
    int stoneTowerStaging;
    int greatTowerStaging;
    [SerializeField]
    int woodTowerClayToUpgrade;
    [SerializeField]
    int woodTowerStoneToUpgrade;
    [SerializeField]
    int woodTowerWoodToUpgrade;
    [SerializeField]
    int stoneTowerClayToUpgrade;
    [SerializeField]
    int stoneTowerStoneToUpgrade;
    [SerializeField]
    int stoneTowerWoodToUpgrade;
    [SerializeField]
    int greatTowerClayToUpgrade;
    [SerializeField]
    int greatTowerStoneToUpgrade;
    [SerializeField]
    int greatTowerWoodToUpgrade;

    private void Start()
    {
        woodTowerLabel.text = "1";
        stoneTowerLabel.text = "1";
        greatTowerLabel.text = "1";
        buildWoodTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(woodTowerClayToUpgrade * int.Parse(woodTowerLabel.text), woodTowerStoneToUpgrade * int.Parse(woodTowerLabel.text), woodTowerWoodToUpgrade * int.Parse(woodTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref woodTowerStaging, woodTowerLabel, woodTowerStagingText, ref isBuildWoodTower);
            }
        });
        buildStoneTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(stoneTowerClayToUpgrade * int.Parse(stoneTowerLabel.text), stoneTowerStoneToUpgrade * int.Parse(stoneTowerLabel.text), stoneTowerWoodToUpgrade * int.Parse(stoneTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref stoneTowerStaging, stoneTowerLabel, stoneTowerStagingText, ref isBuildStoneTower);
            }
        });
        buildGreatTower.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(greatTowerClayToUpgrade * int.Parse(greatTowerLabel.text), greatTowerStoneToUpgrade * int.Parse(greatTowerLabel.text), greatTowerWoodToUpgrade * int.Parse(greatTowerLabel.text)))
            {
                DoWhenHaveMaterials(ref greatTowerStaging, greatTowerLabel, greatTowerStagingText, ref isBuildGreatTower);
            }
        });
    }
    private void Update()
    {
        Timer(towerWorkShop);
        if (actualBuilding != towerWorkShop && buildTowerButton.IsInteractable() == true)
        {
            buildTowerButton.interactable = false;
            buildTowerButtonText.enabled = false;
        }
        if (actualBuilding == towerWorkShop && buildTowerButton.IsInteractable() == false)
        {
            buildTowerButton.interactable = true;
            buildTowerButtonText.enabled = true;
            buildTowerButton.onClick.AddListener(() => EnableTowerPanel());
        }
        if (isBuildWoodTower)
            BuildSoldierOrTower(woodTowerText, take.woodTowersInCastle, ref timeToCollectWoodTower, firstTimeToCollectWoodTower, timeTextWoodTower, ref castle.woodTower, "Wood Tower", ref woodTowerStaging, woodTowerStagingText, ref isBuildWoodTower);
        if (isBuildStoneTower)
            BuildSoldierOrTower(stoneTowerText, take.stoneTowersInCastle, ref timeToCollectStoneTower, firstTimeToCollectStoneTower, timeTextStoneTower, ref castle.stoneTower, "Stone Tower", ref stoneTowerStaging, stoneTowerStagingText, ref isBuildStoneTower);
        if (isBuildGreatTower)
            BuildSoldierOrTower(greatTowerText, take.greatTowersInCastle, ref timeToCollectGreatTower, firstTimeToCollectGreatTower, timeTextGreatTower, ref castle.greatTower, "Great Tower", ref greatTowerStaging, greatTowerStagingText, ref isBuildGreatTower);

    }
    public void EnableTowerPanel()
    {
        ExitPanel();
        Global.isTowerPanelOnInCastleScene = true;
        exitTowerBuildButton.onClick.AddListener(() => ExitTowerPanel());
        TowerPanel.SetActive(true);
    }
    public void ExitTowerPanel()
    {
        OnEnablePanel();
        buildTowerButton.onClick.RemoveAllListeners();
        exitTowerBuildButton.onClick.RemoveAllListeners();
        TowerPanel.SetActive(false);
    }
}

