using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene.Buldings;
using UnityEngine;

public abstract class Soldier : GameModule
{
    public int helath;
    public int armor;
    public float speed;
    public TextInputQuantity textInputQuantity;
    public ResourcesToUpgradeLvl resources;
    public Castle castle;


    
}
