using UnityEngine;

public class EnemyRun : MonoBehaviour
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
    [SerializeField]
    PlayerArmyInBattle army;
    Soldier soldier;
    private void Awake()
    {
        army = GetComponent<PlayerArmyInBattle>();
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
        transform.position = new Vector3(transform.position.x + (cur + curMinus * Time.deltaTime), 0,
                                         transform.position.z + (forward + forwardMinus * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeRunDirection(other, soldier);

        if (other.gameObject.layer == 14)
        {
            deadSounds.Play();
            Destroy(gameObject);
            other.gameObject.layer = 0;
        }
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
        if (army.player.pikeman.textInputQuantity.quantity > 0)
        {
            Instantiate(pikemanPrefab, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusPikeman();
        }
    }
    public void InstantiateAxeman()
    {
        if (army.player.warrior.textInputQuantity.quantity > 0)
        {
            Instantiate(warriorPrefab, new Vector3(-10.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusWarrior();
        }

    }
    public void InstantiateKnight()
    {
        if (army.player.knight.textInputQuantity.quantity > 0)
        {
            Instantiate(knightPrefab, new Vector3(-30.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusKnight();
        }
    }
    public void MinusPikeman()
    {
        --army.player.pikeman.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army);
    }
    public void MinusWarrior()
    {
        --army.player.warrior.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army);
    }
    public void MinusKnight()
    {
        --army.player.knight.textInputQuantity.quantity;
        SaveSystem.SavePlayerArmyData(army);
    }

}

