using Assets.Scripts.HelpingClass;
using UnityEngine;

public class Training : MonoBehaviour
{
    public GameObject firstTrainingLevel;
    public GameObject secondTrainingLevel;
    public GameObject panel;
    public GameObject endTraining;

    public void Awake()
    {
        if (TrainingManager.firstTrainingLevelOnMainScene)
            firstTrainingLevel.SetActive(true);
        if (TrainingManager.secondTrainingLevelOnMainScene)
            secondTrainingLevel.SetActive(true);
        if (TrainingManager.thirdTrainingLevelOnMainScene && TrainingManager.train)
        {
            Global.treningPanelsActive = true;
            panel.SetActive(true);
        }
        if (TrainingManager.train && TrainingManager.endTraining)
        {
            endTraining.SetActive(true);
            Global.treningPanelsActive = true;
        }
        else
            endTraining.SetActive(false);

    }
    private void Update()
    {
        if (!TrainingManager.thirdTrainingLevelOnMainScene && TrainingManager.secondTrainingLevelOnMainScene)
            firstTrainingLevel.SetActive(false);
    }
    public void ExitPanel()
    {
        TrainingManager.thirdTrainingLevelOnMainScene = false;
        Global.treningPanelsActive = false;
        panel.SetActive(false);
    }
    public void ExitEndTraining()
    {
        TrainingManager.train = false;
        Global.treningPanelsActive = false;
        endTraining.SetActive(false);
        TrainingManager.firstLevelOfTrainingBattleScene = false;
        TrainingManager.secondLevelOfTrainingCastleScene = false;
        TrainingManager.firstLevelOfTrainingCastleScene = false;
        TrainingManager.secondLevelOfTrainingBattleScene = false;
    }

}
