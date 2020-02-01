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
    #endregion

    #region Main Method
    public void Build(Transform transform)
    {
        title.text = transform.name;
        GetBuildingType(transform).isBuild = true;
    }

    public void Timer(Building building)
    {
        if (building.isBuild)
        {
            building.timeToUpgrade -= Time.deltaTime;
            time.text = building.timeToUpgrade.ToString();
            if (building.timeToUpgrade < 0)
            {
                building.level++;
                building.timeToUpgrade = building.startTimeToUpgrade;
                time.text = building.timeToUpgrade.ToString();
                building.isBuild = false;
                levelInPanel.text = SetLevelText(building.level);
                building.buildingText.text = SetText(building.name, building.level);
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
        Building building = GetBuildingType(transform);
        buildButton.onClick.AddListener(() => Build(transform));
        title.text = transform.name;
        levelInPanel.text = SetLevelText(building.level);
        time.text = building.timeToUpgrade.ToString();
        building.buildingText.text = SetText(building.name, building.level);
        panel.SetActive(true);
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
    public void ExitPanel()
    {
        panel.SetActive(false);
        buildButton.onClick.RemoveAllListeners();
    }
    #endregion
}


