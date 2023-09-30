using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    private int qntBullet = 0;
    [SerializeField] private float BossLife = 100f;
    private float PlayerLife = 100f;


    [SerializeField]
    private Text qntBulletText;
    [SerializeField]
    private Text BossLifeText;
    [SerializeField]
    private GameObject BossLifeObject;
    [SerializeField]
    private Image BossLifeImage;

    [SerializeField]
    private GameObject BossLifeSpace;

    [SerializeField]
    private Image PlayerLifeImage;

    [SerializeField]
    private GameObject PlayerLifeSpace;


    [SerializeField]
    private GameObject Portal;

    [SerializeField]
    private GameObject GameOver;

    [SerializeField]
    private GameObject ButtonsTouch;

    private float originalBossLife;
    void Awake()
    {
        if (gc == null)
        {
            gc = this;
        }
        else if (gc != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        if (Application.isMobilePlatform)
        {
            ButtonsTouch.SetActive(true);
        }
        originalBossLife = BossLife;
        RefreshScreen();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BossLife <= 0)
        {
            BossLifeObject.SetActive(false);
            BossLifeSpace.SetActive(false);
            Portal.SetActive(true);
        }

        if (PlayerLife <= 0)
        {
            GameOver.SetActive(true);
        }
    }
    public void RefreshScreen()
    {
        if(qntBulletText) qntBulletText.text = $"Bullets: {qntBullet}/6";
        if(BossLifeText) BossLifeText.text = $"{BossLife}%";
        if(BossLifeImage) BossLifeImage.fillAmount = BossLife / originalBossLife;
        PlayerLifeImage.fillAmount = PlayerLife / 100f;

    }

    public bool AddBullet()
    {
        if (qntBullet == 6) return false;
        qntBullet++;
        RefreshScreen();
        return true;
    }

    public bool UseBullet()
    {
        if (qntBullet > 0)
        {
            qntBullet--;
            RefreshScreen();
            return true;
        }
        else
        {
            return false;
        }

    }

    public void BossLoseLife()
    {
        BossLife = BossLife - 10;
        RefreshScreen();
    }
    public void PLayerLoseLife()
    {
        PlayerLife = PlayerLife - 33.4f;
        RefreshScreen();
    }

    public float GetBossLife()
    {
        return BossLife;
    }

    public float GetPlayerLife()
    {
        return PlayerLife;
    }

    public GameObject GetBossLifeSpace()
    {
        return BossLifeSpace;
    }
}
