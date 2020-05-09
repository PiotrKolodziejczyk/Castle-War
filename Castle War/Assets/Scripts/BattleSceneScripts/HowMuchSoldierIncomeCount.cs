using TMPro;
using UnityEngine;

public class HowMuchSoldierIncomeCount : MonoBehaviour
{
    [SerializeField]
    private readonly TextMeshProUGUI countText;
    private int count = 0;
    private Castle castle;

    private void Awake()
    {
        castle = GetComponentInParent<Castle>();
    }
    private void Update()
    {
        if (!castle.isPlayer && count == 10)
        {
            SaveCastleAndSetAppropriateTagAndLayer(true, "PlayerCastle", "I");
            Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.CastleScene, castle.id);

        }
        else if (castle.isPlayer && count == 10)
        {
            SaveCastleAndSetAppropriateTagAndLayer(false, "Untagged", "Enemy");
            Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.SampleScene, castle.id);
        }
    }

    private void SaveCastleAndSetAppropriateTagAndLayer(bool isPlayer, string tag, string layer)
    {
        castle.isPlayer = isPlayer;
        castle.tag = tag;
        castle.gameObject.layer = LayerMask.NameToLayer(layer);
        SaveSystem.SaveCastle(castle);
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
