public class Clay : RawMaterial
{
    private void Start()
    {
        materialName = "Clay";
    }
    private void Update()
    {
        GetMaterial(materialName);
    }
}

