using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FInalScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deaths;
    [SerializeField] private TextMeshProUGUI time;
    void Start(){

            InfoGame infoGameScritp = InfoGame.Instance;
        if(infoGameScritp){
            float timeInSeconds = infoGameScritp.TimeGame;
            int numberDeaths = infoGameScritp.PlayerKilled;

            time.text = $"Time: {FormatStringTime(timeInSeconds)}";
            deaths.text = $"Deaths: {numberDeaths.ToString()}";
        }
    }

    string FormatStringTime(float timeInSeconds){
        int hours = (int)(timeInSeconds / 3600);
        int minutes = (int)((timeInSeconds % 3600) / 60);
        int seconds = (int)(timeInSeconds % 60);


        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

        return formattedTime;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
