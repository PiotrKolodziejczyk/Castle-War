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
            woodTower.Initialize();
            stoneTower = GetComponentInChildren<StoneTower>();
            stoneTower.Initialize();
            greatTower = GetComponentInChildren<GreatTower>();
            greatTower.Initialize();
        }
        public void InitializeArmyWhenFileNotExist(int p,int w,int k,int wt,int st,int gt)
        {
            pikeman.textInputQuantity.quantity = p;
            warrior.textInputQuantity.quantity = w;
            knight.textInputQuantity.quantity = k;
            woodTower.textInputQuantity.quantity = wt;
            stoneTower.textInputQuantity.quantity = st;
            greatTower.textInputQuantity.quantity = gt;
        }
    }
}
