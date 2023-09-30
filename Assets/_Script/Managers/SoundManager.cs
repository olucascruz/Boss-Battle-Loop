using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource ShootPlayerSound;
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get{return instance;}
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }

    }

    public void ShootPlayerSoundPlay(){
        ShootPlayerSound.Play();
    }
    public void AttackBossSoundPlay(AudioSource audio){
        audio.Play();
    }


}
