using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public List<GameObject> spawnedShips = new();
    public int nextWave = 1;
    public int howManyEnemies;
    public float timeBetweenSpawn;
    public bool canSwitchTheCase;



    void Start()
    {
        StartCoroutine(WaveSpawner());
    }
    
    void Update()
    {
        RemoveMissingObjectFromList();

        if(spawnedShips.Count == 0)
        {
            canSwitchTheCase = true;
        }
        else
        {
            canSwitchTheCase = false;
        }
    }

    IEnumerator WaveSpawner()
    {
        switch(nextWave)
        {
            case 1:
                Debug.Log("Wave 1 yazisi geldi");
                yield return new WaitForSeconds(3);
                Debug.Log("Wave 1 yazisi 3sn sonra gitti");

                howManyEnemies = 1;
                timeBetweenSpawn = 3;
                for(int i = 0; i < howManyEnemies; i++)
                {
                    Debug.Log("Spawned " + i);
                    SpawnShip();
                    yield return new WaitForSeconds(0);//its 0 because we are only spawning one object
                }
        
                Debug.Log(spawnedShips.Count);
                nextWave ++;
                yield return new WaitUntil(() => canSwitchTheCase == true);
                break;
            
            case 2:
                Debug.Log("Wave 2 yazisi geldi");
                yield return new WaitForSeconds(3);
                Debug.Log("Wave 2 yazisi 3sn sonra gitti");

                howManyEnemies = 2;
                timeBetweenSpawn = 3;
                for(int i = 0; i < howManyEnemies; i++)
                {
                    Debug.Log("Spawned " + i);
                    SpawnShip();
                    yield return new WaitForSeconds(timeBetweenSpawn);
                }
        
                Debug.Log(spawnedShips.Count);
                nextWave ++;
                yield return new WaitUntil(() => canSwitchTheCase == true);
                break;

            case 3:
                Debug.Log("Wave 3 yazisi geldi");
                yield return new WaitForSeconds(3);
                Debug.Log("Wave 3 yazisi 3sn sonra gitti");

                howManyEnemies = 5;
                timeBetweenSpawn = 3;
                for(int i = 0; i < howManyEnemies; i++)
                {
                    Debug.Log("Spawned " + i);
                    SpawnShip();
                    yield return new WaitForSeconds(timeBetweenSpawn);
                }
        
                Debug.Log(spawnedShips.Count);
                nextWave ++;
                yield return new WaitUntil(() => canSwitchTheCase == true);
                break;

            case 4:
                //Boss
                break;
                
        }
        StartCoroutine(WaveSpawner());
    }

    void SpawnShip()
    {
        int randomPart = Random.Range(1,5);

        switch(randomPart)
        {
            case 1:
            float upperPartX = Random.Range(-500f, 500f);
            float upperPartZ = Random.Range(200f, 500f);
            Vector3 spawnPosition1 = new Vector3(upperPartX, 5.361748f, upperPartZ);
            GameObject spawnedShip1 = Instantiate(enemy, spawnPosition1, Quaternion.identity);
            spawnedShips.Add(spawnedShip1);
            break;

            case 2:
            float bottomPartX = Random.Range(-500f, 500f);
            float bottomPartZ = Random.Range(-200f, -500f);
            Vector3 spawnPosition2 = new Vector3(bottomPartX, 5.361748f, bottomPartZ);
            GameObject spawnedShip2 = Instantiate(enemy, spawnPosition2, Quaternion.identity);
            spawnedShips.Add(spawnedShip2);
            break;

            case 3:
            float rightPartX = Random.Range(200f, 500f);
            float rightPartZ = Random.Range(200f, -200f);
            Vector3 spawnPosition3 = new Vector3(rightPartX, 5.361748f, rightPartZ);
            GameObject spawnedShip3 = Instantiate(enemy, spawnPosition3, Quaternion.identity);
            spawnedShips.Add(spawnedShip3);
            break;

            case 4:
            float leftPartX = Random.Range(-200, -500f);
            float leftPartZ = Random.Range(200f, -200f);
            Vector3 spawnPosition4 = new Vector3(leftPartX, 5.361748f, leftPartZ);
            GameObject spawnedShip4 = Instantiate(enemy, spawnPosition4, Quaternion.identity);
            spawnedShips.Add(spawnedShip4);
            break;
        }

    }

    public void RemoveMissingObjectFromList()
    {
        for(var i = spawnedShips.Count - 1; i > -1; i--)
            {
                if (spawnedShips[i] == null)
                    spawnedShips.RemoveAt(i);
            }
    }
}
