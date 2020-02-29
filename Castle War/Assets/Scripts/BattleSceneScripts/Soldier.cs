using UnityEngine;
using UnityEngine.UI;

public abstract class Soldier : MonoBehaviour
{
    public int helath;
    public int armor;
    public float speed;
    [SerializeField]
    internal Text text;
    [SerializeField]
    internal InputField input;
    [SerializeField]
    internal int quantity;
}
