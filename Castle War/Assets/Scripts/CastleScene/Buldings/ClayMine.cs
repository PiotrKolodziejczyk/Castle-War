using UnityEngine;

namespace Assets.Scripts.Buldings
{
    public class ClayMine : Building
    {
        ClayMine clayMine;
        public void Start()
        {
            clayMine = GetComponent<ClayMine>();
        }
        private void Update()
        {
            Timer(clayMine);
        }
    }
}
