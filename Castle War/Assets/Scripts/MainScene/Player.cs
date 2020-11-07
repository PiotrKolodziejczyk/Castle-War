using Assets.Scripts.CastleScene;
using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainScene;
using Assets.Scripts.SavingData;
using System.IO;
using UnityEngine;

public class Player : GameModule, IArmy, IMaterials
{
    [SerializeField] private Army army;
    [SerializeField] private Materials materials;
    public Army Army { get => army; set => army = value; }
    public Materials Materials { get => materials; set => materials = value; }
}
