using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
