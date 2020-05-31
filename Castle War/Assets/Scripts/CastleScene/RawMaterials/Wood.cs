public class Wood : RawMaterial
{
    private Sawmill sawmill;
    private float timeToCheckLevel = 5;
    private void Awake()
    {
        sawmill = GetComponentInChildren<Sawmill>();
    }
    private void Start()
    {
        materialName = "Wood";
    }

    private void Update()
    {
        if (Global.Timer(ref timeToCheckLevel))
        {
            increaseQuantity = 100 * sawmill.level;
            timeToCheckLevel = 5;
        }
        GetMaterial(materialName);
    }
}

