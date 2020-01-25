using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 position;

    private void Start()
    {
        position = transform.position;
    }
}
