using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    bool isPlayerHere;
    
    private void OnMouseDown()
    {
        
        if (isPlayerHere && gameObject.layer == 9)
        {
            SceneManager.LoadScene("CastleScene");
        }
        else if(isPlayerHere && gameObject.layer == 8)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerHere = false;
        }
    }
}
