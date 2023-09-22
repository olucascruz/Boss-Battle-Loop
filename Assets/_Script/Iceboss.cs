using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceboss : Boss
{

    protected override IEnumerator Behavior(){
        IEnumerator loopWithTarget = LoopShootWithTarget(1f, "Player");
        while(true){
            SetTargetToMove(leftUp);
            yield return new WaitForSeconds(2f);

            // Loop Shoot
            StartCoroutine(loopWithTarget);
            SetTargetToMove(leftDown);
            yield return new WaitForSeconds(2f);
            SetTargetToMove(rightUp);
            yield return new WaitForSeconds(6f);
            SetTargetToMove(leftDown);
            StopCoroutine(loopWithTarget);

        }
    }
}
