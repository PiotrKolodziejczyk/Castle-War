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
            input.text = "0";
        }

        private void Update()
        {
            text.text = quantity.ToString();
            if (transform.parent.name != "Player")
                textInCanvas.text = text.text;
        }
    }
}
