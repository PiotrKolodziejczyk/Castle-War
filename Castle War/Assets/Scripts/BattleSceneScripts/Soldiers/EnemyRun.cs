using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRun : GameModule
{
    private float forward;
    private float forwardMinus;
    private float cur;
    private float curMinus;
    public GameObject knightPrefab;
    public GameObject pikemanPrefab;
    public GameObject warriorPrefab;
    public Pikeman pikeman;
    public Warrior warrior;
    public Knight knight;
    public TowerShooting towerShooting;
    public AudioSource deadSounds;
    [SerializeField] private PlayerArmyInBattle army;
    private Soldier soldier;
    public TextMeshPro damageText;
    private float time = 2;
    float unitTime = 0.5f;
    bool instantiate = false;
    bool instantiateUnit = false;
    private void Awake()
    {
        army = GetComponentInChildren<PlayerArmyInBattle>();
        deadSounds = GameObject.FindGameObjectWithTag("DeadSound").GetComponent<AudioSource>();
    }
    private void Start()
    {
        ChooseUnit();
    }


    private void ChooseUnit()
    {
        switch (transform.tag)
        {
            case "Knight":
                {
                    knight = GetComponent<Knight>();
                    soldier = knight;
                    forward = knight.speed;

                    return;
                }
            case "Pikeman":
                {
                    pikeman = GetComponent<Pikeman>();
                    soldier = pikeman;
                    forward = pikeman.speed;
                    return;
                }
            case "Axeman":
                {
                    warrior = GetComponent<Warrior>();
                    soldier = warrior;
                    forward = warrior.speed;
                    return;
                }
        }
    }

    private void Update()
    {
        if (!Global.PAUSE)
        {
            transform.position = new Vector3(transform.position.x + (cur + curMinus * Time.deltaTime), 0,
                                             transform.position.z + (forward + forwardMinus * Time.deltaTime));
            if (damageText != null && damageText.text != "")
                if (Global.Timer(ref time))
                {
                    damageText.text = "";
                    time = 2;
                }

            if (instantiate)
            {
                if (Global.Timer(ref unitTime))
                {
                    instantiateUnit = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeRunDirection(other, soldier);

        if (other.gameObject.layer == 14)
        {
            Hit(50, other);
        }
        if (other.gameObject.layer == 19)
        {
            Hit(75, other);
        }
        if (other.gameObject.layer == 20)
        {
            Hit(100, other);
        }
    }
    private void Hit(float damage,Collider other)
    {
        int hit = (int)(damage * Random.Range(0.6f, 1.4f));
        soldier.helath -= hit;
        damageText.text = hit.ToString();
        if (soldier.helath <= 0)
        {
            deadSounds.Play();
            Destroy(gameObject);
        }
        other.gameObject.layer = 0;
    }

    private void ChangeRunDirection(Collider other, Soldier cursoldier)
    {
        if (other.name == "ChangeFor")
        {
            forward = 0.5f * cursoldier.speed;
            forwardMinus = 0;
            cur = 0;
            curMinus = 0;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (other.name == "ChangeCur")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0.5f * cursoldier.speed;
            curMinus = 0;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (other.name == "ChangeCurMinus")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0;
            curMinus = -15f * cursoldier.speed;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (other.name == "ChangeForMinus")
        {
            forward = 0;
            forwardMinus = -6f * cursoldier.speed;
            cur = 0;
            curMinus = 0;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void InstantiatePikeman()
    {
        instantiate = true;
        if (army.army.pikeman.textInputQuantity.quantity > 0)
        {
            if (instantiateUnit)
            {
                Instantiate(pikemanPrefab, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
                MinusPikeman();
                unitTime = 0.5f;
                instantiate = false;
                instantiateUnit = false;
            }
        }
    }
    public void InstantiateAxeman()
    {
        instantiate = true;
        if (army.army.warrior.textInputQuantity.quantity > 0)
        {
            if (instantiateUnit)
            {
                Instantiate(warriorPrefab, new Vector3(-10.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
                MinusWarrior();
                unitTime = 0.5f;
                instantiate = false;
                instantiateUnit = false;
            }
        }

    }
    public void InstantiateKnight()
    {
        instantiate = true;
        if (army.army.knight.textInputQuantity.quantity > 0)
        {
            if (instantiateUnit)
            {
                Instantiate(knightPrefab, new Vector3(-30.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
                MinusKnight();
                unitTime = 0.5f;
                instantiateUnit = false;
                instantiate = false;
            }
        }
    }
    public void MinusPikeman()
    {
        --army.army.pikeman.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army, Global.globalInitializingClass.currentSavePlayerArmy);
    }
    public void MinusWarrior()
    {
        --army.army.warrior.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army, Global.globalInitializingClass.currentSavePlayerArmy);
    }
    public void MinusKnight()
    {
        --army.army.knight.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army, Global.globalInitializingClass.currentSavePlayerArmy);
    }

}

