using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform shootingPoint;
    public float force;
    float shootingTimer;
    public float shootingDelay;
    void Start()
    {
        
    }
    
    void Update()
    {

        shootingTimer += Time.deltaTime;
        
        if(Input.GetMouseButtonDown(0) && shootingTimer >= shootingDelay)
        {
            shootingTimer = 0f;
            StartCoroutine(ShootingCannonBall());
        }
        
    }

    IEnumerator ShootingCannonBall()
    {
        GameObject bullet = Instantiate(cannonBall, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = shootingPoint.forward * force * Time.deltaTime;
        yield return new WaitForSeconds(8);
        Destroy(bullet);
    }
}
