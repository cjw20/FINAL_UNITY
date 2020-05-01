using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyA;
    
    public Transform[] spawnPoints;
    int spawnLoc;
    void Start()
    {
        InvokeRepeating("SpawnA",1f,3f);
        InvokeRepeating("SpawnB", 20f, 2f);
        InvokeRepeating("SpawnC", 10f, 2.5f);
    }

    
    void SpawnA()
    {
        if(GameObject.Find("Player") != null)
        {
            spawnLoc = Random.Range(0, 5);
            Instantiate(EnemyA, spawnPoints[spawnLoc].position, spawnPoints[spawnLoc].rotation);
        }
       
    }
    void SpawnB()
    {
        if (GameObject.Find("Player") != null)
        {
            spawnLoc = Random.Range(0, 5);
            Instantiate(EnemyA, spawnPoints[spawnLoc].position, spawnPoints[spawnLoc].rotation);
        }
    }
    void SpawnC()
    {
        if (GameObject.Find("Player") != null)
        {
            spawnLoc = Random.Range(0, 5);
            Instantiate(EnemyA, spawnPoints[spawnLoc].position, spawnPoints[spawnLoc].rotation);
        }
    }
}
