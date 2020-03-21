using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.BattleSceneScripts
{
    public class TextInputQuantity : MonoBehaviour
    {
        [SerializeField]
        internal Text text;
        [SerializeField]
        internal Text textInCanvas;
        [SerializeField]
        internal InputField input;
        [SerializeField]
        internal int quantity;
        private void Start()
        {
            if (input != null)
            {
                input.text = "0";
            }
        }

        private void Update()
        {
            if (!Regex.Match(transform.parent.name, @"CastleArmy").Success)
            {
                text.text = quantity.ToString();
                if (transform.parent.name != "Player")
                {
                    textInCanvas.text = text.text;
                }
            }
        }
    }
}
