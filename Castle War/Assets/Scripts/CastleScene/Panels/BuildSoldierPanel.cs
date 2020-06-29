using Assets.Scripts.HelpingClass;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    public class BuildSoldierPanel : MonoBehaviour
    {
        [SerializeField] internal GameObject soldierPanelPrefab;
        [SerializeField] internal ResourcesToUpgradeLvl pikemanResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl warriorResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl knightResourcesToUpgrade;
        [SerializeField] internal TimeProperties pikemanTimeProperties;
        [SerializeField] internal TimeProperties warriorTimeProperties;
        [SerializeField] internal TimeProperties knightTimeProperties;
        internal GameObject soldierPanel;
        internal Button exitSoldierBuildButton;
        internal Button buildPikeman;
        internal Button buildWarrior;
        internal Button buildKnight;
        internal InputField pikemanLabel;
        internal InputField warriorLabel;
        internal InputField knightLabel;
        internal int pikemanStaging;
        internal int warriorStaging;
        internal int knightStaging;
        internal Text pikemanStagingText;
        internal Text warriorStagingText;
        internal Text knightStagingText;
        public Transform training;
        public Transform youNeedMorePikeman;
        public Transform youNeedMoreWarrior;
        public Transform youNeedMoreKnight;
        public void Instantiate()
        {
            soldierPanel = Instantiate(soldierPanelPrefab, GameObject.FindGameObjectWithTag("UI").transform);
            exitSoldierBuildButton = soldierPanel.GetComponentsInChildren<Button>().Where(x => x.name == "Exit").First();
            InitializeInputFields();
            InitializeStagingTexts();
            InitializeButtons();
            InitializeTimeTexts();
            InitializeUpgradeTexts();
            pikemanLabel.text = "1";
            warriorLabel.text = "1";
            knightLabel.text = "1";
            training = soldierPanel.GetComponentsInChildren<Transform>().Where(x => x.name == "Training").First();
            youNeedMorePikeman = soldierPanel.GetComponentsInChildren<Transform>().Where(x => x.name == "YouNeedMorePikeman").First();
            youNeedMorePikeman.gameObject.SetActive(false);
            youNeedMoreWarrior = soldierPanel.GetComponentsInChildren<Transform>().Where(x => x.name == "YouNeedMoreWarrior").First();
            youNeedMoreWarrior.gameObject.SetActive(false);
            youNeedMoreKnight = soldierPanel.GetComponentsInChildren<Transform>().Where(x => x.name == "YouNeedMoreKnight").First();
            youNeedMoreKnight.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (TrainingManager.firstLevelOfTrainingCastleScene)
            {
                if (training != null && TrainingManager.fiveTrainingLevelOnCastleScene)
                    training.gameObject.SetActive(true);
                else if (training != null)
                    training.gameObject.SetActive(false);
            }
            else if (training != null)
                training.gameObject.SetActive(false);
        }
        private void InitializeTimeTexts()
        {
            pikemanTimeProperties.text = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimePikeman").First();
            warriorTimeProperties.text = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeWarrior").First();
            knightTimeProperties.text = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeKnight").First();
        }

        private void InitializeButtons()
        {
            buildPikeman = soldierPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildPikeman").First();
            buildWarrior = soldierPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildWarrior").First();
            buildKnight = soldierPanel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildKnight").First();
        }

        private void InitializeStagingTexts()
        {
            pikemanStagingText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingPikeman").First();
            warriorStagingText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingWarrior").First();
            knightStagingText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StagingKnight").First();
            pikemanStagingText.text = pikemanStaging.ToString();
            warriorStagingText.text = warriorStaging.ToString();
            knightStagingText.text = knightStaging.ToString();
        }

        private void InitializeInputFields()
        {
            pikemanLabel = soldierPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldPikeman").First();
            warriorLabel = soldierPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldWarrior").First();
            knightLabel = soldierPanel.GetComponentsInChildren<InputField>().Where(x => x.name == "InputFieldKnight").First();
        }

        private void InitializeUpgradeTexts()
        {
            pikemanResourcesToUpgrade.woodToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlPikeman").First();
            pikemanResourcesToUpgrade.stoneToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlPikeman").First();
            pikemanResourcesToUpgrade.clayToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlPikeman").First();
            warriorResourcesToUpgrade.woodToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlWarrior").First();
            warriorResourcesToUpgrade.stoneToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlWarrior").First();
            warriorResourcesToUpgrade.clayToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlWarrior").First();
            knightResourcesToUpgrade.woodToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvlKnight").First();
            knightResourcesToUpgrade.stoneToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvlKnight").First();
            knightResourcesToUpgrade.clayToUpgradeLvlText = soldierPanel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvlKnight").First();
        }
    }
}
