using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    [SerializeField]
    private LineRenderer circleRenderer;

    [SerializeField]
    private int StepsTest;
    [SerializeField]

    private float radiusSize;

    [SerializeField]
    private float SpeedRotation = 1;
    private GameController gc;
    void Start()
    {
        gc = GameController.gc;
        circleRenderer = GetComponent<LineRenderer>();
        DrawACircle(StepsTest, radiusSize);
    }

    void FixedUpdate(){
         if(gc.GetBossLife() > 0){
            RotatePlatform();
        }else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void DrawACircle(int steps, float radius)
    {
        circleRenderer.positionCount = steps;
        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);
            circleRenderer.SetPosition(currentStep, currentPosition);

        }
    }


    private void RotatePlatform(){
        transform.Rotate(transform.rotation.x, transform.rotation.y, Time.deltaTime * SpeedRotation, Space.Self);
    }
}
