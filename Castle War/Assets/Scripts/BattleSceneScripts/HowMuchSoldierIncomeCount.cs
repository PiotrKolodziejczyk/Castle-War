using Assets.Scripts.HelpingClass;
using TMPro;
using UnityEngine;

public class HowMuchSoldierIncomeCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;
    [SerializeField]
    private TextMeshProUGUI toWinText;
    private int count = 0;
    public Castle castle;
    public GameObject WinPanel;
    public GameObject LosePanel;
    private int soldiersToWin;
    private void Start()
    {
        soldiersToWin = (castle.Army.pikeman.textInputQuantity.quantity + castle.Army.warrior.textInputQuantity.quantity + castle.Army.knight.textInputQuantity.quantity) / 2;
        if (soldiersToWin < 10)
            soldiersToWin = 10;
        toWinText.text = soldiersToWin.ToString();
    }

    private void Update()
    {
        if (!castle.isPlayer && count >= soldiersToWin && !LosePanel.activeSelf)
            PlayerWin();
        if (castle.isPlayer && count >= soldiersToWin && !WinPanel.activeSelf)
            EnemyWin();
    }
    public void PlayerWin()
    {
        SaveCastleAndSetAppropriateTagAndLayer(true, "PlayerCastle", "I");
        if (TrainingManager.train)
        {
            TrainingManager.thirdTrainingLevelOnMainScene = true;
            Global.isAttackEnemy = true;
        }
        WinPanel.SetActive(true);
        Global.aiActive = false;
    }
    public void EnemyWin()
    {
        SaveCastleAndSetAppropriateTagAndLayer(false, "Untagged", "Enemy");
        LosePanel.SetActive(true);
        if (TrainingManager.train)
            TrainingManager.endTraining = true;
        Global.aiActive = false;
    }
    public void Win()
    {
        Global.aiActive = true;
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.CastleScene, castle.Id);
    }
    public void Lose()
    {
        Global.aiActive = true;
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.SampleScene, castle.Id);
    }

    private void SaveCastleAndSetAppropriateTagAndLayer(bool isPlayer, string tag, string layer)
    {
        if (TrainingManager.train)
        {
            TrainingManager.secondLevelOfTrainingCastleScene = true;
            TrainingManager.nineTrainingLevelOnCastleScene = true;
        }

        castle.isPlayer = isPlayer;
        castle.tag = tag;
        castle.gameObject.layer = LayerMask.NameToLayer(layer);
        SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Soldiers"))
        {
            count++;
            countText.text = "SOLDIER INCOME : " + count;
        }
    }
}
