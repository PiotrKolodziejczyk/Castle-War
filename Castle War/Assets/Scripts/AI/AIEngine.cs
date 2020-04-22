using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene;
using UnityEngine;

public class AIEngine : MonoBehaviour
{
    float time = 5;
    internal Army army;
    [SerializeField] GameObject pikemanPrefab;
    [SerializeField] GameObject warriorPrefab;
    [SerializeField] GameObject knightPrefab;
    Pikeman pikeman;
    Warrior warrior;
    Knight knight;
    TextInputQuantity pikemanTextInputQuantity;
    TextInputQuantity warriorTextInputQuantity;
    TextInputQuantity knightTextInputQuantity;
    Castle castle;
    private void Awake()
    {
        army = new Army();
        pikemanTextInputQuantity = new TextInputQuantity();
        pikeman = new Pikeman();
        pikeman.textInputQuantity = pikemanTextInputQuantity;
        army.pikeman = pikeman;
        warriorTextInputQuantity = new TextInputQuantity();
        warrior = new Warrior();
        warrior.textInputQuantity = warriorTextInputQuantity;
        army.warrior = warrior;
        knightTextInputQuantity = new TextInputQuantity();
        knight = new Knight();
        knight.textInputQuantity = knightTextInputQuantity;
        army.knight = knight;
        army.pikeman.textInputQuantity.quantity = 30;
        army.warrior.textInputQuantity.quantity = 30;
        army.knight.textInputQuantity.quantity = 30;
        castle = GetComponentInParent<Castle>();
        AiArmyData data = SaveSystem.LoadEnemyArmy();
        army.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
        army.warrior.textInputQuantity.quantity = data.warriorQuantity;
        army.knight.textInputQuantity.quantity = data.knightQuantity;
    }

    void Update()
    {
        if (castle.isPlayer)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                InstantiatePikeman();
                InstantiateAxeman();
                InstantiateKnight();
                time = 3;
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
        SaveSystem.SaveEnemyArmyData(this);
    }
    public void MinusWarrior()
    {
        --army.warrior.textInputQuantity.quantity;
        SaveSystem.SaveEnemyArmyData(this);
    }
    public void MinusKnight()
    {
        --army.knight.textInputQuantity.quantity;
        SaveSystem.SaveEnemyArmyData(this);
    }
}
