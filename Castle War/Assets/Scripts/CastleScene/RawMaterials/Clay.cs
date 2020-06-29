using UnityEngine.SceneManagement;

public class Clay : RawMaterial
{
    private ClayMine clayMine;
    //private void Awake()
    //{
    //    clayMine = GetComponentInChildren<ClayMine>();
    //}
    public override void Initialize()
    {
        //clayMine =transform.parent.transform.parent.GetComponentInChildren<ClayMine>();
        clayMine = transform.GetComponentInChildren<ClayMine>();
        materialName = "Clay";
    }
    //private void Start()
    //{
    //    materialName = "Clay";
    //}
    private void Update()
    {
        if (transform.parent.name != "Player" && transform.parent.name != "Materials")
        {
            increaseQuantity = 100 * clayMine.level;
            GetMaterial(materialName);
        }
        if (SceneManager.GetActiveScene().name == "CastleScene")
            textInCastle.text = quantity.ToString();
        if (text != null && SceneManager.GetActiveScene().name == "SampleScene")
            text.text = quantity.ToString();
    }
}

