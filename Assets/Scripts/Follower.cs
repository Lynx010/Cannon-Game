using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTraveled;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
    }
}
