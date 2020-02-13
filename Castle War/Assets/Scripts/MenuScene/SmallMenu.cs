using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SmallMenu : MonoBehaviour
{
    bool isOn;
    [SerializeField]
    Animator anim;

    private void Start()
    {
        isOn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isOn)
        {
            anim.SetBool("isOn", false);
            isOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isOn)
        { 
            anim.SetBool("isOn", true);
            isOn = false;
        }
    }
    public void EnableMenu()
    {
        if (!isOn)
        {
            anim.SetBool("isOn", false);
            isOn = true;
        }
        else
        {
            anim.SetBool("isOn", true);
            isOn = false;
        }
    }
    public void ToMainMenu()
    {
        Global.whichScene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }
}
