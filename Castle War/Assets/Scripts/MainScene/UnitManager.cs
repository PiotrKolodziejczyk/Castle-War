using UnityEngine;

public class UnitManager : MonoBehaviour
{

    RaycastHit hit = new RaycastHit();
    RaycastHit hit1 = new RaycastHit();
    public Map map;
    float distance;
    public bool isMove = false;
    float startTime;
    float fractionOfJourney;
    float distCovered;
    bool isHit = false;
    public Camera cam;
    public float x;
    public float y;
    public float z;
    Ray ray;
    private void Start()
    {
        
    }
    private void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit1);
        cam.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
        if (Input.GetMouseButtonDown(0)&&hit1.transform.gameObject.layer==15 && !map.isEnabled)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            isHit = true;
            var tmpPosition = new Vector3(hit.transform.position.x, 0.334f, hit.transform.position.z);
            if (hit.transform.position != transform.position)
                transform.LookAt(tmpPosition);
            distance = Vector3.Distance(transform.position, hit.transform.position);
            distCovered = Time.deltaTime;
            isMove = true;
            map.isMove = true;

        }
        if (isHit &&isMove&&hit.transform.gameObject.layer==15)
        {
            Move();     
        }
        

        if (isHit&&transform.position.x == hit.transform.position.x && transform.position.z == hit.transform.position.z)
        {
            isMove = false;
            isHit = false;
            map.isMove = false;

        }

    }

    private void Move()
    {
        Debug.Log(Vector3.Distance(hit.transform.position, transform.position));
        if (Vector3.Distance(hit.transform.position, transform.position) > 0.335 && !map.isEnabled)
        {
            distCovered += Time.deltaTime * 0.03f;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(transform.position,
                               new Vector3(hit.transform.position.x, 0.334f, hit.transform.position.z),
                                   fractionOfJourney);
        }
        if(Vector3.Distance(hit.transform.position, transform.position) < 0.335)
        {
            map.isMove = false;
        }
       

    }





}
