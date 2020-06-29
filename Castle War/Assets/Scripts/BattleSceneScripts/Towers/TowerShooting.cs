using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : GameModule
{
    public Rigidbody bullet;
    private Rigidbody Shoot = null;
    public List<GameObject> bulletList = new List<GameObject>();
    private float time = 0;
    private bool isShooting = false;
    private float timetest = 0;
    private float cleaner = 10;
    private int limit = 3;
    [SerializeField]
    private AudioSource shootSound;
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
            limit--;
            if (limit < 0)
            {
                GameObject.Destroy(transform.parent.gameObject);
            }
        }
    }
}

