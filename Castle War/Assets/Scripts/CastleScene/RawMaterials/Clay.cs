using UnityEngine;

namespace Assets.Scripts
{
    public class Clay : RawMaterial
    {
        private void Start()
        {
            name = "Clay";
        }

        private void Update()
        {
            GetMaterial(name);           
        }
    }
}
