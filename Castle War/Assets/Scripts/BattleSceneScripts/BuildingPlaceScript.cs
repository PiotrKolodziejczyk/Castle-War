using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceScript : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "TowerB(Clone)")
        {
           var meshList= other.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.white;
            }
            
            other.GetComponent<TowerManager>().building = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TowerB(Clone)")
        {
            var meshList = other.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.red;
            }
            other.GetComponent<TowerManager>().building = false;

        }
    }
}
