using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationProblemFix : MonoBehaviour
{
    private Quaternion previousRotation;
    public GameObject camHolder;
    
    void Start()
    {
        previousRotation = transform.rotation;
    }
    
    void Update()
    {
        // Calculate the angle difference between the current and previous frames
        Quaternion currentRotation = transform.rotation;
        Quaternion deltaRotation = Quaternion.Inverse(previousRotation) * currentRotation;
        previousRotation = currentRotation;

        // Extract the angle difference from the delta rotation quaternion
        float angleDifference = 0f;
        Vector3 axis = Vector3.zero;
        deltaRotation.ToAngleAxis(out angleDifference, out axis);

        // Apply the angle difference to the camera rotation
        transform.RotateAround(camHolder.transform.position, axis, angleDifference);
    }
}
