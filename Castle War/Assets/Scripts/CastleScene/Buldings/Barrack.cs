using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barrack : Building
{
    [SerializeField]
    UnityEngine.UI.Button exitSoldierBuildButton;
    [SerializeField]
    GameObject SoldierPanel;
    [SerializeField]
    UnityEngine.UI.Button buildSoldierButton;
    [SerializeField]
    Text buildButtonText;
    public TextMeshProUGUI pikemanText;
    public TextMeshProUGUI warriorText;
    public TextMeshProUGUI knightText;
    public float timeToCollectPikeman;
    public float timeToCollectWarrior;
    public float timeToCollectKnight;
    public float firstTimeToCollectPikeman;
    public float firstTimeToCollectWarrior;
    public float firstTimeToCollectKnight;
    public UnityEngine.UI.Button buildPikeman;
    public UnityEngine.UI.Button buildWarrior;
    public UnityEngine.UI.Button buildKnight;
    public Text timeTextPikeman;
    public Text timeTextWarrior;
    public Text timeTextKnight;
    bool isBuildPikeman;
    bool isBuildWarrior;
    bool isBuildKnight;
    [SerializeField]
    InputField pikemanLabel;
    [SerializeField]
    InputField warriorLabel;
    [SerializeField]
    InputField knightLabel;
    [SerializeField]
    Text pikemanStagingText;
    [SerializeField]
    Text warriorStagingText;
    [SerializeField]
    Text knightStagingText;
    [SerializeField]
    int pikemanStaging;
    int warriorStaging;
    int knightStaging;
    [SerializeField]
    int pikemanClayToUpgrade;
    [SerializeField]
    int warriorClayToUpgrade;
    [SerializeField]
    int warriorStoneToUpgrade;
    [SerializeField]
    int warriorWoodToUpgrade;
    [SerializeField]
    int knightClayToUpgrade;
    [SerializeField]
    int knightStoneToUpgrade;
    [SerializeField]
    int knightWoodToUpgrade;
    [SerializeField]
    int pikemanStoneToUpgrade;
    [SerializeField]
    int pikemanWoodToUpgrade;
    [SerializeField]
    GameObject buildTowersButton;
    private void Start()
    {
        pikemanLabel.text = "1";
        warriorLabel.text = "1";
        knightLabel.text = "1";
        buildPikeman.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(pikemanClayToUpgrade* int.Parse(pikemanLabel.text), pikemanStoneToUpgrade* int.Parse(pikemanLabel.text), pikemanWoodToUpgrade * int.Parse(pikemanLabel.text)))
            {
                DoWhenHaveMaterials(ref pikemanStaging, pikemanLabel, pikemanStagingText,ref isBuildPikeman);
            }
        });
        buildWarrior.onClick.AddListener(() => {
            if (RemoveMaterialIfisTrue(warriorClayToUpgrade * int.Parse(warriorLabel.text), warriorStoneToUpgrade * int.Parse(warriorLabel.text), warriorWoodToUpgrade * int.Parse(warriorLabel.text)))
            {
                DoWhenHaveMaterials(ref warriorStaging, warriorLabel, warriorStagingText,ref isBuildWarrior);
            }
        });
        buildKnight.onClick.AddListener(() => {
            if (RemoveMaterialIfisTrue(knightClayToUpgrade * int.Parse(knightLabel.text), knightStoneToUpgrade * int.Parse(knightLabel.text), knightWoodToUpgrade * int.Parse(knightLabel.text)))
            {
                DoWhenHaveMaterials(ref knightStaging, knightLabel, knightStagingText,ref isBuildKnight);
            }
        });
    }
   
    private void Update()
    {
        Timer(barrack);
        if (actualBuilding != barrack && buildSoldierButton.IsInteractable() == true)
        {
            buildSoldierButton.interactable = false;
            buildButtonText.enabled = false;
            buildTowersButton.SetActive(true);
        }
        if (actualBuilding == barrack && buildSoldierButton.IsInteractable() == false)
        {
            Debug.Log("Wchodzi00");
            buildSoldierButton.interactable = true;
            buildButtonText.enabled = true;
            buildTowersButton.SetActive(false);
            buildSoldierButton.onClick.AddListener(() => EnableSoldierPanel());
        }
        if (isBuildPikeman)
            BuildSoldierOrTower(pikemanText,ref timeToCollectPikeman, firstTimeToCollectPikeman, timeTextPikeman, castle.pikeman, "Pikeman",ref pikemanStaging, pikemanStagingText,ref isBuildPikeman);
        if (isBuildWarrior)
            BuildSoldierOrTower(warriorText, ref timeToCollectWarrior, firstTimeToCollectWarrior, timeTextWarrior, castle.warrior, "Warrior", ref warriorStaging, warriorStagingText, ref isBuildWarrior);
        if (isBuildKnight)
            BuildSoldierOrTower(knightText, ref timeToCollectKnight, firstTimeToCollectKnight, timeTextKnight, castle.knight, "Knight", ref knightStaging, knightStagingText, ref isBuildKnight);

    }
    public void EnableSoldierPanel()
    {
        ExitPanel();
        Global.isSoldierPanelOnInCastleScene = true;
        exitSoldierBuildButton.onClick.AddListener(() => ExitSoldierPanel());
        SoldierPanel.SetActive(true);
    }
    public void ExitSoldierPanel()
    {
        OnEnablePanel();
        buildSoldierButton.onClick.RemoveAllListeners();
        exitSoldierBuildButton.onClick.RemoveAllListeners();
        SoldierPanel.SetActive(false);
    }
    
}
