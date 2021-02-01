using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene.Buldings;

public abstract class Soldier : GameModule
{
    public int helath;
    public float speed;
    public TextInputQuantity textInputQuantity;
    public ResourcesToUpgradeLvl resources;
    public Castle castle;
}
