using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public Rigidbody bullet;
    private float time = 0;
    private bool isShooting = false;
    private readonly float timetest = 0;
    public List<GameObject> bulletList = new List<GameObject>();
    float cleaner = 10;
    Rigidbody Shoot = null;
    
    private void Update()
    {
        if (isShooting)
        {         
            time -= Time.deltaTime;      
        }
        cleaner -= Time.deltaTime;
        if (cleaner <= 0)
        {
            foreach (var item in bulletList)
            {
                if (item is null)
                {
                    bulletList.Remove(item);
                }
                else
                    Destroy(item);


            }

            bulletList.Clear();
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.layer == 10 && time <= 0)
        {
            if (Shoot is null)
            {

            }
            else
                bulletList.Add(Shoot.gameObject);
            time = 1;
            isShooting = true;
            transform.LookAt(other.transform);
            Shoot = Instantiate(bullet, transform.position, transform.rotation);
            Shoot.AddRelativeForce(Vector3.forward * 350, ForceMode.Impulse);
            
        }

    }
  
}

