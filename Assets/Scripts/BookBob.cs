using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBob : MonoBehaviour
{
    public enum axis { x, y, z };
    private Vector3 thisPosition;
    private bool goingUp = true;
    public float addDist = 0.5f;
    private float currentVel = .01f;
    public float velocityMod = .09f;
    public float distAccuracy = .005f;
    public axis axisToBob = axis.y;
    public bool oppositeDir = false;

    void Start()
    {
        thisPosition = this.transform.position;
    }

    void Update()
    {
        float approxCheckAxis = axisToBob == axis.y ? thisPosition.y : (axisToBob == axis.z ? thisPosition.z : thisPosition.x);
        Vector3 vectorToBob = Vector3.zero;

        if (goingUp)
            currentVel = oppositeDir ? -addDist : addDist;
        else
            currentVel = oppositeDir ? addDist : -addDist;

        if (axisToBob == axis.x)
        {
            if (isApproximate(this.transform.position.x, approxCheckAxis + currentVel, distAccuracy))
                goingUp = !goingUp;
            vectorToBob = new Vector3(thisPosition.x + currentVel, thisPosition.y, thisPosition.z);

        }
        else if (axisToBob == axis.y)
        {
            if (isApproximate(this.transform.position.y, approxCheckAxis + currentVel, distAccuracy))
                goingUp = !goingUp;
            vectorToBob = new Vector3(thisPosition.x, thisPosition.y + currentVel, thisPosition.z);
        }
        else
        {
            if (isApproximate(this.transform.position.z, approxCheckAxis + currentVel, distAccuracy))
                goingUp = !goingUp;
            vectorToBob = new Vector3(thisPosition.x, thisPosition.y, thisPosition.z + currentVel);
        }

        this.transform.position = Vector3.Lerp(this.transform.position, vectorToBob, Time.deltaTime * velocityMod);
    }

    bool isApproximate(float inputA, float inputB, float tolerance)
    {
        return Mathf.Abs(inputA - inputB) < tolerance;
    }
}