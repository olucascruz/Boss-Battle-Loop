using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_coletavel : MonoBehaviour
{
    private GameController gc;

    void Start()
    {
        gc = GameController.gc;
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            gc.AddBullet();
            Invoke("ReturnBullet", 5f);
        }
    }

    void ReturnBullet()
    {
        gameObject.SetActive(true);
    }
}
