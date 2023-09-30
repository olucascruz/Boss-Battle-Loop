using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceboss : Boss
{

    [SerializeField] private GameObject iceSpike;
    [SerializeField] private float attackIceSpikeDelay;



    protected override IEnumerator Behavior(){
        GameObject player = GameObject.FindWithTag("Player");
        IEnumerator loopWithTarget = LoopShootWithTargetPlayer(2f);
        while(true){
            SetTargetToMove(leftUp);
            yield return new WaitForSeconds(2f);

            // Loop Shoot
            StartCoroutine(loopWithTarget);
            SetTargetToMove(leftDown);
            StartCoroutine(AttackIceSpike(player.transform.position));
            yield return new WaitForSeconds(2f);
            SetTargetToMove(rightUp);
            StartCoroutine(AttackIceSpike(player.transform.position));
            StartCoroutine(AttackIceSpike(player.transform.position));
            StartCoroutine(AttackIceSpike(player.transform.position));


            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            SetTargetToMove(leftUp);

            yield return new WaitForSeconds(4f);
            SetTargetToMove(leftDown);
            StopCoroutine(loopWithTarget);

        }
    }

    private IEnumerator AttackIceSpike(Vector3 playerPosition){
        yield return new WaitForSeconds(attackIceSpikeDelay);
        GameObject spike = Instantiate(iceSpike, playerPosition, Quaternion.identity);
        Destroy(spike, 3f);
    }
}
