using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] int xRange;
    [SerializeField] int zRange;
    private int enemyCount;
    private int waveCount;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = TrackEnemyCount();
        SpawnWave();
    }

    void SpawnWave()
    {
        if(enemyCount == 0)
        {
            for(int i = 0; i < waveCount; i++)
            {
                GameObject enemy = GenerateRandomEnemey();

                Instantiate(enemy, GenerateRandomLocation(), enemy.transform.rotation);
            }

            waveCount++;
        }
    }

    int TrackEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    GameObject GenerateRandomEnemey()
    {
        int index = Random.Range(0, enemyPrefabs.Length);

        return enemyPrefabs[index];
    }

    Vector3 GenerateRandomLocation()
    {
        int x = Random.Range(-xRange, xRange);
        int z = Random.Range(-zRange, zRange);

        return new Vector3(x, 0, z);
    }
}
