using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireboss : Boss
{
    protected override IEnumerator Behavior(){
        IEnumerator loopAll = LoopShoot(1f, "all");
        IEnumerator loopDiagonal = LoopShoot(1f, "diagonal");
        IEnumerator loopWithTarget = LoopShootWithTargetPlayer(1f);

        while(true){
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            SetTargetToMove(rightDown);
            SetTargetToMove(rightUp);
            yield return new WaitForSeconds(4f);
            StartCoroutine(loopAll);
            yield return new WaitForSeconds(6f);
            StopCoroutine(loopAll);
            yield return new WaitForSeconds(2f);
            SetTargetToMove(leftUp);

            StartCoroutine(loopWithTarget);
            yield return new WaitForSeconds(6f);
            SetTargetToMove(rightUp);
            StopCoroutine(loopWithTarget);

            yield return new WaitForSeconds(2f);
            StartCoroutine(loopDiagonal);
            yield return new WaitForSeconds(4f);
            StopCoroutine(loopDiagonal);



        }

    }
}
