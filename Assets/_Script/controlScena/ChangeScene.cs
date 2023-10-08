using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string NameScene;

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScen(){
        SceneManager.LoadScene(NameScene);
    }

    public void SceneFinal(){
        StartCoroutine(ChangeSceneFinal());
    }
    private IEnumerator ChangeSceneFinal(){
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("FinalScene");
    }
}
