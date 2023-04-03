using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameController gc;

    private GameObject BossLifeSpace;

    [SerializeField]
    private Transform[] positionsPoint;
    [SerializeField]
    private float speed;

    private Transform Target = null;
    void Start()
    {
        gc = GameController.gc;
        BossLifeSpace = gc.GetBossLifeSpace();
        Invoke("Move1", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void FixedUpdate(){
         BossLifeSpace.transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        if(Target != null){
        transform.position = Vector2.MoveTowards(transform.position,
                                                Target.position,
                                                speed * Time.deltaTime);
        }
    }

    private void Move1(){

        Target = positionsPoint[0];
        Invoke("Move2", 2f);

    }
    private void Move2()
    {

        Target = positionsPoint[1];
        Invoke("Move3", 2f);
    }
    private void Move3()
    {

        Target = positionsPoint[2];
        Invoke("Move4", 2f);
    }
    private void Move4()
    {

        Target = positionsPoint[3];
        Invoke("Move1", 2f);
    }

    private void Death(){
        if (gc.GetBossLife() <= 0 || gc.GetPlayerLife() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gc.BossLoseLife();
            Destroy(collision.gameObject);
        }
    }


}
