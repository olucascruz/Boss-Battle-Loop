using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBulletBoss : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private float angleBullet = 0f;
    public void Shoot(Vector3? direction = null ,Transform target = null)
    {

        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Vector3 velocity = Vector3.zero;

        if(direction != null){
            velocity = (Vector3) direction * bullet.GetComponent<Bullet>().Speed;
            velocity.y += angleBullet;
        }

        if(target != null){
            Vector3 targetDirection = (target.position - transform.position).normalized;
            velocity = targetDirection * (bullet.GetComponent<Bullet>().Speed * 0.5f);
        }

        bullet.GetComponent<Rigidbody2D>().velocity = velocity;

    }

}
