using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    public int id;
    public Texture2D texture;
    public Texture2D texture1;
    bool isPlayerHere;

    private void Awake()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDown()
    {

        if (isPlayerHere && gameObject.layer == 9)
        {
            Global.currentCastle = id;
            SceneManager.LoadScene("CastleScene");
            
        }
        else if (isPlayerHere && gameObject.layer == 8)
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

    private void OnMouseEnter()
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }
}
