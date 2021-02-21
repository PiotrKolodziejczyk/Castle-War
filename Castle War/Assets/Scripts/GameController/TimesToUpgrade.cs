namespace Assets.Scripts.GameController
{
    public static class TimesToUpgrade
    {
        public static int GetTime(string building)
        {
            switch (building.ToLower())
            {
                case "townhall":
                    return 12;
                case "barrack":
                    return 8;
                case "towerworkshop":
                    return 10;
                case "sawmill":
                    return 10;
                case "wall":
                    return 10;
                case "quarry":
                    return 10;
                case "claymine":
                    return 10;
                case "smithy":
                    return 18;
                case "pikeman":
                    return 5;
                case "warrior":
                    return 8;
                case "knight":
                    return 15;
                case "woodtower":
                    return 10;
                case "stonetower":
                    return 12;
                case "greattower":
                    return 18;
            }
            return 11;
        }
    }
}
