using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    public class ResourcesToUpgradeLvl : MonoBehaviour
    {
        [SerializeField] internal int clayToUpgradeLvl;
        [SerializeField] internal int stoneToUpgradeLvl;
        [SerializeField] internal int woodToUpgradeLvl;
        [SerializeField] internal Text woodToUpgradeLvlText;
        [SerializeField] internal Text stoneToUpgradeLvlText;
        [SerializeField] internal Text clayToUpgradeLvlText;
        private void Update()
        {
            if (transform.parent.name == "Army" && woodToUpgradeLvlText != null)
            {
                woodToUpgradeLvlText.text = woodToUpgradeLvl.ToString();
                stoneToUpgradeLvlText.text = stoneToUpgradeLvl.ToString();
                clayToUpgradeLvlText.text = clayToUpgradeLvl.ToString();
            }
        }
    }
}
