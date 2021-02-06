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
        soldiersToWin = (castle.Army.pikeman.textInputQuantity.quantity * 2 + castle.Army.warrior.textInputQuantity.quantity * 4 + castle.Army.knight.textInputQuantity.quantity * 8);
        if (soldiersToWin < 30)
            soldiersToWin = 30;
        toWinText.text = soldiersToWin.ToString();
    }

    private void Update()
    {
        if (!Global.PAUSE)
        {
            if (!castle.isPlayer && count >= soldiersToWin && !LosePanel.activeSelf)
                PlayerWin();
            if (castle.isPlayer && count >= soldiersToWin && !WinPanel.activeSelf)
                EnemyWin();
        }
    }
    public void PlayerWin()
    {
        SaveCastleAndSetAppropriateTagAndLayer(true, "PlayerCastle", "I");
        WinPanel.SetActive(true);
        Global.aiActive = false;
    }
    public void EnemyWin()
    {
        SaveCastleAndSetAppropriateTagAndLayer(false, "Untagged", "Enemy");
        LosePanel.SetActive(true);
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
        castle.isPlayer = isPlayer;
        castle.tag = tag;
        castle.gameObject.layer = LayerMask.NameToLayer(layer);
        SaveSystem.SaveCastle(castle, Global.globalInitializingClass.currentSaveCastleSave);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pikeman"))
        {
            count++;
            countText.text = "SOLDIER INCOME : " + count;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Warrior"))
        {
            count += 2;
            countText.text = "SOLDIER INCOME : " + count;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Knight"))
        {
            count += 4;
            countText.text = "SOLDIER INCOME : " + count;
        }
    }
}
