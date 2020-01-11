﻿using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefabSea;
    public GameObject prefabMountain;
    public float positionX = 0;
    public float positionZ = 0;
    public float changeMove;
    public float changePositionZ;
    public float changePositionX;
    public bool genX = false;
    int X = 50;
    int Y = 50;
    

    private void Update()
    {
        if (genX)
            GenerateX();
    }

    private void GenerateX()
    {
        for (int j = 1; j < Y; j++)
        {
            for (int i = 1; i < X; i++)
            {
                if (j < 6 && j !=1)
                {
                    Instantiate(prefabSea, new Vector3(positionX, 0, positionZ), transform.rotation, transform);
                }
                else if (j > Y - 4)
                {
                    Instantiate(prefabMountain, new Vector3(positionX, 0, positionZ), transform.rotation, transform);
                }
                else if ( i > X - 7 || i < 7)
                {
                    prefab.GetComponent<SphereCollider>().enabled = false;
                    Instantiate(prefab, new Vector3(positionX, 0, positionZ), transform.rotation, transform);
                }
                else
                {
                    prefab.GetComponent<SphereCollider>().enabled = true;
                    Instantiate(prefab, new Vector3(positionX, 0, positionZ), transform.rotation, transform);
                }

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


