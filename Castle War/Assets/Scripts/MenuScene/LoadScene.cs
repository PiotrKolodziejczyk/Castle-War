using Assets.Scripts.HelpingClass;
using Assets.Scripts.Initializing;
using Assets.Scripts.Interfaces;
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
        Development.NewGame = true;
        Tutorial.sampleSceneTutorial = true;
        Tutorial.castleSceneTutorial = true;
        Tutorial.battleSceneTutorial = true;
        Initializing.Load(nickName.text, savingData);
        Global.whichScene = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void ToMap()
    {
        Global.PAUSE = false;
        Global.whichScene = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void ToMenu()
    {
        Global.PAUSE = false;
        Global.whichScene = "Menu";
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadAppropriateScene()
    {
        string text = GetComponent<Text>().text;
        if (text != "Save Template")
        {
            SavingSaveData data = SaveSystem.LoadSavingData(text);
            Global.globalInitializingClass = new GlobalInitializingClass();
            Global.actualPlayerName = text;

            if (data.nickName != null)
                Global.globalInitializingClass.nickName = data.nickName;
            else
                Global.globalInitializingClass.nickName = text;

            if (data.currentSavePlayerPosition != null)
                Global.globalInitializingClass.currentSavePlayerPosition = data.currentSavePlayerPosition;
            else
                Global.globalInitializingClass.currentSavePlayerPosition = "playerPosition" + text;

            if (data.currentSaveAiPosition != null)
                Global.globalInitializingClass.currentSaveAiPosition = data.currentSaveAiPosition;
            else
                Global.globalInitializingClass.currentSaveAiPosition = "aiPosition" + text;

            if (data.currentSaveCastleSave != null)
                Global.globalInitializingClass.currentSaveCastleSave = data.currentSaveCastleSave;
            else
                Global.globalInitializingClass.currentSaveCastleSave = "";

            if (data.currentSavePlayerArmy != null)
                Global.globalInitializingClass.currentSavePlayerArmy = data.currentSavePlayerArmy;
            else
                Global.globalInitializingClass.currentSavePlayerArmy = "playerArmy" + text;

            if (data.currentSaveEnemyArmy != null)
                Global.globalInitializingClass.currentSaveEnemyArmy = data.currentSaveEnemyArmy;
            else
                Global.globalInitializingClass.currentSaveEnemyArmy = "";

            if (data.currentSavePlayerMaterials != null)
                Global.globalInitializingClass.currentSavePlayerMaterials = data.currentSavePlayerMaterials;
            else
                Global.globalInitializingClass.currentSavePlayerMaterials = "playerMaterials" + text;

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
