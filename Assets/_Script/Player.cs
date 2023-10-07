using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] GeneratorBullet;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;
    private string Direction;
    private GameController gc;
    private bool isSlow = false;
    private bool isInIceDamageDelay = false;
    private SpriteRenderer spriteRenderer;
    private Color origianlColor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        origianlColor = spriteRenderer.color;
        Direction = "Up";
        gc = GameController.gc;
    }


    void Update()
    {
        if (!Application.isMobilePlatform)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.x > 0){
            Direction = "Right";
        }
        else if(movement.x < 0){
            Direction = "Left";
        }
        else if(movement.y < 0){
            Direction = "Down";
        }
        else if (movement.y > 0 && movement.x == 0){
            Direction = "Up";
        }

        DirectionShoot(Direction);
    }

    void FixedUpdate()
    {
        Vector2 movementDirection = new Vector2(movement.x, movement.y).normalized;
        rb.velocity = movementDirection * moveSpeed;
    }

    public void MoveMobile(string dir){
        switch (dir)
        {
            case "UP":
                movement = new Vector2(0f, 1f);
                break;
            case "DOWN":
                movement = new Vector2(0f, -1f); ;
                break;
            case "RIGHT":
                movement = new Vector2(1f, 0f); ;
                break;
            case "LEFT":
                movement = new Vector2(-1f, 0f); ;
                break;

            case "0":
                movement = new Vector2(0f, 0f); ;
                break;

            default:
                movement.x = 0f;
                movement.y = 0f;
                break;
        }
    }

    private IEnumerator SlowEffect(float duration){
        isSlow = true;
        float originalMoveSpeed = moveSpeed;

        moveSpeed = moveSpeed / 2f;

        Color frozenColor = new Color(0f, 1f, 1f);
        spriteRenderer.color = frozenColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = origianlColor;


        moveSpeed = originalMoveSpeed;
        isSlow = false;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "EnemyBullet")
        {
            gc.PLayerLoseLife();
            StartCoroutine(DamageColor());
        }
        else if (other.gameObject.tag == "EnemyBulletIce")
        {
            if(!isSlow) StartCoroutine(SlowEffect(3f));
        }
        else if (other.gameObject.tag == "IceSpike"){

            if(!isInIceDamageDelay){
                StartCoroutine(DelayIceDamage(3f));
                gc.PLayerLoseLife();
                StartCoroutine(DamageColor());
            }
        }
    }

    private IEnumerator DamageColor(){
        Color colorDamage =new Color(1f, 0.2f, 0.18f);
        spriteRenderer.color = colorDamage;
        yield return new WaitForSeconds(1f);
        if(!isSlow){
            spriteRenderer.color = origianlColor;
        }
    }

    private IEnumerator DelayIceDamage(float duration){
        isInIceDamageDelay = true;
        yield return new WaitForSeconds(duration);
        isInIceDamageDelay = false;
    }


    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Ponte")
        {
            this.transform.parent = null;
        }
    }


    private void DirectionShoot(string direction){
        switch (direction)
        {
            case "Up":
                anim.SetInteger("dir", 0);
                GeneratorBullet[0].SetActive(true);
                GeneratorBullet[1].SetActive(false);
                GeneratorBullet[2].SetActive(false);
                GeneratorBullet[3].SetActive(false);


                break;
            case "Down":
                anim.SetInteger("dir", 1);
                GeneratorBullet[0].SetActive(false);
                GeneratorBullet[1].SetActive(true);
                GeneratorBullet[2].SetActive(false);
                GeneratorBullet[3].SetActive(false);

                break;
            case "Right":
                anim.SetInteger("dir", 2);
                GeneratorBullet[0].SetActive(false);
                GeneratorBullet[1].SetActive(false);
                GeneratorBullet[2].SetActive(false);
                GeneratorBullet[3].SetActive(true);

                break;

            case "Left":
                anim.SetInteger("dir", 3);
                GeneratorBullet[0].SetActive(false);
                GeneratorBullet[1].SetActive(false);
                GeneratorBullet[2].SetActive(true);
                GeneratorBullet[3].SetActive(false);

                break;


            default:
                GeneratorBullet[0].SetActive(true);
                GeneratorBullet[1].SetActive(false);
                GeneratorBullet[2].SetActive(false);
                GeneratorBullet[3].SetActive(false);
                break;
        }
    }

}
