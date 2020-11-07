using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeOverTexts : MonoBehaviour
{
    public Text knightPlayer;
    public Text knightEnemy;
    public Text pikinierPlayer;
    public Text pikinierEnemy;
    public Text warriorPlayer;
    public Text warriorEnemy;
    public Text woodTowerPlayer;
    public Text woodTowerEnemy;
    public Text stoneTowerPlayer;
    public Text stoneTowerEnemy;
    public Text greatTowerPlayer;
    public Text greatTowerEnemy;

    // Update is called once per frame
    void Update()
    {
        knightEnemy.text = knightPlayer.text;
        pikinierEnemy.text = pikinierPlayer.text;
        warriorEnemy.text = warriorPlayer.text;

        greatTowerEnemy.text = greatTowerPlayer.text;
        stoneTowerEnemy.text = stoneTowerPlayer.text;
        woodTowerEnemy.text = woodTowerPlayer.text;
    }
}
