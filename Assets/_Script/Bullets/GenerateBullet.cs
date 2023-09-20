using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    private GameController gc;
    private MobileButtonShoot mbs;
    private SoundManager soundManager;
    void Start()
    {
        gc = GameController.gc;
        mbs = MobileButtonShoot.mbs;
        soundManager = SoundManager.Instance;
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
            if (mbs)
            {
                mbs.SetFireTouch(false);
            }
        }

    }


    private void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        if(soundManager){
            soundManager.ShootPlayerSoundPlay();
        }else{
            print("Sound manager not found");
        }
    }




}
