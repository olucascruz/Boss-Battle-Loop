using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private GameObject BossLifeSpace;

    [SerializeField] private GameObject[] positionsPoint;

    [SerializeField] private float speed;

    private Vector3 target = Vector3.zero;

    [SerializeField] GenerateBulletBoss generateBulletBoss;


    protected Vector3 leftUp;
    protected Vector3 rightUp;
    protected Vector3 leftDown;
    protected Vector3 rightDown;

    private List<Vector3> listTarget = new List<Vector3>();
    private Dictionary<string, Vector3> dir = new Dictionary<string, Vector3>();
    private GameObject playerTarget;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start(){
        dir["up"] = Vector3.up;
        dir["down"] = Vector3.down;
        dir["left"] = Vector3.left;
        dir["right"] = Vector3.right;
        dir["all"] = Vector3.zero;
        dir["diagonal"] = Vector3.zero;
        leftUp = GetPositionPoint("LeftUp");
        rightUp = GetPositionPoint("RightUp");
        leftDown = GetPositionPoint("RightDown");
        rightDown = GetPositionPoint("RightDown");
        playerTarget = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        StartCoroutine(Behavior());
    }

    protected abstract IEnumerator Behavior();

    void FixedUpdate(){
         gameController.GetBossLifeSpace().transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        if(target != Vector3.zero){
            transform.position = Vector2.MoveTowards(transform.position,
                                                target,
                                                speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, target) < 0.3f){
                target = Vector3.zero;
                listTarget.RemoveAt(0);
                if(listTarget.Count >= 1){
                    target = listTarget[0];
                }
            }
        }
    }

    protected Vector3 GetPositionPoint(string s){

        Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();

        foreach (GameObject positionPoint in positionsPoint)
        {
            positions[positionPoint.name] = positionPoint.transform.position;
        }

        return positions[s];
    }

    protected void SetTargetToMove(Vector3 position){
        if (listTarget.Count < 10){
            listTarget.Add(position);
        }
        if(listTarget.Count == 1){
            target = listTarget[0];
        }
    }

    protected IEnumerator LoopShootWithTargetPlayer(float speed){
        while(true){
            yield return new WaitForSeconds(speed);
            Transform vectorTarget = playerTarget.transform;
            generateBulletBoss.Shoot(null, vectorTarget);
        }
    }



    protected IEnumerator LoopShoot(float speed, string direction){

        if (!dir.ContainsKey(direction)){
            Debug.Log("Erro LoopShoot: Direction Error");
            yield break;
        }


        if(direction == "all"){
            while(true){
                yield return new WaitForSeconds(speed);

                generateBulletBoss.Shoot(dir["up"]);
                generateBulletBoss.Shoot(dir["down"]);
                generateBulletBoss.Shoot(dir["left"]);
                generateBulletBoss.Shoot(dir["right"]);
            }
        }else if(direction == "diagonal"){
            while(true){
                yield return new WaitForSeconds(speed);
                generateBulletBoss.Shoot((dir["up"] + dir["left"]).normalized);
                generateBulletBoss.Shoot((dir["up"] + dir["right"]).normalized);
                generateBulletBoss.Shoot((dir["down"] + dir["left"]).normalized);
                generateBulletBoss.Shoot((dir["down"] + dir["right"]).normalized);
            }
        }else{
            while(true){
                yield return new WaitForSeconds(speed);
                generateBulletBoss.Shoot(dir[direction]);
            }
        }
    }

    protected void CheckDeath(){
        if (gameController.GetBossLife() <= 0 || gameController.GetPlayerLife() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameController.BossLoseLife();
            StartCoroutine(DamageColor());
            CheckDeath();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DamageColor(){
        Color colorDamage = new Color(0.8f, 0.25f, 0.25f);
        spriteRenderer.color = colorDamage;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = originalColor;
    }
}
