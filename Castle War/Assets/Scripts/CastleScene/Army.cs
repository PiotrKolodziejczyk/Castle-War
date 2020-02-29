using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CastleScene
{
    class Army : MonoBehaviour
    {
        [SerializeField]
        internal WoodTower woodTowerInCastle;
        [SerializeField]
        internal WoodTower woodTowerInPlayer;
        [SerializeField]
        internal StoneTower stoneTowerInCastle;
        [SerializeField]
        internal StoneTower stoneTowerInPlayer;
        [SerializeField]
        internal GreatTower greatTowerInCastle;
        [SerializeField]
        internal GreatTower greatTowerInPlayer;
        [SerializeField]
        internal Pikeman pikemanInCastle;
        [SerializeField]
        internal Pikeman pikemanInPlayer;
        [SerializeField]
        internal Warrior warriorInCastle;
        [SerializeField]
        internal Warrior warriorInPlayer;
        [SerializeField]
        internal Knight knightInCastle;
        [SerializeField]
        internal Knight knightInPlayer;
    }
}
