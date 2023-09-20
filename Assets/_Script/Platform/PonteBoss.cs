using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject ponte;
    [SerializeField]

    private GameObject BarreiraBoss;
    [SerializeField]
    private GameObject BarreiraEnemy;


    private GameController gc;
    void Start()
    {
        gc = GameController.gc;

    }
    void Update()
    {
        if(gc.GetBossLife() <= 0){
            BarreiraEnemy.SetActive(false);
            BarreiraBoss.SetActive(false);
            ponte.SetActive(true);
        }
    }
}
