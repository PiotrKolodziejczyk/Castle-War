using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    Castle castle;
    public Texture2D texture;
    public Texture2D texture1;
    bool isPlayerHere;

    private void Awake()
    {
        castle = GetComponent<Castle>();
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDown()
    {
        if (isPlayerHere && castle.id < 100)
        {
            Global.currentCastle = castle.id;
            Global.whichScene = "CastleScene";
            SceneManager.LoadScene("LoadingScene");
        }
        else if (isPlayerHere && castle.id > 100)
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

    private void OnMouseEnter()
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }
}
