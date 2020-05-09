using UnityEngine;

public class CastleManager : MonoBehaviour
{
    private Castle castle;
    private bool isPlayerHere;

    private void Awake()
    {
        castle = GetComponent<Castle>();
    }

    private void OnMouseDown()
    {
        if (isPlayerHere && castle.isPlayer)
            Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.CastleScene, castle.id);
        else if (isPlayerHere && !castle.isPlayer)
            Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.BattleScene, castle.id);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            isPlayerHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            isPlayerHere = false;
    }

}
