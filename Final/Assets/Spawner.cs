using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyA;
    public GameObject EnemyB;
    public Transform[] spawnPoints;
    int spawnLoc;
    void Start()
    {
        InvokeRepeating("SpawnA",1f,1f);
        InvokeRepeating("SpawnB", 1f, 1f);
    }

    
    void SpawnA()
    {
        spawnLoc = Random.Range(0, 5);
        Instantiate(EnemyA, spawnPoints[spawnLoc].position, spawnPoints[spawnLoc].rotation);
    }
    void SpawnB()
    {
        spawnLoc = Random.Range(0, 5);
        Instantiate(EnemyB, spawnPoints[spawnLoc].position, spawnPoints[spawnLoc].rotation);
    }
}
