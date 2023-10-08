using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
    private int playerKilled = 0;
    public int PlayerKilled{
        get{return playerKilled;}
    }
    private float timeGame;
    public float TimeGame{
        get{return timeGame;}
    }

    private static InfoGame instance;
    public static InfoGame Instance{
        get{return instance;}
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

   public void StartTime()
   {
    timeGame = Time.time;
   }
   public void EndTime()
   {
    timeGame = timeGame - Time.time;
   }
   public void StarCountKilled()
   {
    playerKilled = 0;
   }
   public void AddKilled()
   {
    playerKilled += 1;
   }

}
