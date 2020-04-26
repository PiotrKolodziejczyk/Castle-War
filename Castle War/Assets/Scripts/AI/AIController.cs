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
    private void Awake()
    {
        items = transform.GetComponentsInChildren<Transform>().ToList();
        AiPositionData data = SaveSystem.LoadAiPosition();
        Vector3 position = new Vector3(data.x, data.y, data.z);
        transform.position = position;
    }
    private void Start()
    {
        aiCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("Enemy") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        playerCastles = FindObjectsOfType<Transform>().Where(x => x.gameObject.layer == LayerMask.NameToLayer("I") && Regex.Match(x.name, @"Castle\(Clone\)\s*\(\d+\)").Success).ToList();
        AcceptMove(whichCaslte);
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            whichCaslte = Random.Range(0, aiCastles.Count);
            AcceptMove(whichCaslte);
            time = 30;
        }
        if (isMove)
            AIMove(whichCaslte);
    }
    public void AIMove(int castle)
    {
        animator.SetBool("isRun", true);
        audioSource.Play();

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

    private void AcceptMove(int castle)
    {
        var tmpPosition = new Vector3(aiCastles[castle].transform.position.x, 0, aiCastles[castle].transform.position.z);

        if (aiCastles[castle].transform.position != transform.position)
            transform.LookAt(tmpPosition);

        distance = Vector3.Distance(transform.position, aiCastles[castle].transform.position);
        distCovered = Time.deltaTime;
        isMove = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            foreach (var item in items)
                item.gameObject.layer = LayerMask.NameToLayer("VisibleAI");
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
