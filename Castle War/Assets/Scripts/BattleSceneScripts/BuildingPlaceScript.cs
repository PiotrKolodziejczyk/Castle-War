using System.Text.RegularExpressions;
using UnityEngine;

public class BuildingPlaceScript : MonoBehaviour
{
    Regex regex;
    private void Start()
    {
        regex = new Regex(@"Tower[ABC]\(Clone\)");
    }
    private void OnTriggerStay(Collider other)
    {

        if (regex.IsMatch(other.gameObject.name)&&other.gameObject.layer == 11)
        {
            //var meshList = other.GetComponentsInChildren<MeshRenderer>();
            //for (int i = 0; i < meshList.Length; i++)
            //{
            //    meshList[i].material.color = Color.white;
            //}

            other.GetComponent<TowerManager>().building = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (regex.IsMatch(other.gameObject.name) && other.gameObject.layer == 11)
        {
            //    var meshList = other.GetComponentsInChildren<MeshRenderer>();
            //    for (int i = 0; i < meshList.Length; i++)
            //    {
            //        meshList[i].material.color = Color.red;
            //    }
            other.GetComponent<TowerManager>().building = false;

        }
    }
}

