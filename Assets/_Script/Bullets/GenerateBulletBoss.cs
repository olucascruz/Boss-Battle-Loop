using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBulletBoss : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private SoundManager soundManager;
    [SerializeField] private AudioSource bossBulletSound;

    void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public void Shoot(Vector3? direction = null, Transform targetBullet = null, float speed = 0f)
    {

        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Vector3 velocity = Vector3.zero;

        if(soundManager && bossBulletSound){
            soundManager.AttackBossSoundPlay(bossBulletSound);
        }

        float bulletSpeed = bullet.GetComponent<Bullet>().Speed;
        if(speed != 0f){
            bulletSpeed = speed;
        }

        if(direction != null){
            velocity = (Vector3) direction * bulletSpeed;
        }

        if(targetBullet != null){
            Vector3 targetDirection = (targetBullet.position - transform.position).normalized;
            velocity = targetDirection * bulletSpeed * 1.2f;

        }

        bullet.GetComponent<Rigidbody2D>().velocity = velocity;

    }

}
