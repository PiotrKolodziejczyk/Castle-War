using Assets.Scripts.HelpingClass;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private RaycastHit hit = new RaycastHit();
    private RaycastHit hit1 = new RaycastHit();
    private Ray ray;
    public Animator animator;
    public AudioSource audioSource;
    public Moving moving;
    private readonly float startTime;
    public Camera cam;
    public EnableMap map;
    public float x;
    public float y;
    public float z;

    private void Start()
    {
        moving = new Moving();
        PlayerPositionData data = SaveSystem.LoadPlayerPosition();
        Vector3 position = new Vector3(data.x, data.y, data.z);
        transform.position = position;
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit1);
        cam.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);

        if (Input.GetMouseButtonDown(0) && hit1.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            animator.SetBool("isRun", true);
            audioSource.Play();
            ShotRayAndAcceptMove();
        }

        if (moving.isMove && hit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            Move();
    }

    private void ShotRayAndAcceptMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        moving.AcceptMove(hit.transform.position, transform);
    }

    private void Move()
    {
        moving.StartMoving(hit.transform.position, transform);
        moving.StopMoving(hit.transform.position, transform.position, animator, audioSource);
        SaveSystem.SavePlayerPosition(this);
    }
}
