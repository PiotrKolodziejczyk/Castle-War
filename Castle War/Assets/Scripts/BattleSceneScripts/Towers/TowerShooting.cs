using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public Rigidbody bullet;
    Rigidbody Shoot = null;
    public List<GameObject> bulletList = new List<GameObject>();
    float time = 0;
    bool isShooting = false;
    float timetest = 0;
    float cleaner = 10;
    [SerializeField]
    AudioSource shootSound;
    private void Awake()
    {
        shootSound = GameObject.FindGameObjectWithTag("ShootSound").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isShooting)
        {
            time -= Time.deltaTime;
        }
        BulletCleaner();
    }

    private void BulletCleaner()
    {
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

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.layer == 10 && time <= 0)
        {
            if (Shoot is null) { }
            else
                bulletList.Add(Shoot.gameObject);
            time = 3;
            isShooting = true;
            transform.LookAt(other.transform);
            shootSound.Play();
            Shoot = Instantiate(bullet, transform.position, transform.rotation);
            Shoot.AddRelativeForce(Vector3.forward * 350, ForceMode.Impulse);
        }
    }
}

