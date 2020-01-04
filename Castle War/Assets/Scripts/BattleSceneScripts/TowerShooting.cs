using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject bullet;
    float nextFire = 0;
    float fireRate = 0.5f;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.gameObject.layer == 10)
        {
            
            
            
                transform.LookAt(other.transform.position);
                nextFire = Time.time + fireRate;
                var Shoot = Instantiate(bullet, transform.position, transform.rotation);
                Shoot.GetComponent<Rigidbody>().AddForce(Vector3.forward*100, ForceMode.Force);
            

        }
    }
}

