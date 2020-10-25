using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMap : MonoBehaviour
{
    public GameObject warning;
    public GameObject defend;
    public void BackToMapMethod()
    {
        Global.PAUSE = false;
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToMenuMethod()
    {
        Global.PAUSE = true;
        defend.SetActive(true);
        warning.SetActive(true);
    }
    public void No()
    {
        Global.PAUSE = false;
        defend.SetActive(false);
        warning.SetActive(false);
    }
    public void Yes()
    {
        Global.PAUSE = false;
        SceneManager.LoadScene("Menu");
    }
}
