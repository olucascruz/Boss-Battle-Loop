using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    PLAY, GAMEOVER
}

public class GameController : MonoBehaviour
{
    public static GameController gc;
    private GameState gameState;
    public GameState GameState{
        get{return gameState;}
    }
    private int qntBullet = 0;
    [SerializeField] private float BossLife = 100f;
    private float PlayerLife = 100f;


    [SerializeField] private Text qntBulletText;
    [SerializeField] private Text BossLifeText;
    [SerializeField] private GameObject BossLifeObject;
    [SerializeField] private Image BossLifeImage;

    [SerializeField] private GameObject BossLifeSpace;
    [SerializeField] private Image PlayerLifeImage;
    [SerializeField] private GameObject PlayerLifeSpace;
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject ButtonsTouch;

    private InfoGame infoGame;

    private bool playerIsBoss = false;
    public bool PlayerIsBoss{
        set{playerIsBoss = value;}
    }
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
        }else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        gameState = GameState.PLAY;
        originalBossLife = BossLife;
        infoGame = InfoGame.Instance;
        RefreshScreen();

    }

    public void RefreshScreen()
    {
        if(!playerIsBoss){
            if(qntBulletText) qntBulletText.text = $"Bullets: {qntBullet}/6";
        }else{
            if(qntBulletText) qntBulletText.text = $"Bullets: ∞/∞";
        }
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
        if(playerIsBoss) return true;

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
        if (BossLife <= 0)
        {
            if(BossLifeObject) BossLifeObject.SetActive(false);
            if(BossLifeSpace) BossLifeSpace.SetActive(false);
            Portal.SetActive(true);
        }
    }
    public void PLayerLoseLife()
    {
        PlayerLife = PlayerLife - 33.4f;
        RefreshScreen();
        if (PlayerLife <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameState = GameState.GAMEOVER;
            GameOver.SetActive(true);
            infoGame.AddKilled();
        }
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
