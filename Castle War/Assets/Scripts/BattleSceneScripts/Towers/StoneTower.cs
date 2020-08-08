using Assets.Scripts.BattleSceneScripts;

public class StoneTower : Tower
{
    public override void Initialize()
    {
        if (transform.parent.parent.name != "EnemyAI" && transform.parent.parent.name != "TowerManagerGameObject" && transform.parent.name != "Player")
        {
            castle = transform.parent.GetComponentInParent<Castle>();
            MainResourcesClass.InitializeResources(ref resources, ResourcesEnum.StoneTower.ToString(), castle.towerWorkShop, castle.townHall);
        }
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
