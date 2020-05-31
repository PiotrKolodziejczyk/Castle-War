using Assets.Scripts.HelpingClass;
using Assets.Scripts.SavingData;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public List<Transform> aiCastles;
    public List<Transform> playerCastles;
    private float time = 30;
    private int whichCaslte = 0;
    private List<Transform> items;
    private bool isAttack;
    private float timeToAttack = 20;
    private int castleToAttackIndex = -1;
    [SerializeField] private Moving moving;
    private void Awake()
    {
        isAttack = false;
        items = transform.GetComponentsInChildren<Transform>().ToList();
        AiPositionData data = SaveSystem.LoadAiPosition();
        Vector3 position = new Vector3(data.x, data.y, data.z);
        transform.position = position;
    }
    private void Start()
    {
        moving = new Moving();
        aiCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("Enemy") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        playerCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("I") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        AcceptMove(whichCaslte, false);
    }

    private void Update()
    {
        if (!isAttack)
        {
            if (Global.Timer(ref timeToAttack))
                isAttack = true;
            if (Global.Timer(ref time))
            {
                whichCaslte = Random.Range(0, aiCastles.Count);
                AcceptMove(whichCaslte, false);
                time = 100;
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
    }
    public void AIMove(int castle, bool attack)
    {
        animator.SetBool("isRun", true);
        audioSource.Play();
        if (!attack)
        {
            moving.StartMoving(aiCastles[castle].transform.position, transform);
            moving.StopMoving(aiCastles[castle].transform.position, transform.position, animator, audioSource);
            SaveSystem.SaveAIPosition(this);
        }
        else
        {
            moving.StartMoving(playerCastles[castle].transform.position, transform);
            moving.StopMoving(playerCastles[castle].transform.position, transform.position, animator, audioSource);
            SaveSystem.SaveAIPosition(this);
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            foreach (Transform item in items)
                item.gameObject.layer = LayerMask.NameToLayer("VisibleAI");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("I") && castleToAttackIndex != -1)
        {
            castleToAttackIndex = -1;
            AIAttackScript.SimulateAttack(other.gameObject.GetComponent<Castle>().id);
        }

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
