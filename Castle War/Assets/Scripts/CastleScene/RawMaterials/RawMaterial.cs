using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class RawMaterial : GameModule
{
    public string materialName;
    public int quantity;
    [SerializeField] internal int increaseQuantity;
    public TextMeshProUGUI text;
    public Text textInCastle;
    public float timeToCollect;
    public float firstTimeToCollect;
    public InputField input;

    private void Start()
    {
        timeToCollect = 10;
        firstTimeToCollect = 10;
    }

    public static string SeText(string name, int quantity)
    {
        return $"{name} : {quantity}";
    }

    public void GetMaterial(string name)
    {
        timeToCollect -= Time.deltaTime;
        if (timeToCollect < 0)
        {
            quantity += increaseQuantity;
            timeToCollect = firstTimeToCollect;
        }
        if (Regex.Match(transform.parent.name, @"Castle\(Clone\)\s*\(\d+\)").Success || transform.name == "Castle")
            text.text = SeText(name, quantity);

       
    }

}
