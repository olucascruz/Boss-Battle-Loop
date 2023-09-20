using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameController gc;

    private GameObject BossLifeSpace;

    [SerializeField] private GameObject[] positionsPoint;

    [SerializeField] private float speed;

    private Vector3 target = Vector3.zero;

    [SerializeField] GenerateBulletBoss generateBulletBoss;
    void Start()
    {
        gc = GameController.gc;
        BossLifeSpace = gc.GetBossLifeSpace();
    }


    void FixedUpdate(){
         BossLifeSpace.transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        if(target != Vector3.zero){
            transform.position = Vector2.MoveTowards(transform.position,
                                                target,
                                                speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, target) < 0.4f){
                target = Vector3.zero;
            }
        }
    }

    public Vector3 GetPositionPoint(string s){

        Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();

        foreach (GameObject positionPoint in positionsPoint)
        {
            positions[positionPoint.name] = positionPoint.transform.position;
        }

        return positions[s];
    }

    public void SetTarget(Vector3 position){
        target = position;
    }


    protected IEnumerator LoopShoot(float speed, string direction){
        Dictionary<string, Vector3> dir = new Dictionary<string, Vector3>();
        dir["up"] = Vector3.up;
        dir["down"] = Vector3.down;
        dir["left"] = Vector3.left;
        dir["right"] = Vector3.right;

        if (!dir.Keys.Contains(direction)){
            Debug.Log("Erro LoopShoot: Direction Error");
            yield break;
        }


        while(true){
            yield return new WaitForSeconds(speed);
            generateBulletBoss.Shoot();
        }
    }



    private void CheckDeath(){
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
