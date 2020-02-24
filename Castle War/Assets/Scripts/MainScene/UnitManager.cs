using UnityEngine;

public class UnitManager : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    RaycastHit hit1 = new RaycastHit();
    Ray ray;
    float distance;
    float startTime;
    float fractionOfJourney;
    float distCovered;
    public Camera cam;
    public Map map;
    public float x;
    public float y;
    public float z;
    public bool isMove = false;
    public Animator animator;
    public AudioSource audioSource;
    internal int pikinierQuantity;
    internal int warriorQuantity;
    internal int knightQuantity;
    internal int woodTowerQuantity;
    internal int stoneTowerQuantity;
    internal int greatTowerQuantity;

    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position = new Vector3(data.x, data.y, data.z);
        transform.position = position;
        pikinierQuantity = data.pikinierQuantity;
        warriorQuantity = data.warriorQuantity;
        knightQuantity = data.knightQuantity;
        woodTowerQuantity = data.woodTowerQuantity;
        stoneTowerQuantity = data.stoneTowerQuantity;
        greatTowerQuantity = data.greatTowerQuantity;
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit1);
        cam.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);

        if (Input.GetMouseButtonDown(0) && hit1.transform.gameObject.layer == 15 && !map.isEnabled)
        {
            animator.SetBool("isRun", true);
            audioSource.Play();
            ShotRayAndAcceptMove();
        }

        if (isMove && hit.transform.gameObject.layer == 15)
        {
            Move();
        }
    }

    private void ShotRayAndAcceptMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        var tmpPosition = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);

        if (hit.transform.position != transform.position)
            transform.LookAt(tmpPosition);

        distance = Vector3.Distance(transform.position, hit.transform.position);
        distCovered = Time.deltaTime;
        isMove = true;
        map.isMove = true;
    }

    private void Move()
    {
        if (Vector3.Distance(hit.transform.position, transform.position) > 0.1f && !map.isEnabled)
        {
            distCovered += Time.deltaTime * 0.03f;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(transform.position,
                               new Vector3(hit.transform.position.x, 0.1f, hit.transform.position.z),
                                   fractionOfJourney);
        }

        if (Vector3.Distance(hit.transform.position, transform.position) < 0.2f)
        {
            map.isMove = false;
            isMove = false;
            animator.SetBool("isRun", false);
            audioSource.Stop();
            SaveSystem.SavePlayer(this);
        }
    }
}
