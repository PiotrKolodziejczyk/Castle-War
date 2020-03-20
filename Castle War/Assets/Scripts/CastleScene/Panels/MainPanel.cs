using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return panel;
        }
       
    }
}
