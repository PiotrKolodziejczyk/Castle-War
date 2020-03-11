using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    class BuildTowerPanel : MonoBehaviour
    {
        [SerializeField] internal GameObject towerPanelPrefab;
        [SerializeField] internal ResourcesToUpgradeLvl woodTowerResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl stoneTowerResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl greatTowerResourcesToUpgrade;
        [SerializeField] internal TimeProperties woodTowerTimeProperties;
        [SerializeField] internal TimeProperties stoneTowerTimeProperties;
        [SerializeField] internal TimeProperties greatTowerTimeProperties;
        internal GameObject towerPanel;
        internal Button exitTowerBuildButton;
        internal Button buildWoodTower;
        internal Button buildStoneTower;
        internal Button buildGreatTower;
        internal InputField woodTowerLabel;
        internal InputField stoneTowerLabel;
        internal InputField greatTowerLabel;
        internal int woodTowerStaging;
        internal int stoneTowerStaging;
        internal int greatTowerStaging;
        internal Text woodTowerStagingText;
        internal Text stoneTowerStagingText;
        internal Text greatTowerStagingText;
        
        public void Instantiate()
        {
            towerPanel = Instantiate(towerPanelPrefab, GameObject.FindGameObjectWithTag("UI").transform);
            exitTowerBuildButton = towerPanel.GetComponentsInChildren<Button>().Where(x => x.name == "Exit").First();
            InitializeInputFields();
            InitializeStagingTexts();
            InitializeButtons();
            InitializeTimeTexts();
            InitializeUpgradeTexts();
            woodTowerLabel.text = "1";
            stoneTowerLabel.text = "1";
            greatTowerLabel.text = "1";
        }

        private void InitializeTimeTexts()
        {
            woodTowerTimeProperties.text = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeWoodTower").First();
            stoneTowerTimeProperties.text = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeStoneTower").First();
            greatTowerTimeProperties.text = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeGreatTower").First();
        }

        private void InitializeButtons()
        {
            buildWoodTower = towerPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildWoodTower").First();
            buildStoneTower = towerPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildStoneTower").First();
            buildGreatTower = towerPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildGreatTower").First();
        }

        private void InitializeStagingTexts()
        {
            woodTowerStagingText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingWoodTower").First();
            stoneTowerStagingText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingStoneTower").First();
            greatTowerStagingText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingGreatTower").First();
            woodTowerStagingText.text = woodTowerStaging.ToString();
            stoneTowerStagingText.text = stoneTowerStaging.ToString();
            greatTowerStagingText.text = greatTowerStaging.ToString();
        }

        private void InitializeInputFields()
        {
            woodTowerLabel = towerPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldWoodTower").First();
            stoneTowerLabel = towerPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldStoneTower").First();
            greatTowerLabel = towerPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldGreatTower").First();
        }

        private void InitializeUpgradeTexts()
        {
            woodTowerResourcesToUpgrade.woodToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlWoodTower").First();
            woodTowerResourcesToUpgrade.stoneToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlWoodTower").First();
            woodTowerResourcesToUpgrade.clayToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlWoodTower").First();
            stoneTowerResourcesToUpgrade.woodToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlStoneTower").First();
            stoneTowerResourcesToUpgrade.stoneToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlStoneTower").First();
            stoneTowerResourcesToUpgrade.clayToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlStoneTower").First();
            greatTowerResourcesToUpgrade.woodToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlGreatTower").First();
            greatTowerResourcesToUpgrade.stoneToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlGreatTower").First();
            greatTowerResourcesToUpgrade.clayToUpgradeLvlText = towerPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlGreatTower").First();
        }
    }

}
