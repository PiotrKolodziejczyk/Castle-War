using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    float timer = 5;
    public void LoadNewGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadSampleScene()
    {
        Global.whichScene = "SampleScene";
        LoadNewGame();
    }
    private void Update()
    {
        if (transform.name == "Loading")
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
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
    }
}
