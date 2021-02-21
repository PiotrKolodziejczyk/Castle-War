using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene.Buldings;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : GameModule
{
    [SerializeField] public int damage;
    [SerializeField] internal TextInputQuantity textInputQuantity;
    public ResourcesToUpgradeLvl resources;
    public Castle castle;
    public TimeProperties timeProperties;
}
