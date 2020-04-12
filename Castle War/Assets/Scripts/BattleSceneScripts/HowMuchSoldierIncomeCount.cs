using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowMuchSoldierIncomeCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;
    private int count = 0;
    Castle castle;

    private void Awake()
    {
        castle = GetComponentInParent<Castle>();
    }
    private void Update()
    {
        if(count == 10)
        {
            castle.isPlayer = true;
            castle.tag = "PlayerCastle";
            castle.gameObject.layer = LayerMask.NameToLayer("I");
            
            SaveSystem.SaveCastle(castle);
            Global.currentCastle = castle.id;
            Global.whichScene = "CastleScene";
            SceneManager.LoadScene("LoadingScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            count++;
            countText.text = "SOLDIER INCOME : "+ count;
        }
    }
}
