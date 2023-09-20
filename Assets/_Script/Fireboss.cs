using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireboss : Boss
{


    private void Start(){

    }

    private void Update(){

    }

    private IEnumerator Behavior(){
        while(true){

            // this.Move1();
            yield return new WaitForSeconds(4f);

            // this.Move4();

            // yield return new WaitForSeconds(4f);

            // this.Move2();

            // yield return new WaitForSeconds(4f);

        }
    }
}
