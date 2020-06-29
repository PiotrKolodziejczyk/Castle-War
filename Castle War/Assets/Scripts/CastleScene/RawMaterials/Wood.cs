using UnityEngine.SceneManagement;

public class Wood : RawMaterial
{
    private Sawmill sawmill;
    private float timeToCheckLevel = 1;
    //private void Awake()
    //{
    //    sawmill = GetComponentInChildren<Sawmill>();
    //}
    //private void Start()
    //{
    //    materialName = "Wood";
    //}
    public override void Initialize()
    {
        //sawmill = transform.parent.transform.parent.GetComponentInChildren<Sawmill>();
        sawmill = transform.GetComponentInChildren<Sawmill>();
        materialName = "Wood";
    }

    private void Update()
    {
        if (transform.parent.name != "Player" && transform.parent.name != "Materials")
        {
            increaseQuantity = 100 * sawmill.level;
            GetMaterial(materialName);
        }
        if (SceneManager.GetActiveScene().name == "CastleScene")
            textInCastle.text = quantity.ToString();
        if (text!=null&&SceneManager.GetActiveScene().name == "SampleScene")
            text.text = quantity.ToString();

    }
}

