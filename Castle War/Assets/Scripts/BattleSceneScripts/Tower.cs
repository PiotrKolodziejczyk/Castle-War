using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    [SerializeField]
    protected float range;
    [SerializeField]
    protected int damage;
    [SerializeField]
    internal Text text;
    [SerializeField]
    internal InputField input;
    [SerializeField]
    internal int quantity;
}
