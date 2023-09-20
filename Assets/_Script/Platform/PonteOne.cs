using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonteOne : MonoBehaviour
{
    [SerializeField]
    private GameObject Barreira;
    [SerializeField]
    private GameObject Ponte;

    private bool hasPonte = false;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("ShowPonte", 4f, 10f);
        Invoke("ShowPonte", 4f);
    }


    private void ShowPonte(){
        if(!hasPonte){
            Ponte.SetActive(true);
            Barreira.SetActive(false);
        }else{
            Ponte.SetActive(false);
            Barreira.SetActive(true);
        }

    }
}
