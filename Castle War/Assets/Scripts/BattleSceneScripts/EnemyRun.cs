﻿using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    private float forward;
    private float forwardMinus;
    private float cur;
    private float curMinus;
    public GameObject Knight;
    public GameObject Pikeman;
    public GameObject Axeman;

    private void Start()
    {
        switch (transform.tag)
        {
            case "Knight":
                {
                    forward = 0.3f;
                    return;
                }
            case "Pikeman":
                {
                    forward = 0.5f;
                    return;
                }
            case "Axeman":
                {
                    forward = 0.7f;
                    return;
                }
        }
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (cur + curMinus * Time.deltaTime), 0, transform.position.z + (forward + forwardMinus * Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ChangeFor")
        {
            forward = 0.1f;
            forwardMinus = 0;
            cur = 0;
            curMinus = 0;
        }
        if (other.name == "ChangeCur")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0.1f;
            curMinus = 0;
        }
        if (other.name == "ChangeCurMinus")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0;
            curMinus = -6f;
        }
        if (other.name == "ChangeForMinus")
        {
            forward = 0;
            forwardMinus = -3f;
            cur = 0;
            curMinus = 0;


        }
    }
    public void InstantiateKnight()
    {
        Instantiate(Knight, new Vector3(-30.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));

    }
    public void InstantiatePikeman()
    {
        Instantiate(Pikeman, new Vector3(-20.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));

    }
    public void InstantiateAxeman()
    {
        Instantiate(Axeman, new Vector3(-10.8f, 0.1402141f, -439f), new Quaternion(0, 0, 0, 0));

    }






}

