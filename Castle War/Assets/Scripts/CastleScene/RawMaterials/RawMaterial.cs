using System;
using TMPro;
using UnityEngine;

public abstract class RawMaterial : MonoBehaviour
{
    public string name;
    public int quantity;
    public int increaseQuantity;
    public TextMeshProUGUI text;
    public float timeToCollect;
    public float firstTimeToCollect;

    public static string SeText(string name, int quantity)
    {
        return $"{name} : {quantity}";
    }

    public void GetMaterial(string name)
    {
        timeToCollect -= Time.deltaTime;
        if (timeToCollect < 0)
        {
            this.quantity += this.increaseQuantity;
            text.text = SeText(name, this.quantity);
            timeToCollect = firstTimeToCollect;
        }
    }
    
}
