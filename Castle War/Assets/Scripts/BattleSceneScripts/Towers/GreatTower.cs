using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene.Buldings;

public class GreatTower : Tower
{
    public override void Initialize()
    {
        damage = 100;
        if (transform.parent.parent.name != "EnemyAI" && transform.parent.parent.name != "TowerManagerGameObject" && transform.parent.name != "Player")
        {
            castle = transform.parent.GetComponentInParent<Castle>();
            MainResourcesClass.InitializeResources(ref resources, ResourcesEnum.GreatTower.ToString(), castle.towerWorkShop, castle.townHall);
            timeProperties = GetComponent<TimeProperties>();
        }
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
