using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBulletBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private float SpeedShoot;

    [SerializeField]
    private AudioSource ShootSound;

    void Start()
    {
        InvokeRepeating("Shoot", 3f, SpeedShoot);
    }

    private void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        ShootSound.Play();
    }
}
