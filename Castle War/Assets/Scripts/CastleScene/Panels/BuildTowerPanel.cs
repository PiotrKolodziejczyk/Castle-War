using Assets.Scripts.HelpingClass;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    public class BuildTowerPanel : MonoBehaviour
    {
        [SerializeField] internal GameObject towerPanelPrefab;
        [SerializeField] internal ResourcesToUpgradeLvl woodTowerResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl stoneTowerResourcesToUpgrade;
        [SerializeField] internal ResourcesToUpgradeLvl greatTowerResourcesToUpgrade;
        [SerializeField] internal TimeProperties woodTowerTimeProperties;
        [SerializeField] internal TimeProperties stoneTowerTimeProperties;
        [SerializeField] internal TimeProperties greatTowerTimeProperties;
        [SerializeField] internal InputField woodTowerLabel;
        [SerializeField] internal InputField stoneTowerLabel;
        [SerializeField] internal InputField greatTowerLabel;
        [SerializeField] internal Text woodTowerStagingText;
        [SerializeField] internal Text stoneTowerStagingText;
        [SerializeField] internal Text greatTowerStagingText;
        public Transform youNeedMoreWoodTower;
        internal int woodTowerStaging;
        internal int stoneTowerStaging;
        internal int greatTowerStaging;
        public Transform youNeedMoreStoneTower;
        public Transform youNeedMoreGreatTower;
        public Transform training;
        public void Instantiate()
        {
            towerPanelPrefab.SetActive(true);
        }

        public void ExitTowerPanel()
        {
            Global.mainPanelActive = false;
            Global.isSoldierPanelOnInCastleScene = false;
            Global.isTowerPanelOnInCastleScene = false;
            towerPanelPrefab.SetActive(false);
        }
    }

}
