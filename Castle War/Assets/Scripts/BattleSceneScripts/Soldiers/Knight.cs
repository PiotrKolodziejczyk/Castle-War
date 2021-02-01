using Assets.Scripts.BattleSceneScripts;

public class Knight : Soldier
{
    public override void Initialize()
    {
        helath = 200;
        speed = 1;
        if (transform.parent.parent.name != "EnemyAI" && transform.parent.parent.name != "TowerManagerGameObject" && transform.parent.name != "Player")
        {
            castle = transform.parent.GetComponentInParent<Castle>();
            MainResourcesClass.InitializeResources(ref resources, ResourcesEnum.Knight.ToString(), castle.barrack, castle.townHall);
        }
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
