public class Clay : RawMaterial
{
    private ClayMine clayMine;
    private float timeToCheckLevel = 5;
    private void Awake()
    {
        clayMine = GetComponentInChildren<ClayMine>();
    }
    private void Start()
    {
        materialName = "Clay";
    }
    private void Update()
    {
        if (Global.Timer(ref timeToCheckLevel))
        {
            increaseQuantity = 100 * clayMine.level;
            timeToCheckLevel = 5;
        }
        GetMaterial(materialName);
    }
}

