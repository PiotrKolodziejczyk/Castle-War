namespace Assets.Scripts
{
    public class Wood : RawMaterial
    {
        private void Start()
        {
            name = "Wood";
        }

        private void Update()
        {
            GetMaterial(name);
        }

    }
}
