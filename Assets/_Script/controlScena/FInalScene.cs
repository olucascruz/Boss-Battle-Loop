using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FInalScene : MonoBehaviour
{

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
