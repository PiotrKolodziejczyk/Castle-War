using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    #region Fields
    [SerializeField]
    internal short level;
    [SerializeField]
    Button exitButton;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    bool unlockPanel = false;
    [SerializeField]
    Text title;
    [SerializeField]
    Text levelInPanel;
    [SerializeField]
    Button buildButton;
    [SerializeField]
    bool isBuild;
    [SerializeField]
    float timeToUpgrade;
    [SerializeField]
    float startTimeToUpgrade;
    [SerializeField]
    Text time;
    [SerializeField]
    protected Barrack barrack;
    [SerializeField]
    protected ClayMine clayMine;
    [SerializeField]
    protected Quarry quarry;
    [SerializeField]
    protected Sawmill sawmill;
    [SerializeField]
    protected Smithy smithy;
    [SerializeField]
    protected TownHall townHall;
    [SerializeField]
    protected Wall wall;
    [SerializeField]
    protected TowerWorkShop towerWorkShop;
    [SerializeField]
    internal TextMeshProUGUI buildingText;
    [SerializeField]
    internal Building actualBuilding;
    [SerializeField]
    int clayToUpgradeLvl;
    [SerializeField]
    int stoneToUpgradeLvl;
    [SerializeField]
    int woodToUpgradeLvl;
    [SerializeField]
    internal PlayerCastle castle;
    public bool isPanelOn = false;
    #endregion

    #region Main Method
    public void Build(Transform transform)
    {
        title.text = transform.name;
        if (RemoveMaterialIfisTrue(clayToUpgradeLvl,stoneToUpgradeLvl,woodToUpgradeLvl))
            GetBuildingType(transform).isBuild = true;
    }
    public bool RemoveMaterialIfisTrue(int clayToUpgrade,int stoneToUpgrade,int woodToUpgrade)
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

    public void Timer(Building building)
    {
        if (building.isBuild)
        {
            building.timeToUpgrade -= Time.deltaTime;
            if (building.unlockPanel)
                time.text = building.timeToUpgrade.ToString();
            if (building.timeToUpgrade < 0)
            {
                building.level++;
                building.timeToUpgrade = building.startTimeToUpgrade;
                if (building.unlockPanel)
                {
                    time.text = building.timeToUpgrade.ToString();
                    levelInPanel.text = SetLevelText(building.level);
                    building.buildingText.text = SetText(building.name, building.level);
                }
                building.isBuild = false;
            }
        }
    }

    public Building GetBuildingType(Transform transform)
    {
        switch (transform.name)
        {
            case "Barrack":
                return barrack;
            case "ClayMine":
                return clayMine;
            case "Quarry":
                return quarry;
            case "Sawmill":
                return sawmill;
            case "Smithy":
                return smithy;
            case "TowerWorkshop":
                return towerWorkShop;
            case "Wall":
                return wall;
            case "TownHall":
                return townHall;
            default:
                return null;
        }
    }

    private void OnMouseDown()
    {
        if (Global.isPanelOnInCastleScene==false)
        {
            OnEnablePanel();
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
        Global.isPanelOnInCastleScene = true;
        actualBuilding = GetBuildingType(transform);
        actualBuilding.unlockPanel = true;
        buildButton.onClick.AddListener(() => Build(transform));
        exitButton.onClick.AddListener(() => ExitPanel());
        title.text = transform.name;
        levelInPanel.text = SetLevelText(actualBuilding.level);
        time.text = actualBuilding.timeToUpgrade.ToString();
        actualBuilding.buildingText.text = SetText(actualBuilding.name, actualBuilding.level);
        panel.SetActive(true);
    }
    public void ExitPanel()
    {
        buildButton.onClick.RemoveAllListeners();
        actualBuilding.unlockPanel = false;
        actualBuilding = null;
        exitButton.onClick.RemoveAllListeners();
        Global.isPanelOnInCastleScene = false;
        panel.SetActive(false);
    }

    #endregion
}


