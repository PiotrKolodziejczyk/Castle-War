using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableMove : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D curentCursor;
    private void Awake()
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            transform.name = "NameDisable";
    }

    private void OnMouseEnter()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
            Cursor.SetCursor(curentCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
