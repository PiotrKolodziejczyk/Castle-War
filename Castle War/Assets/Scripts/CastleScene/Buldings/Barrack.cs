using Assets.Scripts.CastleScene.Buldings;


public class Barrack : Building
{
    internal BuildSoldierPanel soldierPanel;
    internal bool isBuildPikeman;
    internal bool isBuildWarrior;
    internal bool isBuildKnight;
    private void Start()
    {
        soldierPanel = GetComponent<BuildSoldierPanel>();
    }

    private void Update()
    {
        if (mainPanel.panel != null && isMainPanelOn)
        {
            mainPanel.buildSoldierButton.onClick.AddListener(() => EnableSoldierPanel());
            isMainPanelOn = false;
        }
        ElapsedTimeAndBuild(this);
        if (isBuildPikeman)
            BuildSoldierOrTower(take.castle.Army.pikeman.textInputQuantity.text, ref soldierPanel.pikemanTimeProperties.timeToUpgrade, soldierPanel.pikemanTimeProperties.startTimeToUpgrade, soldierPanel.pikemanTimeProperties.text, ref castle.Army.pikeman.textInputQuantity.quantity, "Pikeman", ref soldierPanel.pikemanStaging, soldierPanel.pikemanStagingText, ref isBuildPikeman);
        if (isBuildWarrior)
            BuildSoldierOrTower(take.castle.Army.warrior.textInputQuantity.text, ref soldierPanel.warriorTimeProperties.timeToUpgrade, soldierPanel.warriorTimeProperties.startTimeToUpgrade, soldierPanel.warriorTimeProperties.text, ref castle.Army.warrior.textInputQuantity.quantity, "Warrior", ref soldierPanel.warriorStaging, soldierPanel.warriorStagingText, ref isBuildWarrior);
        if (isBuildKnight)
            BuildSoldierOrTower(take.castle.Army.knight.textInputQuantity.text, ref soldierPanel.knightTimeProperties.timeToUpgrade, soldierPanel.knightTimeProperties.startTimeToUpgrade, soldierPanel.knightTimeProperties.text, ref castle.Army.knight.textInputQuantity.quantity, "Knight", ref soldierPanel.knightStaging, soldierPanel.knightStagingText, ref isBuildKnight);
    }
    public void EnableSoldierPanel()
    {
        ExitPanel();
        isSoldierPanelOn = true;
        Global.isSoldierPanelOnInCastleScene = true;
        soldierPanel.Instantiate();
        soldierPanel.buildPikeman.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(soldierPanel.pikemanResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text),
                                       soldierPanel.pikemanResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text),
                                       soldierPanel.pikemanResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.pikemanLabel.text)))
            {
                DoWhenHaveMaterials(ref soldierPanel.pikemanStaging, soldierPanel.pikemanLabel, soldierPanel.pikemanStagingText, ref isBuildPikeman);
            }
        });
        soldierPanel.buildWarrior.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(soldierPanel.warriorResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text),
                                       soldierPanel.warriorResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text),
                                       soldierPanel.warriorResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.warriorLabel.text)))
            {
                DoWhenHaveMaterials(ref soldierPanel.warriorStaging, soldierPanel.warriorLabel, soldierPanel.warriorStagingText, ref isBuildWarrior);
            }
        });
        soldierPanel.buildKnight.onClick.AddListener(() =>
        {
            if (RemoveMaterialIfisTrue(soldierPanel.knightResourcesToUpgrade.clayToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text),
                                       soldierPanel.knightResourcesToUpgrade.stoneToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text),
                                       soldierPanel.knightResourcesToUpgrade.woodToUpgradeLvl * int.Parse(soldierPanel.knightLabel.text)))
            {
                DoWhenHaveMaterials(ref soldierPanel.knightStaging, soldierPanel.knightLabel, soldierPanel.knightStagingText, ref isBuildKnight);
            }
        });
        soldierPanel.exitSoldierBuildButton.onClick.AddListener(() => ExitSoldierPanel());
    }
    public void ExitSoldierPanel()
    {
        OnEnablePanel();
        isSoldierPanelOn = false;
        Destroy(soldierPanel.soldierPanel);
    }
}
