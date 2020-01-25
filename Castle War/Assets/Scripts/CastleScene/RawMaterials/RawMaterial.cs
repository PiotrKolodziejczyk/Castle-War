using TMPro;
using UnityEngine;

public abstract class RawMaterial : MonoBehaviour
{
    public int quantity;

    public TextMeshProUGUI text;

    public static string SeText(string name, int quantity)
    {
        return $"{name} : {quantity}";
    }
}
