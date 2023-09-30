using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkboss : Boss
{
    [SerializeField] private GameObject darkSphere;
    [SerializeField] private GameObject[] listTargets;


    protected Vector3 GetTargetSphere(string s){
        Dictionary<string, Vector3> targetSphere = new Dictionary<string, Vector3>();


        foreach (GameObject darkTarget in listTargets)
        {
            targetSphere[darkTarget.name] = darkTarget.transform.position;
        }

        return targetSphere[s];
    }

    private void GenerateDarkSphere(int numCircle){
        GameObject upDarkSphere = Instantiate(darkSphere, transform.position, transform.rotation);
        GameObject downDarkSphere = Instantiate(darkSphere, transform.position, transform.rotation);
        GameObject leftDarkSphere = Instantiate(darkSphere, transform.position, transform.rotation);
        GameObject rightDarkSphere = Instantiate(darkSphere, transform.position, transform.rotation);


        upDarkSphere.GetComponent<DarkSphere>().SetTarget(GetTargetSphere($"up{numCircle}"));
        downDarkSphere.GetComponent<DarkSphere>().SetTarget(GetTargetSphere($"down{numCircle}"));
        leftDarkSphere.GetComponent<DarkSphere>().SetTarget(GetTargetSphere($"left{numCircle}"));
        rightDarkSphere.GetComponent<DarkSphere>().SetTarget(GetTargetSphere($"right{numCircle}"));
    }

    protected override IEnumerator Behavior(){
        IEnumerator loopWithTarget = LoopShootWithTargetPlayer(2f);
        int numCircle =  1;
        while(true){
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            SetTargetToMove(rightUp);
            SetTargetToMove(rightDown);
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            yield return new WaitForSeconds(6f);
            StartCoroutine(loopWithTarget);
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            SetTargetToMove(rightUp);
            SetTargetToMove(rightDown);
            SetTargetToMove(leftUp);
            SetTargetToMove(leftDown);
            yield return new WaitForSeconds(5f);
            numCircle = (numCircle == 1) ? 2 : 1;
            StopCoroutine(loopWithTarget);
            GenerateDarkSphere(numCircle);






        }
    }
}
