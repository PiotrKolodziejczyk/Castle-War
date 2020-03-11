using UnityEngine;

namespace Assets.Scripts.CastleScene
{
    public class Army : MonoBehaviour
    {
        [SerializeField]
        internal WoodTower woodTower;
        [SerializeField]
        internal StoneTower stoneTower;
        [SerializeField]
        internal GreatTower greatTower;
        [SerializeField]
        internal Pikeman pikeman;
        [SerializeField]
        internal Warrior warrior;
        [SerializeField]
        internal Knight knight;
        private void Awake()
        {
            InitializeArmy();
        }
        public void InitializeArmy()
        {
            pikeman = GetComponentInChildren<Pikeman>();
            warrior = GetComponentInChildren<Warrior>();
            knight = GetComponentInChildren<Knight>();
            woodTower = GetComponentInChildren<WoodTower>();
            stoneTower = GetComponentInChildren<StoneTower>();
            greatTower = GetComponentInChildren<GreatTower>();
        }
    }
}
