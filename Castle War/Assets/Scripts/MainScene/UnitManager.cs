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
    

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit1);
        cam.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);

        if (Input.GetMouseButtonDown(0)&&hit1.transform.gameObject.layer==15 && !map.isEnabled)
        {
            ShotRayAndAcceptMove();
        }

        if (isMove&&hit.transform.gameObject.layer==15)
        {
            Move();     
        }
    }

    private void ShotRayAndAcceptMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        var tmpPosition = new Vector3(hit.transform.position.x, 0.334f, hit.transform.position.z);

        if (hit.transform.position != transform.position)
            transform.LookAt(tmpPosition);

        distance = Vector3.Distance(transform.position, hit.transform.position);
        distCovered = Time.deltaTime;
        isMove = true;
        map.isMove = true;
    }

    private void Move()
    {
        if (Vector3.Distance(hit.transform.position,transform.position) > 0.335 && !map.isEnabled)
        {
            distCovered += Time.deltaTime * 0.03f;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(transform.position,
                               new Vector3(hit.transform.position.x, 0.334f, hit.transform.position.z),
                                   fractionOfJourney);
        }

        if(Vector3.Distance(hit.transform.position,transform.position) < 0.335)
        {
            map.isMove = false;
            isMove = false;
        }
    }
}
