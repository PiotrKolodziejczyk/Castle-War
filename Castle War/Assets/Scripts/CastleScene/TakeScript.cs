using Assets.Scripts.CastleScene;
using Assets.Scripts.MainScene;
using UnityEngine;
using UnityEngine.UI;

public class TakeScript : MonoBehaviour
{
    [SerializeField]
    GameObject takePanel;
    [SerializeField]
    Castle castle;
    [SerializeField]
    internal Army army;
    public int pikeman;
    private void Awake()
    {
        army = GetComponent<Army>();
        InitializeInputTexts();
        LoadAndInitializeDataFromFile();
    }

    private void LoadAndInitializeDataFromFile()
    {
        PlayerArmyData data = SaveSystem.LoadPlayerArmy();
       
        army.pikemanInPlayer.quantity = data.pikemanQuantity;
        army.warriorInPlayer.quantity = data.warriorQuantity;
        army.knightInPlayer.quantity = data.knightQuantity;
        army.pikemanInPlayer.text.text = army.pikemanInPlayer.quantity.ToString();
        army.warriorInPlayer.text.text = army.warriorInPlayer.quantity.ToString();
        army.knightInPlayer.text.text = army.knightInPlayer.quantity.ToString();
        army.woodTowerInPlayer.quantity = data.woodTowerQuantity;
        army.stoneTowerInPlayer.quantity = data.stoneTowerQuantity;
        army.greatTowerInPlayer.quantity = data.greatTowerQuantity;
        army.woodTowerInPlayer.text.text = army.woodTowerInPlayer.quantity.ToString();
        army.stoneTowerInPlayer.text.text = army.stoneTowerInPlayer.quantity.ToString();
        army.greatTowerInPlayer.text.text = army.greatTowerInPlayer.quantity.ToString();
    }

    private void InitializeInputTexts()
    {
        army.pikemanInCastle.input.text = "0";
        army.warriorInCastle.input.text = "0";
        army.knightInCastle.input.text = "0";
        army.woodTowerInCastle.input.text = "0";
        army.stoneTowerInCastle.input.text = "0";
        army.greatTowerInCastle.input.text = "0";
        army.pikemanInCastle.text.text = castle.pikeman.ToString();
        army.warriorInCastle.text.text = castle.warrior.ToString();
        army.knightInCastle.text.text = castle.knight.ToString();
        army.woodTowerInCastle.text.text = castle.woodTower.ToString();
        army.stoneTowerInCastle.text.text = castle.stoneTower.ToString();
        army.greatTowerInCastle.text.text = castle.greatTower.ToString();
    }

    public void EnablePanel()
    {
        takePanel.SetActive(true);
    }
    public void ExitPanel()
    {
        takePanel.SetActive(false);
    }
    public void SwitchToPlayer()
    {
        army.pikemanInCastle.text.text = (int.Parse(army.pikemanInCastle.text.text) - int.Parse(army.pikemanInCastle.input.text)).ToString();
        army.warriorInCastle.text.text = (int.Parse(army.warriorInCastle.text.text) - int.Parse(army.warriorInCastle.input.text)).ToString();
        army.knightInCastle.text.text = (int.Parse(army.knightInCastle.text.text) - int.Parse(army.knightInCastle.input.text)).ToString();
        castle.pikeman = int.Parse(army.pikemanInCastle.text.text);
        castle.warrior = int.Parse(army.warriorInCastle.text.text);
        castle.knight = int.Parse(army.knightInCastle.text.text);
        army.pikemanInPlayer.text.text = (int.Parse(army.pikemanInPlayer.text.text) + int.Parse(army.pikemanInCastle.input.text)).ToString();
        army.warriorInPlayer.text.text = (int.Parse(army.warriorInPlayer.text.text) + int.Parse(army.warriorInCastle.input.text)).ToString();
        army.knightInPlayer.text.text = (int.Parse(army.knightInPlayer.text.text) + int.Parse(army.knightInCastle.input.text)).ToString();
        int tmpPik= int.Parse(army.pikemanInCastle.input.text);
        int tmpWar= int.Parse(army.warriorInCastle.input.text);
        int tmpKni= int.Parse(army.warriorInCastle.input.text);
        army.pikemanInPlayer.quantity += tmpPik;
        army.warriorInPlayer.quantity += tmpWar;
        army.knightInPlayer.quantity += tmpKni;

        army.woodTowerInCastle.text.text = (int.Parse(army.woodTowerInCastle.text.text) - int.Parse(army.woodTowerInCastle.input.text)).ToString();
        army.stoneTowerInCastle.text.text = (int.Parse(army.stoneTowerInCastle.text.text) - int.Parse(army.stoneTowerInCastle.input.text)).ToString();
        army.greatTowerInCastle.text.text = (int.Parse(army.greatTowerInCastle.text.text) - int.Parse(army.greatTowerInCastle.input.text)).ToString();
        castle.woodTower = int.Parse(army.woodTowerInCastle.text.text);
        castle.stoneTower = int.Parse(army.stoneTowerInCastle.text.text);
        castle.greatTower = int.Parse(army.greatTowerInCastle.text.text);
        army.woodTowerInPlayer.text.text = (int.Parse(army.woodTowerInPlayer.text.text) + int.Parse(army.woodTowerInCastle.input.text)).ToString();
        army.stoneTowerInPlayer.text.text = (int.Parse(army.stoneTowerInPlayer.text.text) + int.Parse(army.stoneTowerInCastle.input.text)).ToString();
        army.greatTowerInPlayer.text.text = (int.Parse(army.greatTowerInPlayer.text.text) + int.Parse(army.greatTowerInCastle.input.text)).ToString();

        int tmpWt = int.Parse(army.woodTowerInCastle.input.text);
        int tmpSt = int.Parse(army.stoneTowerInCastle.input.text);
        int tmpGt = int.Parse(army.greatTowerInCastle.input.text);
        army.woodTowerInPlayer.quantity += tmpWt;
        army.stoneTowerInPlayer.quantity += tmpSt;
        army.greatTowerInPlayer.quantity += tmpGt;
        SaveSystem.SavePlayerArmyData(this);
    }
}
