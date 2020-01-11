using UnityEngine;

public class UnitManager : MonoBehaviour
{

    RaycastHit hit = new RaycastHit();
    float distance;
    bool isMove = false;
    float startTime;
    float fractionOfJourney;
    float distCovered;
    bool isHit = false;
    Vector3 target;
    private void Start()
    {
        
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            isHit = true;
            
            distance = Vector3.Distance(transform.position, hit.transform.position);
            distCovered = Time.deltaTime;
            isMove = true;
            

        }
        if (isHit &&isMove&& hit.transform.gameObject.layer == 15)
        {
            Move();
        }
        

        if (isHit&&transform.position.x == hit.transform.position.x && transform.position.z == hit.transform.position.z)
        {
            isMove = false;
            isHit = false;
        }

    }

    private void Move()
    {

        distCovered += Time.deltaTime * 0.03f;
        fractionOfJourney = distCovered / distance;
        transform.position = Vector3.Lerp(transform.position,
                           new Vector3(hit.transform.position.x, 0.334f, hit.transform.position.z),
                               fractionOfJourney);
        

    }





}
