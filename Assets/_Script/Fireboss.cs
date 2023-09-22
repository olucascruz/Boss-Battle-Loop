using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireboss : Boss
{



    private void Start(){

        StartCoroutine(Behavior());
    }

    private void Update(){

    }

    protected override IEnumerator Behavior(){
        IEnumerator loopAll = LoopShoot(0.5f, "all");
        IEnumerator loopDiagonal = LoopShoot(0.5f, "diagonal");
        IEnumerator loopWithTarget = LoopShootWithTarget(1f, "Player");

        while(true){
            SetTargetToMove(leftUp);
            yield return new WaitForSeconds(2f);

            // Loop Shoot
            StartCoroutine(loopAll);
            SetTargetToMove(leftDown);
            yield return new WaitForSeconds(2f);
            SetTargetToMove(rightUp);
            yield return new WaitForSeconds(6f);
            SetTargetToMove(leftDown);
            StopCoroutine(loopAll);



            yield return new WaitForSeconds(3f);
            SetTargetToMove(rightDown);

            // Loop Shoot with Target
            StartCoroutine(loopWithTarget);
            yield return new WaitForSeconds(5f);
            StopCoroutine(loopWithTarget);
            SetTargetToMove(rightUp);
            yield return new WaitForSeconds(2f);


            StartCoroutine(loopDiagonal);
            yield return new WaitForSeconds(5f);
            StopCoroutine(loopDiagonal);

        }
    }
}
