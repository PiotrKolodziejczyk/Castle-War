using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleManager : GameModule
{
    private Castle castle;
    private bool isPlayerHere;
    public TextMeshPro nick;
    private GameObject menuPlayerCastle;
    private GameObject menuEnemyCastle;
    private GameObject inputToChangeName;
    private TMP_InputField input;
    public GameObject prefab;
    public GameObject prefabEnemy;
    private Button toCastle;
    private Button buttonChangeCastleName;
    private Button toMap;
    private Button apply;
    private void Awake()
    {
        castle = GetComponent<Castle>();
        if (castle.nick == null)
        {
            nick.text = "Castle";
        }
    }
    private void OnMouseDown()
    {
        if (!Global.PAUSE)
        {
            if ((menuPlayerCastle == null || menuPlayerCastle.activeSelf == false) && castle.isPlayer && !Global.isAttackEnemy)
            {
                CreateCastleMiniMenuForPlayer();
            }

            if ((menuEnemyCastle == null || menuEnemyCastle.activeSelf == false) && !castle.isPlayer && !Global.isAttackEnemy)
            {
                menuEnemyCastle = Instantiate(prefabEnemy, transform);
                menuEnemyCastle.SetActive(true);
                Global.active = false;
                toMap = menuEnemyCastle.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonToMap").First();
                toMap.onClick.AddListener(() => { ToMapFromEnemy(); });
                toCastle = menuEnemyCastle.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonToCastle").First();
                toCastle.onClick.AddListener(() => { GoToBattle(); });
            }
        }

        //if (isPlayerHere && castle.isPlayer)
        //    Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.CastleScene, castle.id);
        //else if (isPlayerHere && !castle.isPlayer)
        //    Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.BattleScene, castle.id);
    }

    private void CreateCastleMiniMenuForPlayer()
    {
        menuPlayerCastle = Instantiate(prefab, transform);
        menuPlayerCastle.SetActive(true);
        Global.active = false;
        toMap = menuPlayerCastle.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonToMap").First();
        toMap.onClick.AddListener(() => { ToMapFromPlayer(); });
        toCastle = menuPlayerCastle.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonToCastle").First();
        toCastle.onClick.AddListener(() => { GoToCastle(); });
        inputToChangeName = menuPlayerCastle.GetComponentsInChildren<Transform>().Where(x => x.name == "InputToChange").First().gameObject;
        buttonChangeCastleName = menuPlayerCastle.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonChangeCastleName").First();
        buttonChangeCastleName.onClick.AddListener(() => { OnInputChangeName(); });
        apply = inputToChangeName.GetComponentsInChildren<Button>().Where(x => x.transform.name == "ButtonApply").First();
        apply.onClick.AddListener(() => { ChangeName(); });
        input = inputToChangeName.GetComponentsInChildren<TMP_InputField>().Where(x => x.transform.name == "ToChangeName").First();
        inputToChangeName.SetActive(false);
        nick = GetComponentsInChildren<TextMeshPro>().Where(x => x.transform.name == "nick").First();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerHere = false;
        }
    }
    public void GoToCastle()
    {
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.CastleScene, castle.Id);
    }
    public void GoToBattle()
    {
        Global.LoadAppropriateSceneTroughtTheLoadingScene(Scenes.BattleScene, castle.Id);
    }
    public void OnInputChangeName()
    {
        inputToChangeName.SetActive(true);
    }
    public void ChangeName()
    {
        nick.text = input.text;
        inputToChangeName.SetActive(false);
    }
    public void ToMapFromEnemy()
    {
        menuEnemyCastle.SetActive(false);
        Global.active = true;
    }
    public void ToMapFromPlayer()
    {
        menuPlayerCastle.SetActive(false);
        Global.active = true;
    }

}
