public class Wood : RawMaterial
{
    private void Start()
    {
        materialName = "Wood";
    }

    private void Update()
    {
        GetMaterial(materialName);
    }
}

