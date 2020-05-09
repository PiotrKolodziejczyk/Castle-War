using Assets.Scripts.BattleSceneScripts;
using UnityEngine;
using UnityEngine.UI;

public abstract class Soldier : MonoBehaviour
{
    public int helath;
    public int armor;
    public float speed;
    public TextInputQuantity textInputQuantity;

    private void Awake()
    {
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
