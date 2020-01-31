namespace Assets.Scripts
{
    public class Stone : RawMaterial
    {
        private void Start()
        {
            name = "Stone";
        }

        private void Update()
        {
            GetMaterial(name);
        }

    }
}
