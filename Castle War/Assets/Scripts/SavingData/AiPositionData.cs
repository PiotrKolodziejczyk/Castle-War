namespace Assets.Scripts.SavingData
{
    [System.Serializable]
    public class AiPositionData
    {
        public float x;
        public float y;
        public float z;

        public AiPositionData(AIController ai)
        {
            x = ai.transform.position.x;
            y = ai.transform.position.y;
            z = ai.transform.position.z;
        }
    }
}
