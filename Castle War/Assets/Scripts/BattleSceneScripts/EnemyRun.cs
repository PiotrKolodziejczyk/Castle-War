using Assets.Scripts.CastleScene;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    private float forward;
    private float forwardMinus;
    private float cur;
    private float curMinus;
    public GameObject Knight;
    public GameObject Pikeman;
    public GameObject Axeman;
    public TowerShooting towerShooting;
    public AudioSource deadSounds;
    [SerializeField]
    PlayerArmyInBattle army;
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
                    forward = 0.3f;
                    return;
                }
            case "Pikeman":
                {
                    forward = 0.5f;
                    return;
                }
            case "Axeman":
                {
                    forward = 0.7f;
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
        ChangeRunDirection(other);

        if (other.gameObject.layer == 14)
        {
            deadSounds.Play();
            Destroy(gameObject);
            other.gameObject.layer = 0;
        }
    }

    private void ChangeRunDirection(Collider other)
    {
        if (other.name == "ChangeFor")
        {
            forward = 0.5f;
            forwardMinus = 0;
            cur = 0;
            curMinus = 0;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (other.name == "ChangeCur")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0.5f;
            curMinus = 0;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (other.name == "ChangeCurMinus")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0;
            curMinus = -15f;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (other.name == "ChangeForMinus")
        {
            forward = 0;
            forwardMinus = -6f;
            cur = 0;
            curMinus = 0;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void InstantiatePikeman()
    {
        if (army.player.pikeman.textInputQuantity.quantity > 0)
        {
            Instantiate(Pikeman, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusPikeman();
        }
    }
    public void InstantiateAxeman()
    {
        if (army.player.warrior.textInputQuantity.quantity > 0)
        {
            Instantiate(Axeman, new Vector3(-10.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
            MinusWarrior();
        }

    }
    public void InstantiateKnight()
    {
        if (army.player.knight.textInputQuantity.quantity > 0)
        {
            Instantiate(Knight, new Vector3(-30.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));
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

