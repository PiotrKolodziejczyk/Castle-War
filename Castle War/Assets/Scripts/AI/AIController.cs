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
    float distance;
    float startTime;
    float fractionOfJourney;
    float distCovered;
    public bool isMove = false;
    float time = 30;
    int whichCaslte = 0;
    List<Transform> items;
    bool isAttack;
    float timeToAttack = 60;
    int castleToAttackIndex = -1;
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
        aiCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("Enemy") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        playerCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("I") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        AcceptMove(whichCaslte, false);
    }
    void Update()
    {
        if (!isAttack)
        {
            time -= Time.deltaTime;
            timeToAttack -= Time.deltaTime;
        }
        if (timeToAttack < 0)
            isAttack = true;
        if (time < 0 && !isAttack)
        {
            whichCaslte = Random.Range(0, aiCastles.Count);
            AcceptMove(whichCaslte, false);
            time = 30;
        }
        if (isAttack)
        {
            var playerCastleDistance = Vector3.Distance(aiCastles[whichCaslte].position, playerCastles[0].position);
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
        if (isMove && castleToAttackIndex != -1)
            AIMove(castleToAttackIndex, true);
        else if (isMove && castleToAttackIndex == -1)
            AIMove(whichCaslte, false);
    }
    public void AIMove(int castle, bool attack)
    {
        animator.SetBool("isRun", true);
        audioSource.Play();
        if (!attack)
        {
            if (Vector3.Distance(aiCastles[castle].transform.position, transform.position) > 0.1f)
            {
                distCovered += Time.deltaTime * 0.03f;
                fractionOfJourney = distCovered / distance;
                transform.position = Vector3.Lerp(transform.position,
                                   new Vector3(aiCastles[castle].transform.position.x, 0.1f, aiCastles[castle].transform.position.z),
                                       fractionOfJourney);
            }

            if (Vector3.Distance(aiCastles[castle].transform.position, transform.position) < 0.2f)
            {
                isMove = false;
                animator.SetBool("isRun", false);
                audioSource.Stop();
                SaveSystem.SaveAIPosition(this);
            }
        }
        else
        {
            if (Vector3.Distance(playerCastles[castle].transform.position, transform.position) > 0.1f)
            {
                distCovered += Time.deltaTime * 0.03f;
                fractionOfJourney = distCovered / distance;
                transform.position = Vector3.Lerp(transform.position,
                                   new Vector3(playerCastles[castle].transform.position.x, 0.1f, playerCastles[castle].transform.position.z),
                                       fractionOfJourney);
            }

            if (Vector3.Distance(playerCastles[castle].transform.position, transform.position) < 0.2f)
            {
                isMove = false;
                animator.SetBool("isRun", false);
                audioSource.Stop();
                SaveSystem.SaveAIPosition(this);
                if (castleToAttackIndex != -1)
                {
                    castleToAttackIndex = -1;
                    AIAttackScript.SimulateAttack(playerCastles[castle].GetComponent<Castle>().id);
                }

            }
        }
    }

    private void AcceptMove(int castle, bool attack)
    {
        if (!attack)
        {
            var tmpPosition = new Vector3(aiCastles[castle].transform.position.x, 0, aiCastles[castle].transform.position.z);

            if (aiCastles[castle].transform.position != transform.position)
                transform.LookAt(tmpPosition);

            distance = Vector3.Distance(transform.position, aiCastles[castle].transform.position);
            distCovered = Time.deltaTime;
            isMove = true;
        }
        else
        {
            var tmpPosition = new Vector3(playerCastles[castle].transform.position.x, 0, playerCastles[castle].transform.position.z);

            if (playerCastles[castle].transform.position != transform.position)
                transform.LookAt(tmpPosition);

            distance = Vector3.Distance(transform.position, playerCastles[castle].transform.position);
            distCovered = Time.deltaTime;
            isMove = true;
            isAttack = false;
            timeToAttack = 120;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            foreach (var item in items)
                item.gameObject.layer = LayerMask.NameToLayer("VisibleAI");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("I") && castleToAttackIndex != -1)
        {

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            foreach (var item in items)
                item.gameObject.layer = LayerMask.NameToLayer("AI");
        }
    }
}
