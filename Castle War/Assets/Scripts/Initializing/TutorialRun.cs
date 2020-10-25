using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Initializing
{
    internal class TutorialRun : MonoBehaviour
    {
        public GameObject tutorial;

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "SampleScene" && Tutorial.sampleSceneTutorial)
                tutorial.SetActive(true);
            else if(SceneManager.GetActiveScene().name == "SampleScene" && tutorial.activeSelf)
                tutorial.SetActive(false);
            if (SceneManager.GetActiveScene().name == "BattleScene" && Tutorial.battleSceneTutorial)
                tutorial.SetActive(true);
            else if (SceneManager.GetActiveScene().name == "BattleScene" && tutorial.activeSelf)
                tutorial.SetActive(false);
            if (SceneManager.GetActiveScene().name == "CastleScene" && Tutorial.castleSceneTutorial)
                tutorial.SetActive(true);
            else if (SceneManager.GetActiveScene().name == "CastleScene" && tutorial.activeSelf)
                tutorial.SetActive(false);
            if (tutorial.activeSelf)
                Global.PAUSE = true;
        }

        public void CloseTutorial()
        {
            Global.PAUSE = false;
            if (SceneManager.GetActiveScene().name == "SampleScene")
                Tutorial.sampleSceneTutorial = false;
            if (SceneManager.GetActiveScene().name == "BattleScene")
                Tutorial.battleSceneTutorial = false;
            if (SceneManager.GetActiveScene().name == "CastleScene")
                Tutorial.castleSceneTutorial = false;
        }

        public void OpenTutorial()
        {
            Global.PAUSE = true;
            if (SceneManager.GetActiveScene().name == "SampleScene")
                Tutorial.sampleSceneTutorial = true;
            if (SceneManager.GetActiveScene().name == "BattleScene")
                Tutorial.battleSceneTutorial = true;
            if (SceneManager.GetActiveScene().name == "CastleScene")
                Tutorial.castleSceneTutorial = true;
        }
    }
}
