using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class Entity : MonoBehaviour
{

    [SerializeField] private GameObject dialogGameObject;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] dialog;
    private StringBuilder str = new StringBuilder();
    private GameController gameController;

    void Start()
    {
    gameController = GameController.gc;
    dialogGameObject.SetActive(false);

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
        dialogGameObject.SetActive(false);
        gameController.BossLoseLife();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = str.ToString();
    }
}
