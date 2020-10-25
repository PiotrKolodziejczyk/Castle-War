using Assets.Scripts.HelpingClass;
using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

public class VillageScript : MonoBehaviour, IMaterials
{
    public GameObject menu;
    public GameObject stealPanel;
    public UnitManager player;
    private int wood;
    private int stone;
    private int clay;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI clayText;
    private float lastTimeSteal = 120;
    private bool lastTimeStealBool = true;
    public Texture2D cursorVilage;
    public Texture2D cursorNormal;

    public Materials Materials { get => player.materials; set => player.materials = value; }

    private void OnMouseDown()
    {
        menu.SetActive(true);
        Global.active = false;
    }
    public void ExitMenu()
    {
        menu.SetActive(false);
        Global.active = true;
    }
    public void ExitStealPanel()
    {
        stealPanel.SetActive(false);
        menu.SetActive(false);
        Global.active = true;
    }
    private void Update()
    {
        if (!Global.PAUSE)
            if (!lastTimeStealBool)
                if (Global.Timer(ref lastTimeSteal))
                {
                    lastTimeStealBool = true;
                    lastTimeSteal = 120;
                }
    }
    public void CalculateSteal()
    {
        if (lastTimeStealBool)
        {
            wood = (player.army.pikeman.textInputQuantity.quantity + player.army.warrior.textInputQuantity.quantity + player.army.knight.textInputQuantity.quantity) * Random.Range(0, 10);
            stone = (player.army.pikeman.textInputQuantity.quantity + player.army.warrior.textInputQuantity.quantity + player.army.knight.textInputQuantity.quantity) * Random.Range(0, 10);
            clay = (player.army.pikeman.textInputQuantity.quantity + player.army.warrior.textInputQuantity.quantity + player.army.knight.textInputQuantity.quantity) * Random.Range(0, 10);
            player.materials.wood.quantity += wood;
            player.materials.stone.quantity += stone;
            player.materials.clay.quantity += clay;
            woodText.text = wood.ToString();
            stoneText.text = stone.ToString();
            clayText.text = clay.ToString();
            stealPanel.SetActive(true);
            SaveSystem.SavePlayerMaterialsData(this, Global.globalInitializingClass.currentSavePlayerMaterials);
            lastTimeStealBool = false;
        }
        else
        {
            woodText.text = "0";
            stoneText.text = "0";
            clayText.text = "0";
            stealPanel.SetActive(true);
        }
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorVilage, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.ForceSoftware);

    }
}
