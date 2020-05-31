using Assets.Scripts.BattleSceneScripts;
using Assets.Scripts.CastleScene.Buldings;
using UnityEngine;
using UnityEngine.UI;

public abstract class Soldier : MonoBehaviour
{
    public int helath;
    public int armor;
    public float speed;
    public TextInputQuantity textInputQuantity;
    public ResourcesToUpgradeLvl resources;

    private void Awake()
    {
        textInputQuantity = GetComponent<TextInputQuantity>();
    }
}
