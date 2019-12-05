using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    public float forward =0;
    public float forwardMinus;
    public float cur;
    public float curMinus;
    public GameObject en;
    void Start()
    {
      
    }

   
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (cur+curMinus*Time.deltaTime), 0, transform.position.z + (forward+forwardMinus*Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ChangeFor")
        {
            forward = 0.5f;
            forwardMinus = 0;
            cur = 0;
            curMinus = 0;
        }
        if (other.name == "ChangeCur")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0.5f;
            curMinus = 0;
        }
        if (other.name == "ChangeCurMinus")
        {
            forward = 0;
            forwardMinus = 0;
            cur = 0;
            curMinus = -1f;
        }
        if (other.name == "ChangeForMinus")
        {
            forward = 0;
            forwardMinus = -1f;
            cur = 0;
            curMinus = 0;
            

        }
    }
    public void enemy()
    {
        Instantiate(en, new Vector3(-4.59f, 0.1402141f, -44.38f), new Quaternion(0, 0, 0, 0));
        
    }
    private void OnMouseDown()
    {
        forward = 1;
    }





}

