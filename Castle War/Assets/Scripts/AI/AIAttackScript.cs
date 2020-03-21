using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIAttackScript : MonoBehaviour
{
    public int CastleIdAttack;

   
    public void SimulateAttack()
    {
        Global.currentCastle = CastleIdAttack;
        Global.whichScene = "CastleScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
