using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;

    public int startSpawnTime = 10;
    public int spawnTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        int spawnPoints = Random.Range(0, 5);
        int enemy = Random.Range(0, 3);

        Instantiate(this.enemy, this.spawnPoints[spawnPoints].position, this.spawnPoints[spawnPoints].rotation);
    }
}
