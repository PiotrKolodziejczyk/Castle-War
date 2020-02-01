using UnityEngine;

namespace Assets.Scripts.Buldings
{
    public class Barrack : Building
    {
        Barrack barrack;
        public void Start()
        {
            barrack = GetComponent<Barrack>();
        }
        private void Update()
        {
            Timer(barrack);
        }
    }
}
