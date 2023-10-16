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
    private GameController gameController;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }

    }
    void Start()
    {
        gameController = GameController.gc;
    }


    public void ShootPlayerSoundPlay(){
        ShootPlayerSound.Play();
    }
    public void AttackBossSoundPlay(AudioSource audio){
        if(gameController.GameState == GameState.PLAY){
            audio.Play();
        }
    }


}
