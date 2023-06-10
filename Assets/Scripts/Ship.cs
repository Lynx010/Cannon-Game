using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public GameObject land;
    
    void Start()
    {
        land = GameObject.FindGameObjectWithTag("Land");
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(land.transform);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(gameObject);
        }
    }
}
