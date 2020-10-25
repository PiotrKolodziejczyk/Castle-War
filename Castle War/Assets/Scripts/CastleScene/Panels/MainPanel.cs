using Assets.Scripts.CastleScene.Buldings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Panels
{
    public class MainPanel : MonoBehaviour
    {
        [SerializeField] internal GameObject panel;
        [SerializeField] internal Button exitButton;
        [SerializeField] internal Button buildButton;
        [SerializeField] internal bool unlockPanel = false;
        [SerializeField] internal TextMeshProUGUI levelInPanel;
        [SerializeField] internal Text timeText;
        [SerializeField] internal Button buildSoldierButton;
        [SerializeField] internal Text buildSoldierButtonText;
        [SerializeField] internal Button buildTowersButton;
        [SerializeField] internal Text buildTowersButtonText;
        [SerializeField] internal ResourcesToUpgradeLvl buildingResourcesToUpgrade;
        public Transform youNeedMore;
        [SerializeField] internal Image mainImage;
        [SerializeField] internal TextMeshProUGUI textInMainPanel;

        public void Awake()
        {
            InstantiatePanel();
        }

        public GameObject InstantiatePanel()
        {
            buildButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildButton").First();
            exitButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "ExitButton").First();
            levelInPanel = panel.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.name == "Level").First();
            textInMainPanel = panel.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.name == "TextInMainPanel").First();
            mainImage = panel.GetComponentsInChildren<Image>().Where(x => x.name == "ImageMain").First();
            buildSoldierButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildSoldiersButton").First();
            buildSoldierButtonText = buildSoldierButton.GetComponentInChildren<Text>();
            buildTowersButton = panel.GetComponentsInChildren<Button>().Where(x => x.name == "BuildTowersButton").First();
            buildTowersButtonText = buildTowersButton.GetComponentInChildren<Text>();
            buildingResourcesToUpgrade = panel.GetComponentInChildren<ResourcesToUpgradeLvl>();
            buildingResourcesToUpgrade.woodToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "WoodToBuildNextLvl").First();
            buildingResourcesToUpgrade.stoneToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "StoneToBuildNextLvl").First();
            buildingResourcesToUpgrade.clayToUpgradeLvlText = panel.GetComponentsInChildren<Text>().Where(x => x.name == "ClayToBuildNextLvl").First();
            timeText = panel.GetComponentsInChildren<Text>().Where(x => x.tag == "TimeTextInMainPanel").First();
            youNeedMore = panel.GetComponentsInChildren<Transform>().Where(x => x.name == "YouNeedMoreBuilding").First();
            youNeedMore.gameObject.SetActive(false);
            return panel;
        }
        public void InstantiateSoldierPanel(BuildSoldierPanel panel)
        {
            panel.Instantiate();
        }

        public void InstantiateTowerPanel(BuildTowerPanel panel)
        {
            panel.Instantiate();
        }
        
    }
}
