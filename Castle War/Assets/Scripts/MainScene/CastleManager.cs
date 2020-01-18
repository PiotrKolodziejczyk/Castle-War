using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleManager : MonoBehaviour
{
    
    bool isPlayerHere;
    public Texture2D texture;
    public Texture2D texture1;

    private void Awake()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }
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
    private void OnMouseEnter()
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(texture1, Vector2.zero, CursorMode.ForceSoftware);
    }
}
