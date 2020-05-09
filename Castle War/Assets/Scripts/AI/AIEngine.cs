using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene;
using UnityEngine;

public class AIEngine : MonoBehaviour
{
    float time = 5;
    public Army army;
    public Army armyInAttack;
    [SerializeField] GameObject pikemanPrefab;
    [SerializeField] GameObject warriorPrefab;
    [SerializeField] GameObject knightPrefab;
    Castle castle;

    private void Start()
    {
        castle = GetComponentInParent<Castle>();
        if (castle.isPlayer)
        {
            army = armyInAttack;
            AiArmyData data = SaveSystem.LoadEnemyArmy();
            army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
            army.warrior.textInputQuantity.quantity = data.warriorQuantity;
            army.knight.textInputQuantity.quantity = data.knightQuantity;
        }
        else
        {
            army =  GetComponentInParent<Army>();
        }
    }

    void Update()
    {
        if (castle.isPlayer)
        {
            if (Global.Timer(ref time))
            {
                InstantiatePikeman();
                //InstantiateAxeman();
                //InstantiateKnight();
            }
        }
    }
    public void InstantiatePikeman()
    {
        if (army.pikeman.textInputQuantity.quantity > 0)
        {
            Instantiate(pikemanPrefab, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusPikeman();
        }
    }
    public void InstantiateAxeman()
    {
        if (army.warrior.textInputQuantity.quantity > 0)
        {
            Instantiate(warriorPrefab, new Vector3(-10.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusWarrior();
        }

    }
    public void InstantiateKnight()
    {
        if (army.knight.textInputQuantity.quantity > 0)
        {
            Instantiate(knightPrefab, new Vector3(-30.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusKnight();
        }
    }
    public void MinusPikeman()
    {
        --army.pikeman.textInputQuantity.quantity;
        time = 5;
        SaveSystem.SaveEnemyArmyData(this);
    }
    public void MinusWarrior()
    {
        --army.warrior.textInputQuantity.quantity;
        time = 5;
        SaveSystem.SaveEnemyArmyData(this);
    }
    public void MinusKnight()
    {
        --army.knight.textInputQuantity.quantity;
        time = 5;
        SaveSystem.SaveEnemyArmyData(this);
    }
}
