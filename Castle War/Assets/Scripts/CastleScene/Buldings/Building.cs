using Assets.Scripts.Buldings;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField]
    protected int level;
    [SerializeField]
    Button exitButton;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Button buildButton;
    [SerializeField]
    protected bool isBuild;
    [SerializeField]
    protected float timeToUpgrade;
    [SerializeField]
    protected float startTimeToUpgrade;
  
    public void ExitPanel()
    {
        panel.SetActive(false);
        buildButton.onClick.RemoveAllListeners();
    }

    public void Build(Transform transform)
    {
        switch (transform.name)
        {
            case "Barrack":
                Barrack component = transform.GetComponent<Barrack>();
                component.isBuild = true;
                break;
            case "ClayMine":
                ClayMine claymine = transform.GetComponent<ClayMine>();
                claymine.isBuild = true;
                break;
            case "Quarry":
                transform.GetComponent<Quarry>().level++;
                break;
            case "Sawmill":
                transform.GetComponent<Sawmill>().level++;
                break;
            case "Smithy":
                transform.GetComponent<Smithy>().level++;
                break;
            case "TowerWorkshop":
                transform.GetComponent<TowerWorkShop>().level++;
                break;
            case "Wall":
                transform.GetComponent<Wall>().level++;
                break;
            case "TownHall":
                transform.GetComponent<TownHall>().level++;
                break;
        }
    }
   public void Timer(Building barrack)
    {
        if (barrack.isBuild)
        {
            barrack.timeToUpgrade -= Time.deltaTime;
            if (barrack.timeToUpgrade < 0)
            {
                barrack.level++;
                barrack.timeToUpgrade = barrack.startTimeToUpgrade;
                barrack.isBuild = false;
            }
        }
    }

    private void OnMouseDown()
    {
        buildButton.onClick.AddListener(() => Build(transform));
        panel.SetActive(true);
    }

}


