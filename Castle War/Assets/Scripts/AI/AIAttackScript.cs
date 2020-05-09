using UnityEngine;
using UnityEngine.SceneManagement;

public class AIAttackScript : MonoBehaviour
{
    public int CastleIdAttack;

    public static void SimulateAttack(int castle)
    {
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.BattleScene, castle);
    }
}
