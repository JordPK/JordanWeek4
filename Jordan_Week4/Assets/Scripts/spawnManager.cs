using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] coin;
    public GameObject[] environment;
    public GameObject[] backEnvironment;
    public GameObject healthPotion;
    public Vector3 spawnPosition;
    public Vector3 environmentSpawnPosition;
    public Vector3 backEnvironmentSpawnPosition;
    GameManager gm;
    bool isPotionSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        InvokeRepeating("Spawn", 2, 2);
        InvokeRepeating("SpawnCoin", 2, 2);
        InvokeRepeating("SpawnEnvironment", 2, 3);
        InvokeRepeating("SpawnBackEnvironment", 2, 2);
        //InvokeRepeating("SpawnHealthPotion", 5, 10);
    }

    private void Update()
    {
        if (gm.score % 25==0 && !isPotionSpawned)
        {
            //isPotionSpawned=true;
            SpawnHealthPotion();
            
        }
        if (gm.score % 25 != 0)
        {
            isPotionSpawned=false;
        }
    }

    void Spawn()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstacleIndex].transform, spawnPosition, obstacles[obstacleIndex].transform.rotation, transform);
    }

    void SpawnCoin()
    {
        int coinIndex = Random.Range(0, coin.Length);   
        Vector3 coinSpawnPosition = new Vector3(Random.Range(22, 29), Random.Range(1, 4), 0);
        Instantiate(coin[coinIndex].transform, coinSpawnPosition, coin[coinIndex].transform.rotation, transform);
    }

    void SpawnEnvironment()
    {
        int environmentIndex = Random.Range(0, environment.Length);
        Instantiate(environment[environmentIndex].transform, environmentSpawnPosition, environment[environmentIndex].transform.rotation);
    }

    void SpawnBackEnvironment()
    {
        int environmentIndex = Random.Range(0, environment.Length);
        Instantiate(backEnvironment[environmentIndex].transform, backEnvironmentSpawnPosition, backEnvironment[environmentIndex].transform.rotation);
    }

    void SpawnHealthPotion()
    {
        isPotionSpawned = true;
        Vector3 potionSpawnPos = new Vector3(Random.Range(22, 29), Random.Range(1, 4), 0);
        Instantiate(healthPotion.transform, potionSpawnPos, healthPotion.transform.rotation);
    }

       


}
