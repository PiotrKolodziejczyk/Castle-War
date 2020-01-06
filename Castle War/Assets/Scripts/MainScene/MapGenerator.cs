using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prefab;
    public float positionX = 0;
    public float positionZ = 0;
    public float changeMove;
    public float changePositionZ;
    public float changePositionX;
    public bool genX = false;


    private void Update()
    {
        if (genX)
            GenerateX();
    }

    private void GenerateX()
    {
        for (int j = 1; j < 30; j++)
        {
            for (int i = 1; i < 30; i++)
            {

                Instantiate(prefab, new Vector3(positionX, 0, positionZ), transform.rotation, transform);
                positionX += changeMove;

            }
            if (j % 2 != 0)
            {
                if (j == 1)
                {
                    positionX = changePositionX;
                    positionZ = changePositionZ;
                }
                else
                {
                    positionZ = changePositionZ * j;
                    positionX = changePositionX;
                }

            }
            else
            {
                positionX = 0;
                positionZ = changePositionZ * j;

            }
        }
        genX = false;
    }
}


