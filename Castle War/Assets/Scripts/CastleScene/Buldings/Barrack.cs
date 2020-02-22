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
    public int increaseQuantity;
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
    int warriorClayToUpgrade;
    int knightClayToUpgrade;
    [SerializeField]
    int pikemanStoneToUpgrade;
    [SerializeField]
    int pikemanWoodToUpgrade;
    private void Start()
    {
        pikemanLabel.text = "1";
        buildPikeman.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(pikemanClayToUpgrade* int.Parse(pikemanLabel.text), pikemanStoneToUpgrade* int.Parse(pikemanLabel.text), pikemanWoodToUpgrade * int.Parse(pikemanLabel.text)))
            {
                pikemanStaging += int.Parse(pikemanLabel.text);
                pikemanStagingText.text = pikemanStaging.ToString();
                isBuildPikeman = true; ;
                pikemanLabel.text = "1";
            }
        });
        buildWarrior.onClick.AddListener(() => { isBuildWarrior = true; ; });
        buildKnight.onClick.AddListener(() => { isBuildKnight = true; ; });
    }

    private void Update()
    {
        Timer(barrack);
        if (actualBuilding != barrack && buildSoldierButton.IsInteractable() == true)
        {
            buildSoldierButton.interactable = false;
            buildButtonText.enabled = false;
        }
        if (actualBuilding == barrack && buildSoldierButton.IsInteractable() == false)
        {
            buildSoldierButton.interactable = true;
            buildButtonText.enabled = true;
            buildSoldierButton.onClick.AddListener(() => EnableSoldierPanel());
        }
        if (isBuildPikeman)
            GetPikeman(pikemanText);
        if (isBuildWarrior)
            GetWarrior(warriorText);
        if (isBuildKnight)
            GetKnight(knightText);

    }
    public void EnableSoldierPanel()
    {
        ExitPanel();
        Global.isPanelOnInCastleScene = true;
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
    public void GetPikeman(TextMeshProUGUI text)
    {
        timeToCollectPikeman -= Time.deltaTime;
        timeTextPikeman.text = timeToCollectPikeman.ToString();
        if (timeToCollectPikeman < 0)
        {
            castle.pikeman += this.increaseQuantity;
            text.text = RawMaterial.SeText("Pikeman : ", castle.pikeman);
            timeToCollectPikeman = firstTimeToCollectPikeman;
            --pikemanStaging;
            timeTextPikeman.text = timeToCollectPikeman.ToString();
            pikemanStagingText.text = pikemanStaging.ToString();
            if (pikemanStaging <= 0)
                isBuildPikeman = false;
            
        }
    }
    public void GetWarrior(TextMeshProUGUI text)
    {
        timeToCollectWarrior -= Time.deltaTime;
        timeTextWarrior.text = timeToCollectWarrior.ToString();
        if (timeToCollectWarrior < 0)
        {
            timeTextWarrior.text = "0";
            castle.warrior += this.increaseQuantity;
            text.text = RawMaterial.SeText("Warrior : ", castle.warrior);
            timeToCollectWarrior = firstTimeToCollectWarrior;
            isBuildWarrior = false;
            buildWarrior.interactable = true;
        }
    }
    public void GetKnight(TextMeshProUGUI text)
    {
        timeToCollectKnight -= Time.deltaTime;
        timeTextKnight.text = timeToCollectKnight.ToString();
        if (timeToCollectKnight < 0)
        {
            timeTextKnight.text = "0";
            castle.knight += this.increaseQuantity;
            text.text = RawMaterial.SeText("Knight : ", castle.knight);
            timeToCollectKnight = firstTimeToCollectKnight;
            isBuildKnight = false;
            buildKnight.interactable = true;
        }
    }
}
