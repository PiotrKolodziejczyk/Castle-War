using UnityEngine.SceneManagement;

public class Stone : RawMaterial
{
    private Quarry quarryMine;
    //private void Awake()
    //{
    //    quarryMine = GetComponentInChildren<Quarry>();
    //}
    //private void Start()
    //{
    //    materialName = "Stone";
    //}
    public override void Initialize()
    {
        //quarryMine = transform.parent.transform.parent.GetComponentInChildren<Quarry>();
        quarryMine = transform.GetComponentInChildren<Quarry>();
        materialName = "Stone";
    }

    private void Update()
    {
        if (transform.parent.name != "Player" && transform.parent.name != "Materials")
        {
            increaseQuantity = 100 * quarryMine.level;
            GetMaterial(materialName);
        }
        if (SceneManager.GetActiveScene().name == "CastleScene")
            textInCastle.text = quantity.ToString();
        if (text != null && SceneManager.GetActiveScene().name == "SampleScene")
            text.text = quantity.ToString();
    }
}

