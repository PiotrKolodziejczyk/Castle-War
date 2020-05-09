using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class OptimalizeScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<SphereCollider> coliders;
    [SerializeField] List<MeshRenderer> meshes;
    [SerializeField] List<GameObject> playerCastles;
    
    private void Start()
    {
        player = FindObjectsOfType<Transform>().Where(x => x.tag == "Player").First();
        coliders = GetComponentsInChildren<SphereCollider>().ToList();
        meshes = GetComponentsInChildren<MeshRenderer>().ToList();
        playerCastles = FindObjectsOfType<GameObject>().Where(x => x.tag == "PlayerCastle").ToList();
        foreach (var castle in playerCastles)
            foreach (var item in meshes)
            {
                if (Vector3.Distance(item.transform.position, castle.transform.position) < 6)
                {
                    item.transform.tag = "PlayerTerain";
                    item.enabled = true;
                }
            }
    }

    void Update()
    {
        foreach (var item in coliders)
            if (Vector3.Distance(player.transform.position, item.transform.position) > 6 && !Regex.IsMatch(item.name,@"Castle\(Clone\)\s*\(\d+\)"))
            {
                if (item.enabled)
                    item.enabled = false;
            }
            else
                item.enabled = true;
        EnableMeshes(player.transform);
    }

    private void EnableMeshes(Transform tran)
    {
        foreach (var item in meshes)
            if (Vector3.Distance(tran.position, item.transform.position) > 6)
            {
                if (item.transform.tag != "PlayerTerain")
                    item.enabled = false;
            }
            else
                item.enabled = true;
    }
}
