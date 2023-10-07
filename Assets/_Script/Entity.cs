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
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] dialog;
    private StringBuilder str = new StringBuilder();
    private GameController gameController;
    [SerializeField] private bool isFinal = false;

    void Start()
    {
    gameController = GameController.gc;
    dialogGameObject.SetActive(false);
    player = GameObject.FindWithTag("Player");
    if(isFinal){
        gameController.PlayerIsBoss = true;
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
                yield return new WaitForSecondsRealtime(0.15f);
            }
            yield return new WaitForSeconds(2f);
            str.Clear();

        }

        yield return new WaitForSeconds(5f);

    }

    void FinalAction(){
        dialogGameObject.SetActive(false);
        if(!isFinal){
            gameController.BossLoseLife();
        }else{
            if(player){
                player.transform.position = gameObject.transform.position;
            }
            StartCoroutine(ChangeSceneFinal());
        }
        Destroy(gameObject, 1f);
    }

    IEnumerator ChangeSceneFinal(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("FinalScene");
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = str.ToString();
    }
}
