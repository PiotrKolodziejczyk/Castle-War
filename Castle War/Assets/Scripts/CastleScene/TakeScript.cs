using Assets.Scripts.MainScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeScript : MonoBehaviour
{
    [SerializeField]
    GameObject takePanel;
    [SerializeField]
    CastleData player;
    [SerializeField]
    Castle castle;
    [SerializeField]
    internal Text pikiniersInCastle;
    [SerializeField]
    internal Text warriorsInCastle;
    [SerializeField]
    internal Text knightsInCastle;
    [SerializeField]
    internal Text woodTowersInCastle;
    [SerializeField]
    internal Text stoneTowersInCastle;
    [SerializeField]
    internal Text greatTowersInCastle;
    [SerializeField]
    Text pikiniersInPlayer;
    [SerializeField]
    Text warriorsInPlayer;
    [SerializeField]
    Text knightsInPlayer;
    [SerializeField]
    Text woodTowersInPlayer;
    [SerializeField]
    Text stoneTowersInPlayer;
    [SerializeField]
    Text greatTowersInPlayer;
    [SerializeField]
    internal int pikinierQuantity;
    internal int warriorQuantity;
    internal int knightQuantity;
    internal int woodTowerQuantity;
    internal int stoneTowerQuantity;
    internal int greatTowerQuantity;
    [SerializeField]
    InputField castlePikemanInput;
    [SerializeField]
    InputField castleWarriorInput;
    [SerializeField]
    InputField castleKnightInput;
    [SerializeField]
    InputField castleWoodTowerInput;
    [SerializeField]
    InputField castleStoneTowerInput;
    [SerializeField]
    InputField castleGreatTowerInput;
    [SerializeField]
    InputField playerPikemanInput;
    [SerializeField]
    InputField playerWarriorInput;
    [SerializeField]
    InputField playerKnightInput;
    [SerializeField]
    InputField playerWoodTowerInput;
    [SerializeField]
    InputField playerStoneTowerInput;
    [SerializeField]
    InputField playerGreatTowerInput;
    private void Awake()
    {
        pikiniersInCastle.text = castle.pikeman.ToString();
        PlayerArmyData data = SaveSystem.LoadPlayerArmy();
        pikinierQuantity = data.pikinierQuantity;
        pikiniersInPlayer.text = pikinierQuantity.ToString();
    }
    private void Update()
    {
        
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
        pikiniersInCastle.text = (int.Parse(pikiniersInCastle.text) - int.Parse(castlePikemanInput.text)).ToString();
        pikiniersInPlayer.text= (int.Parse(pikiniersInPlayer.text) + int.Parse(castlePikemanInput.text)).ToString();
        pikinierQuantity += int.Parse(pikiniersInPlayer.text);
        SaveSystem.SavePlayerArmyData(this);
    }
}
