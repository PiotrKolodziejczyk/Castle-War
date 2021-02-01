using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public GameObject arthur;
    public GameObject knight;
    public GameObject menu;
    public GameObject chooseMenu;
    public Animator animation;
    public bool on = false;
    public bool off = false;
    private float timer = 2f;
    private float timer1 = 2f;
    public Texture2D cursor;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        arthur.SetActive(false);
        knight.SetActive(false);
    }
    public void Change()
    {
        if (arthur.activeSelf == true)
        {
            arthur.SetActive(false);
            knight.SetActive(true);
            Global.isArtur = false;
            Global.playerCastles = 4;
        }
        else
        {
            arthur.SetActive(true);
            knight.SetActive(false);
            Global.isArtur = true;
            Global.playerCastles = 5;
        }
    }
    private void Update()
    {
        if (on)
        {
            animation.SetBool("New Game", true);
            menu.SetActive(false);
            if (Global.Timer(ref timer))
            {
                arthur.SetActive(true);
                Global.isArtur = true;
                Global.playerCastles = 5;
                chooseMenu.SetActive(true);
                on = false;
                timer1 = 2;
                animation.SetBool("New Game", false);
            }
        }
        if (off)
        {
            animation.SetBool("Back", true);
            chooseMenu.SetActive(false);
            arthur.SetActive(false);
            knight.SetActive(false);
            if (Global.Timer(ref timer1))
            {
                menu.SetActive(true);
                off = false;
                timer = 2;
                animation.SetBool("Back", false);
            }
        }
    }
    public void ToMenu()
    {
        if (menu.activeSelf)
        {
            chooseMenu.SetActive(true);
            menu.SetActive(false);
            arthur.SetActive(false);
            knight.SetActive(false);
        }
        else
        {
            chooseMenu.SetActive(false);
            menu.SetActive(true);
        }
    }
    public void On()
    {
        on = true;
    }
    public void Off()
    {
        off = true;
    }
}
