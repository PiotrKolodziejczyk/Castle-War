using Assets.Scripts.BattleSceneScripts;

public class Warrior : Soldier
{
    public override void Initialize()
    {
        helath = 150;
        speed = 1.5f;
        if (transform.parent.parent.name != "EnemyAI" && transform.parent.parent.name != "TowerManagerGameObject" && transform.parent.name != "Player")
        {
            castle = transform.parent.GetComponentInParent<Castle>();
            MainResourcesClass.InitializeResources(ref resources, ResourcesEnum.Warrior.ToString(), castle.barrack, castle.townHall);
        }
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
