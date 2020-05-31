public class Stone : RawMaterial
{
    private Quarry quarryMine;
    private float timeToCheckLevel = 5;
    private void Awake()
    {
        quarryMine = GetComponentInChildren<Quarry>();
    }
    private void Start()
    {
        materialName = "Stone";
    }

    private void Update()
    {
        if (Global.Timer(ref timeToCheckLevel))
        {
            increaseQuantity = 100 * quarryMine.level;
            timeToCheckLevel = 5;
        }
        GetMaterial(materialName);
    }
}

