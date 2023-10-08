using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogGameObject;
    [SerializeField] private GameObject changeScene;

    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] dialog;
    private StringBuilder str = new StringBuilder();
    private GameController gameController;
    [SerializeField] private bool isFinal = false;
    InfoGame infoGame;

    void Start()
    {
    infoGame = InfoGame.Instance;
    gameController = GameController.gc;
    dialogGameObject.SetActive(false);
    player = GameObject.FindWithTag("Player");
    if(infoGame){
        if(isFinal){
            infoGame.EndTime();
        }else{
            infoGame.StarCountKilled();
        }
    }
    StartCoroutine(Dialog());

    }


    private IEnumerator Dialog(){
        yield return new WaitForSeconds(5f);
        dialogGameObject.SetActive(true);
        foreach (string phrase in dialog)
        {

            foreach (char letter in phrase)
            {
                str.Append(letter.ToString());
                yield return new WaitForSecondsRealtime(0.10f);
            }
            yield return new WaitForSeconds(2f);
            str.Clear();

        }

        yield return new WaitForSeconds(4f);
        FinalAction();

    }

    void FinalAction(){
        dialogGameObject.SetActive(false);
        if(!isFinal){
            infoGame.StartTime();
            gameController.BossLoseLife();
        }else{
            if(player){
                gameController.PlayerIsBoss = true;
                gameController.RefreshScreen();
                player.transform.position = gameObject.transform.position;
            }
            if(changeScene){
                changeScene.GetComponent<ChangeScene>().SceneFinal();
            }
        }
        Destroy(gameObject, 1f);
    }


    // Update is called once per frame
    void Update()
    {
        dialogText.text = str.ToString();
    }
}
