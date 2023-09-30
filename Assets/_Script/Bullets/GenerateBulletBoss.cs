using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBulletBoss : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    public void Shoot(Vector3? direction = null, Transform targetBullet = null)
    {

        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Vector3 velocity = Vector3.zero;
        float bulletSpeed = bullet.GetComponent<Bullet>().Speed;

        if(direction != null){
            velocity = (Vector3) direction * bulletSpeed;
            print($"velocity with direction: {velocity}");

        }

        if(targetBullet != null){
            Vector3 targetDirection = (targetBullet.position - transform.position).normalized;
            velocity = targetDirection * bulletSpeed * 1.2f;
            print($"velocity with target: {velocity}");

        }

        bullet.GetComponent<Rigidbody2D>().velocity = velocity;

    }

}
