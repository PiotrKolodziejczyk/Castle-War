using Assets.Scripts.BattleSceneScripts;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float range;
    [SerializeField] protected int damage;
    [SerializeField] internal TextInputQuantity textInputQuantity;
    private void Awake()
    {
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
