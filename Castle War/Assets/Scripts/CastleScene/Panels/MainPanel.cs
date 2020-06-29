using Assets.Scripts.HelpingClass;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    internal class MainPanel : MonoBehaviour
    {
        [SerializeField] internal GameObject panelPrefab;
        [SerializeField] internal GameObject panel;
        [SerializeField] internal Button exitButton;
        [SerializeField] internal Button buildButton;
        [SerializeField] internal bool unlockPanel = false;
        [SerializeField] internal Text levelInPanel;
        [SerializeField] internal Text timeText;
        [SerializeField] internal Button buildSoldierButton;
        [SerializeField] internal Text buildSoldierButtonText;
        [SerializeField] internal Button buildTowersButton;
        [SerializeField] internal Text buildTowersButtonText;
        [SerializeField] internal ResourcesToUpgradeLvl buildingResourcesToUpgrade;
        private Transform trening;
        private Transform trening1;
        private Transform trening2;
        private Transform exitTrening;
        public Transform youNeedMore;
        public GameObject InstantiatePanel()
        {
            panel = Instantiate(panelPrefab, GameObject.FindGameObjectWithTag("UI").transform);
            buildButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildButton").First();
            exitButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "ExitButton").First();
            levelInPanel = panel.GetComponentsInChildren<Text>().Where(x => x.name == "Level").First();
            timeText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "TimeTextInMainPanel").First();
            buildSoldierButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildSoldiersButton").First();
            buildSoldierButtonText = buildSoldierButton.GetComponentInChildren<Text>();
            buildTowersButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildTowersButton").First();
            buildTowersButtonText = buildTowersButton.GetComponentInChildren<Text>();
            buildingResourcesToUpgrade = GetComponent<ResourcesToUpgradeLvl>();
            buildingResourcesToUpgrade.woodToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvl").First();
            buildingResourcesToUpgrade.stoneToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvl").First();
            buildingResourcesToUpgrade.clayToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvl").First();
            trening = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "Training").First();
            trening1 = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "Training1").First();
            trening2 = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "Training2").First();
            exitTrening = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "ExitTrening").First();
            youNeedMore = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "YouNeedMoreBuilding").First();
            youNeedMore.gameObject.SetActive(false);

            return panel;
        }
        private void Update()
        {
            if (panel != null)
                if (TrainingManager.firstLevelOfTrainingCastleScene)
                {
                    if (TrainingManager.secondTrainingLevelOnCastleScene)
                        trening.gameObject.SetActive(true);
                    else
                        trening.gameObject.SetActive(false);

                    if (TrainingManager.fourTrainingLevelOnCastleScene)
                        trening1.gameObject.SetActive(true);
                    else
                        trening1.gameObject.SetActive(false);

                    if (TrainingManager.exitTrening)
                        exitTrening.gameObject.SetActive(true);
                    else
                        exitTrening.gameObject.SetActive(false);
                }
                else
                {
                    trening.gameObject.SetActive(false);
                    trening1.gameObject.SetActive(false);
                    exitTrening.gameObject.SetActive(false);
                }
            if (panel != null)
                if (TrainingManager.secondLevelOfTrainingCastleScene)
                {
                    if (TrainingManager.tenTrainingLevelOnCastleScene)
                        trening2.gameObject.SetActive(true);
                    else
                        trening2.gameObject.SetActive(false);
                }
                else
                    trening2.gameObject.SetActive(false);
        }
    }
}
