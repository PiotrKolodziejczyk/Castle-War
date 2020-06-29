using System.Text.RegularExpressions;
using UnityEngine;

public class BuildingPlaceScript : GameModule
{
    Regex regex;
    private void Awake()
    {
        regex = new Regex(@"(Wood|Stone|Great)Tower\(Clone\)");
    }
    //public override void Initialize()
    //{
    //    regex = new Regex(@"(Wood|Stone|Great)Tower\(Clone\)");

    //}
    private void OnTriggerStay(Collider other)
    {

        if (regex.IsMatch(other.gameObject.name)&&other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            var meshList = other.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < meshList.Length; i++)
            {
                meshList[i].material.color = Color.white;
            }

            other.GetComponent<TowerManager>().building = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (regex.IsMatch(other.gameObject.name) && other.gameObject.layer == LayerMask.NameToLayer("Tower"))
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

