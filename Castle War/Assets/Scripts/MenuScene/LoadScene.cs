using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNewGame()
    {
        Global.whichScene = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
    private void Update()
    {
        if (transform.name == "Loading")
            switch (Global.whichScene)
            {
                case "CastleScene":
                    SceneManager.LoadScene("CastleScene");
                    break;
                case "SampleScene":
                    SceneManager.LoadScene("SampleScene");
                    break;
                case "BattleScene":
                    SceneManager.LoadScene("BattleScene");
                    break;
                case "Menu":
                    SceneManager.LoadScene("Menu");
                    break;
            }
    }
}
