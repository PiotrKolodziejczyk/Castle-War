using Assets.Scripts.HelpingClass;
using Assets.Scripts.SavingData;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public TMP_InputField nickName;
    public LoadSavingData savingData;
    public GameObject panel;
    public GameObject savingPanel;
    public GameObject achivments;
    public GameObject options;
    public void LoadNewGame()
    {
        Initializing.Load(nickName.text, savingData);
        Global.whichScene = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void ToMap()
    {
        if (TrainingManager.train && !TrainingManager.firstLevelOfTrainingCastleScene)
        {
            TrainingManager.firstLevelOfTrainingBattleScene = false;
        }
        if (TrainingManager.firstLevelOfTrainingCastleScene)
        {
            TrainingManager.secondTrainingLevelOnMainScene = true;
            TrainingManager.firstLevelOfTrainingCastleScene = false;
            TrainingManager.secondLevelOfTrainingCastleScene = true;
        }
        if (TrainingManager.secondLevelOfTrainingCastleScene)
        {
            TrainingManager.secondLevelOfTrainingCastleScene = false;
        }
        Global.whichScene = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void ToMenu()
    {
        Global.whichScene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadAppropriateScene()
    {
        string text = GetComponent<Text>().text;
        if (text != "Save Template")
        {
            SavingSaveData data = SaveSystem.LoadSavingData(text);
            Global.globalInitializingClass = new GlobalInitializingClass
            {
                nickName = data.nickName,
                currentSavePlayerPosition = data.currentSavePlayerPosition,
                currentSaveAiPosition = data.currentSaveAiPosition,
                currentSaveCastleSave = data.currentSaveCastleSave,
                currentSavePlayerArmy = data.currentSavePlayerArmy,
                currentSaveEnemyArmy = data.currentSaveEnemyArmy
            };
            Global.whichScene = "SampleScene";
            SceneManager.LoadScene("LoadingScene");
        }
    }
    public void LoadData()
    {
        if (panel.activeSelf)
        {
            savingPanel.SetActive(true);
            panel.SetActive(false);
        }
        else
        {
            savingPanel.SetActive(false);
            panel.SetActive(true);
        }
    }
    public void ToMenuFromAchivments()
    {
        achivments.SetActive(false);
        panel.SetActive(true);
    }
    public void ToMenuFromOptions()
    {
        options.SetActive(false);
        panel.SetActive(true);
    }
    public void OnAchivments()
    {
        achivments.SetActive(true);
        panel.SetActive(false);
    }
    public void OnOptions()
    {
        options.SetActive(true);
        panel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
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
