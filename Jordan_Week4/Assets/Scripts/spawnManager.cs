using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] Coin;
    public Vector3 spawnPosition;

     
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, 2);
        InvokeRepeating("SpawnCoin", 2, 2);
    }

    void Spawn()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstacleIndex].transform, spawnPosition, obstacles[obstacleIndex].transform.rotation, transform);
    }

    void SpawnCoin()
    {
        int coinIndex = Random.Range(0, Coin.Length);   
        Vector3 coinSpawnPosition = new Vector3(Random.Range(22, 29), Random.Range(-2, 4), 0);
        Instantiate(Coin[coinIndex].transform, coinSpawnPosition, Coin[coinIndex].transform.rotation, transform);
    }


}
