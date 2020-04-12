using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    Castle castle;
    bool isPlayerHere;

    private void Awake()
    {
        castle = GetComponent<Castle>();
    }

    private void OnMouseDown()
    {
        if (isPlayerHere && castle.isPlayer)
        {
            Global.currentCastle = castle.id;
            Global.whichScene = "CastleScene";
            SceneManager.LoadScene("LoadingScene");
        }
        else if (isPlayerHere && !castle.isPlayer)
        {
            Global.currentCastle = castle.id;
            Global.whichScene = "BattleScene";
            SceneManager.LoadScene("LoadingScene");
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
