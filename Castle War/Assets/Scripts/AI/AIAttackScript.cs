using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIAttackScript : MonoBehaviour
{
    public int CastleIdAttack;

    public static void SimulateAttack(int castle)
    {
        Global.currentCastle = castle;
        Global.whichScene = "BattleScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
