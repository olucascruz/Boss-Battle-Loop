using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSphere : MonoBehaviour
{

    private GenerateBulletBoss generateBulletBoss;
    private Vector3 target = Vector3.zero;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        generateBulletBoss = GetComponent<GenerateBulletBoss>();
        StartCoroutine(DarkShoot());
        Destroy(gameObject, 5f);
    }



    private IEnumerator DarkShoot(){
        while(true){
            yield return new WaitForSeconds(.50f);
            generateBulletBoss.Shoot(Vector3.up);
            generateBulletBoss.Shoot(Vector3.down);
            generateBulletBoss.Shoot(Vector3.left);
            generateBulletBoss.Shoot(Vector3.right);
        }
    }

    void FixedUpdate()
    {
        if(target != Vector3.zero){
            Vector3 targetDirection = (target - transform.position).normalized;
            Vector3 velocity = targetDirection * 2;

            rb.velocity = velocity;


            if(Vector3.Distance(target, transform.position) < 0.5f){
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void SetTarget(Vector3 t){
        target = t;
    }
}
