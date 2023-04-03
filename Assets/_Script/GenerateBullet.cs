using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private AudioSource ShootSound;
    private GameController gc;
    private MobileButtonShoot mbs;
    void Start()
    {
        gc = GameController.gc;
        mbs = MobileButtonShoot.mbs;

    }

    void Update()
    {
        bool mobileFire;
        if(mbs){
            mobileFire = mbs.GetFireTouch();
        }else{
            mobileFire = false;
        }
        if((Input.GetButtonDown("Fire1") || mobileFire) && gc.UseBullet() && gc.GetPlayerLife() > 0)
        {
            Shoot();
            ShootSound.Play();
            if (mbs)
            {
                mbs.SetFireTouch(false);
            }
        }

    }


    private void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }




}
