using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBulletBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    public void Shoot(Vector3? direction = null ,Transform target = null)
    {

       GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);

        if(target == null) return;
        if(direction == null) return;

        Vector3 target_direction = (target.position - transform.position).normalized;
        Vector3 velocity = target_direction * bullet.GetComponent<Bullet>().Speed;
        bullet.GetComponent<Rigidbody2D>().velocity = velocity;


    }
}
