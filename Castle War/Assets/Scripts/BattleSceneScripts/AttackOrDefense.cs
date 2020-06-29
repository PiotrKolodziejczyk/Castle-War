using Assets.Scripts.HelpingClass;
using UnityEngine;

public class AttackOrDefense : MonoBehaviour
{
    [SerializeField] private Castle castle;
    [SerializeField] private GameObject pikeman;
    [SerializeField] private GameObject warrior;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject woodTower;
    [SerializeField] private GameObject stoneTower;
    [SerializeField] private GameObject greatTower;
    [SerializeField] private GameObject training1;
    [SerializeField] private GameObject trainin2;
    [SerializeField] private GameObject trainin3;
    public void SetCanvas()
    {
        if (TrainingManager.firstLevelOfTrainingBattleScene && TrainingManager.firstTrainingLevelOnBattleScene)
            training1.SetActive(true);
        if (TrainingManager.secondLevelOfTrainingBattleScene)
            trainin3.SetActive(true);
        if (!castle.isPlayer)
        {
            woodTower.SetActive(false);
            stoneTower.SetActive(false);
            greatTower.SetActive(false);
        }
        else
        {
            pikeman.SetActive(false);
            warrior.SetActive(false);
            knight.SetActive(false);
        }
    }
    private void Update()
    {
        if (TrainingManager.firstLevelOfTrainingBattleScene && !TrainingManager.firstTrainingLevelOnBattleScene && !trainin2.activeSelf)
        {
            training1.SetActive(false);
            trainin2.SetActive(true);
        }
        if (!TrainingManager.secondLevelOfTrainingBattleScene && trainin3.activeSelf)
        {
            trainin3.SetActive(false);
        }
    }
}
