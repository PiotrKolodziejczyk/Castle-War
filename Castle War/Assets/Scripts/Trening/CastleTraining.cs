using Assets.Scripts.HelpingClass;
using UnityEngine;

public class CastleTraining : MonoBehaviour
{
    public GameObject firstTrainingLevel;
    public GameObject thirdTrainingLevel;
    public GameObject sixTrainingLevel;
    public GameObject sevenTrainingLevel;
    public GameObject eightTrainingLevel;
    public GameObject nineTrainingLevel;
    public GameObject elevenTrainingLevel;
    public GameObject twelveTrainingLevel;
    public GameObject switchToCastle;


    private void Update()
    {
        if(TrainingManager.firstLevelOfTrainingCastleScene && TrainingManager.firstTrainingLevelOnCastleScene && !firstTrainingLevel.activeSelf)
            firstTrainingLevel.SetActive(true);
        else if(TrainingManager.firstLevelOfTrainingCastleScene && !TrainingManager.firstTrainingLevelOnCastleScene)
            firstTrainingLevel.SetActive(false);
        
        if (TrainingManager.firstLevelOfTrainingCastleScene && TrainingManager.thirdTrainingLevelOnCastleScene && !thirdTrainingLevel.activeSelf)
            thirdTrainingLevel.SetActive(true);
        else if (TrainingManager.firstLevelOfTrainingCastleScene && !TrainingManager.thirdTrainingLevelOnCastleScene)
            thirdTrainingLevel.SetActive(false);

        if (TrainingManager.firstLevelOfTrainingCastleScene && TrainingManager.sixTrainingLevelOnCastleScene && !sixTrainingLevel.activeSelf)
            sixTrainingLevel.SetActive(true);
        else if (TrainingManager.firstLevelOfTrainingCastleScene && !TrainingManager.sixTrainingLevelOnCastleScene)
            sixTrainingLevel.SetActive(false);

        if (TrainingManager.firstLevelOfTrainingCastleScene && TrainingManager.sevenTrainingLevelOnCastleScene && !sevenTrainingLevel.activeSelf)
            sevenTrainingLevel.SetActive(true);
        else if (TrainingManager.firstLevelOfTrainingCastleScene && !TrainingManager.sevenTrainingLevelOnCastleScene)
            sevenTrainingLevel.SetActive(false);

        if (TrainingManager.firstLevelOfTrainingCastleScene && TrainingManager.eightTrainingLevelOnCastleScene && !eightTrainingLevel.activeSelf)
            eightTrainingLevel.SetActive(true);
        else if (TrainingManager.firstLevelOfTrainingCastleScene && !TrainingManager.eightTrainingLevelOnCastleScene)
            eightTrainingLevel.SetActive(false);

        if (TrainingManager.secondLevelOfTrainingCastleScene && TrainingManager.nineTrainingLevelOnCastleScene && !nineTrainingLevel.activeSelf)
            nineTrainingLevel.SetActive(true);
        else if (TrainingManager.secondLevelOfTrainingCastleScene && !TrainingManager.nineTrainingLevelOnCastleScene)
            nineTrainingLevel.SetActive(false);

        if (TrainingManager.secondLevelOfTrainingCastleScene && TrainingManager.elevenTrainingLevelOnCastleScene && !elevenTrainingLevel.activeSelf)
            elevenTrainingLevel.SetActive(true);
        else if (TrainingManager.secondLevelOfTrainingCastleScene && !TrainingManager.elevenTrainingLevelOnCastleScene)
            elevenTrainingLevel.SetActive(false);

        if (TrainingManager.secondLevelOfTrainingCastleScene && TrainingManager.twelveTrainingLevelOnCastleScene && !twelveTrainingLevel.activeSelf)
            twelveTrainingLevel.SetActive(true);
        else if (TrainingManager.secondLevelOfTrainingCastleScene && !TrainingManager.twelveTrainingLevelOnCastleScene)
            twelveTrainingLevel.SetActive(false);

        if (TrainingManager.secondLevelOfTrainingCastleScene && TrainingManager.switchToCastle && !switchToCastle.activeSelf)
            switchToCastle.SetActive(true);
        else if (TrainingManager.secondLevelOfTrainingCastleScene && !TrainingManager.switchToCastle)
            switchToCastle.SetActive(false);

    }
}
