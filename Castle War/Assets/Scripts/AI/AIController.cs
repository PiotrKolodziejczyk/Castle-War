using Assets.Scripts.HelpingClass;
using Assets.Scripts.SavingData;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class AIController : GameModule
{
    private AIArmy AIArmy;
    public Animator animator;
    public AudioSource audioSource;
    public List<Transform> aiCastles;
    public List<Transform> playerCastles;
    private float time = 30;
    private int whichCaslte = 0;
    private List<Transform> items;
    private bool isAttack;
    private float timeToAttack = 30;
    private int castleToAttackIndex = -1;
    [SerializeField] private Moving moving;
    public TextMeshProUGUI text;
    public GameObject GameOver;
    public GameObject attack;
    public bool acceptAttack;
    public int id;

    public override void Initialize()
    {
        AIArmy = GetComponentInChildren<AIArmy>();
        isAttack = false;
        items = transform.GetComponentsInChildren<Transform>().ToList();
        if (!File.Exists(Global.Path + $"/{Global.globalInitializingClass.currentSaveAiPosition}.fun"))
        {
            transform.position = new Vector3(25.42f, 0.09998721f, 10f);
            SaveSystem.SaveAIPosition(this, Global.globalInitializingClass.currentSavePlayerPosition);
        }
        else
        {
            AiPositionData data = SaveSystem.LoadAiPosition(Global.globalInitializingClass.currentSaveAiPosition);
            Vector3 position = new Vector3(data.x, data.y, data.z);
            transform.position = position;
        }

        moving = new Moving();
        aiCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("Enemy") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        playerCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("I") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        AcceptMove(whichCaslte, false);
        text.text = "Castles :" + playerCastles.Count;
        if (playerCastles.Count == 0)
        {
            Global.PAUSE = true;
            GameOver.SetActive(true);
        }
    }

    private void Update()
    {

        if (!Global.PAUSE)
        {
            if (!isAttack)
            {
                if (Global.Timer(ref timeToAttack))
                    isAttack = true;
                if (Global.Timer(ref time))
                {
                    whichCaslte = UnityEngine.Random.Range(0, aiCastles.Count);
                    AcceptMove(whichCaslte, false);
                    time = 30;
                }
            }

            if (isAttack)
            {
                float playerCastleDistance = Vector3.Distance(aiCastles[whichCaslte].position, playerCastles[0].position);
                castleToAttackIndex = 0;
                for (int i = 1; i < playerCastles.Count; i++)
                {
                    if (Vector3.Distance(aiCastles[whichCaslte].position, playerCastles[i].position) < playerCastleDistance)
                    {
                        playerCastleDistance = Vector3.Distance(aiCastles[whichCaslte].position, playerCastles[i].position);
                        castleToAttackIndex = i;
                    }
                }
            }
            if (isAttack && castleToAttackIndex != -1)
                AcceptMove(castleToAttackIndex, true);
            if (moving.isMove && castleToAttackIndex != -1)
                AIMove(castleToAttackIndex, true);
            else if (moving.isMove && castleToAttackIndex == -1)
                AIMove(whichCaslte, false);
            if (acceptAttack)
            {
                acceptAttack = false;
                Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.BattleScene, id);
            }
        }
    }
    public void AIMove(int castle, bool attack)
    {
        animator.SetBool("isRun", true);
        audioSource.Play();
        if (!attack)
        {
            moving.StartMoving(aiCastles[castle].transform.position, transform);
            moving.StopMoving(aiCastles[castle].transform.position, transform.position, animator, audioSource);
            SaveSystem.SaveAIPosition(this, Global.globalInitializingClass.currentSaveAiPosition);
        }
        else
        {
            moving.StartMoving(playerCastles[castle].transform.position, transform);
            moving.StopMoving(playerCastles[castle].transform.position, transform.position, animator, audioSource);
            SaveSystem.SaveAIPosition(this, Global.globalInitializingClass.currentSaveAiPosition);
        }
    }

    private void AcceptMove(int castle, bool attack)
    {
        if (!attack)
            moving.AcceptMove(aiCastles[castle].transform.position, transform);
        else
        {
            moving.AcceptMove(playerCastles[castle].transform.position, transform);
            isAttack = false;
            timeToAttack = 30;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AIArmy.CheckAmontOfArmyInCastle(other.GetComponent<Castle>());
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("I") && castleToAttackIndex != -1)
        {
            castleToAttackIndex = -1;
            attack.SetActive(true);
            Global.PAUSE = true;
            id = other.gameObject.GetComponent<Castle>().Id;
        }

    }

    public void AcceptAttack()
    {
        acceptAttack = true;
        Global.PAUSE = false;
        attack.SetActive(false);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            foreach (Transform item in items)
                item.gameObject.layer = LayerMask.NameToLayer("AI");
        }
    }
}
