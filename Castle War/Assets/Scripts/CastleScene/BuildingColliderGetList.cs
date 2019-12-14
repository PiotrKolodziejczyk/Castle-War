using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingColliderGetList : MonoBehaviour
{
    public List<BoxCollider> listBulding;
    void Awake()
    {
        listBulding = GetComponentsInChildren<BoxCollider>().Where(x => x.gameObject.tag == "Building").ToList();
    }

   
}
