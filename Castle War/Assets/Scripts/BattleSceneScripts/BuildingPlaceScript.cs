using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceScript : MonoBehaviour
{
    GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.name == "TowerB(Clone)")
        {
           
            other.GetComponent<TowerManager>().building = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TowerB(Clone)")
        {
           other.GetComponent<TowerManager>().building = false;

        }
    }
}
