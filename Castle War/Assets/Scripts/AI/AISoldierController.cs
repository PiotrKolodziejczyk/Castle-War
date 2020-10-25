using Assets.Scripts.CastleScene;
using UnityEngine;

public class AISoldierController : GameModule, IArmy
{
    private float time = 5;
    public Army army;
    public Army armyInAttack;
    [SerializeField] private GameObject pikemanPrefab;
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private GameObject knightPrefab;
    public Castle castle;
    private bool isInitialize = false;
    public GameObject DefendPanel;
    private bool isPlayer = false;

    public Army Army { get => army; set => army = value; }

    internal void InitializeAIEngine()
    {
        if (castle.isPlayer)
        {
            isPlayer = true;
            AiArmyData data = SaveSystem.LoadEnemyArmy(Global.globalInitializingClass.currentSaveEnemyArmy);
            if (data != null)
            {
                armyInAttack.pikeman.textInputQuantity.quantity = data.pikemanQuantity;
                armyInAttack.warrior.textInputQuantity.quantity = data.warriorQuantity;
                armyInAttack.knight.textInputQuantity.quantity = data.knightQuantity;
            }
            else
            {
                armyInAttack.pikeman.textInputQuantity.quantity = 30;
                armyInAttack.warrior.textInputQuantity.quantity = 30;
                armyInAttack.knight.textInputQuantity.quantity = 30;
            }
            army = armyInAttack;
        }
        else
        {
            army = GetComponentInParent<Army>();
        }
        isInitialize = true;
    }

    private void Update()
    {
        if (!Global.PAUSE)
            if (castle.isPlayer && isInitialize && Global.aiActive)
            {
                if (Global.Timer(ref time))
                {
                    InstantiatePikeman();
                    InstantiateWarrior();
                    InstantiateKnight();
                }
                if (isInitialize && isPlayer && army.pikeman.textInputQuantity.quantity == 0 && army.warrior.textInputQuantity.quantity == 0 && army.knight.textInputQuantity.quantity == 0)
                {
                    DefendPanel.SetActive(true);
                }
            }
    }
    public void Defend()
    {
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.SampleScene, castle.Id);
    }
    public void InstantiatePikeman()
    {
        if (army.pikeman.textInputQuantity.quantity > 0)
        {
            Instantiate(pikemanPrefab, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusPikeman();
        }
    }
    public void InstantiateWarrior()
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
        SaveSystem.SaveEnemyArmyData(this, Global.globalInitializingClass.currentSaveEnemyArmy);
    }
    public void MinusWarrior()
    {
        --army.warrior.textInputQuantity.quantity;
        time = 5;
        SaveSystem.SaveEnemyArmyData(this, Global.globalInitializingClass.currentSaveEnemyArmy);
    }
    public void MinusKnight()
    {
        --army.knight.textInputQuantity.quantity;
        time = 5;
        SaveSystem.SaveEnemyArmyData(this, Global.globalInitializingClass.currentSaveEnemyArmy);
    }
}
