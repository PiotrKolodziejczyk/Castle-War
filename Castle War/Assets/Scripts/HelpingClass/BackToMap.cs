using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMap : MonoBehaviour
{
    public GameObject warning;
    public GameObject defend;
    public void BackToMapMethod()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToMenuMethod()
    {
        defend.SetActive(true);
        warning.SetActive(true);
    }
    public void No()
    {
        defend.SetActive(false);
        warning.SetActive(false);
    }
    public void Yes()
    {
        SceneManager.LoadScene("Menu");
    }
}
