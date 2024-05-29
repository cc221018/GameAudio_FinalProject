using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 distanceToMove;

    [SerializeField]
    private float velocityFactor = 1;

    private Vector3 startingPoint;
    private Vector3 destinationPoint;
    private float passedTimeForInterpolation = 0;

    private bool increaseValue = true;



    void Start()
    {
        startingPoint = gameObject.transform.position;
        destinationPoint = startingPoint + distanceToMove;
    }

    void Update()
    {
        if (increaseValue) {
            passedTimeForInterpolation += Time.deltaTime * velocityFactor; 
            // changes with every update -> need different numbers for result
        }
        else {
            passedTimeForInterpolation -= Time.deltaTime * velocityFactor;
        }

        if (passedTimeForInterpolation > 1) {
            increaseValue = false;
        }
        else if (passedTimeForInterpolation < 0) {
            increaseValue = true;
        }

        Vector3 result = Vector3.Lerp(startingPoint, destinationPoint, passedTimeForInterpolation);
        gameObject.transform.position = result;
    }
}
