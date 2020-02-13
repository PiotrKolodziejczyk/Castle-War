public class Stone : RawMaterial
{
    private void Start()
    {
        materialName = "Stone";
    }

    private void Update()
    {
        GetMaterial(materialName);
    }
}

