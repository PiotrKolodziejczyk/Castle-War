using UnityEngine;

namespace Assets.Scripts.CastleScene
{
    public class Army : GameModule
    {
        [SerializeField] internal WoodTower woodTower;
        [SerializeField] internal StoneTower stoneTower;
        [SerializeField] internal GreatTower greatTower;
        [SerializeField] internal Pikeman pikeman;
        [SerializeField] internal Warrior warrior;
        [SerializeField] internal Knight knight;
        //private void Awake()
        //{
        //    InitializeArmy();
        //}
        public override void Initialize()
        {
            InitializeArmy();
        }
        public void InitializeArmy()
        {
            pikeman = GetComponentInChildren<Pikeman>();
            pikeman.Initialize();
            warrior = GetComponentInChildren<Warrior>();
            warrior.Initialize();
            knight = GetComponentInChildren<Knight>();
            knight.Initialize();
            woodTower = GetComponentInChildren<WoodTower>();
            stoneTower = GetComponentInChildren<StoneTower>();
            greatTower = GetComponentInChildren<GreatTower>();
        }
    }
}
