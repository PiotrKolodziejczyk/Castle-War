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
        [SerializeField] internal InputField pikemanLabel;
        [SerializeField] internal InputField warriorLabel;
        [SerializeField] internal InputField knightLabel;
        [SerializeField] internal Text pikemanStagingText;
        [SerializeField] internal Text warriorStagingText;
        [SerializeField] internal Text knightStagingText;
        internal int pikemanStaging;
        internal int warriorStaging;
        internal int knightStaging;
        public Transform training;
        public Transform youNeedMorePikeman;
        public Transform youNeedMoreWarrior;
        public Transform youNeedMoreKnight;
        public void Instantiate()
        {
            soldierPanelPrefab.SetActive(true);
        }

        public void ExitSoldierPanel()
        {
            Global.mainPanelActive = false;
            Global.isSoldierPanelOnInCastleScene = false;
            Global.isTowerPanelOnInCastleScene = false;
            soldierPanelPrefab.SetActive(false);
        }
    }
}
