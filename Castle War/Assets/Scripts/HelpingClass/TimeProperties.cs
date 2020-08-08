using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CastleScene.Buldings
{
    public class TimeProperties : MonoBehaviour
    {
        [SerializeField] internal float timeToUpgrade;
        [SerializeField] internal float startTimeToUpgrade;
        [SerializeField] internal Text text;

        private void Update()
        {
            if (text != null)
                text.text = timeToUpgrade.ToString();
        }
    }
}
