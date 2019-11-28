using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    RaycastHit hit;
    float distance;
    bool isMove;
    float startTime;
    float fractionOfJourney;
    float distCovered;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            distance = Vector3.Distance(transform.position, hit.transform.position);
            distCovered = Time.deltaTime;
            isMove = true;
           
        }
        if (isMove)
        {
            Move();

        }
        if (transform.position.x == hit.transform.position.x&&transform.position.z==hit.transform.position.z)
        {
            isMove = false;
        }
    }

    private void Move()
    {
        distCovered += Time.deltaTime * 0.03f;
        fractionOfJourney = distCovered / distance;
        transform.position = Vector3.Lerp(transform.position,
                         new Vector3(hit.transform.position.x, 0.18f, hit.transform.position.z),
                             fractionOfJourney);
    }





}
