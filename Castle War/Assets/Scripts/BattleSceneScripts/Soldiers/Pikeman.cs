using Assets.Scripts.BattleSceneScripts;

public class Pikeman : Soldier
{
    public override void Initialize()
    {
        helath = 100;
        speed = 2;
        if (transform.parent.parent.name != "EnemyAI" && transform.parent.parent.name != "TowerManagerGameObject" && transform.parent.name != "Player")
        {
            castle = transform.parent.GetComponentInParent<Castle>();
            MainResourcesClass.InitializeResources(ref resources, ResourcesEnum.Pikeman.ToString(), castle.barrack, castle.townHall);
        }
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
