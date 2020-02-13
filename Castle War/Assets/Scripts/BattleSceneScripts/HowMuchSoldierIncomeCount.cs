using TMPro;
using UnityEngine;

public class HowMuchSoldierIncomeCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            count++;
            countText.text = "SOLDIER INCOME : "+ count;
        }
    }
}
