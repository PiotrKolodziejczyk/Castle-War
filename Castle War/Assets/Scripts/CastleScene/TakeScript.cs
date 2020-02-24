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
    Text pikiniersInCastle;
    [SerializeField]
    Text warriorsInCastle;
    [SerializeField]
    Text knightsInCastle;
    [SerializeField]
    Text woodTowersInCastle;
    [SerializeField]
    Text stoneTowersInCastle;
    [SerializeField]
    Text greatTowersInCastle;
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
    void Start()
    {
        
    }

    void Update()
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

        SaveSystem.SavePlayer(this);
    }
}
