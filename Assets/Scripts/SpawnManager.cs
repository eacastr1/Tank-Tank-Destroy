using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private EnemyPoolManager EnemyPoolManager;

    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] powerUpPrefabs;
    [SerializeField] int xRange;
    [SerializeField] int zRange;
    private int enemyCount;
    private int myWaveCount;
    public int waveCount
    {
        get { return myWaveCount; }
        set
        {
            if(value < 0)
            {
                Debug.Log("You can't have a negative wave count!");
            }
            else 
            {
                myWaveCount = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyPoolManager = EnemyPoolManager.Instance;
        waveCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = TrackEnemyCount();
    }

    public void SpawnBoss()
    {
        if(enemyCount == 0)
        {
            Instantiate(bossPrefab, bossPrefab.transform.position, bossPrefab.transform.rotation);
            waveCount++;
        }
    }

    public void SpawnWave()
    {
        if(enemyCount == 0)
        {
            for(int i = 0; i < waveCount; i++)
            {
                GameObject enemy = EnemyPoolManager.GetEnemy(GenerateRandomLocation(), new Quaternion(0.0f, 0.0f, 0.0f, 1.0f));
            }

            if(TrackPowerupCount() < 3) {
                Instantiate(powerUpPrefabs[0], GenerateRandomLocation(), powerUpPrefabs[0].transform.rotation);
            }

            if(waveCount < 10) {
                waveCount++;
            }
        }
    }

    private int TrackEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private int TrackPowerupCount()
    {
        return GameObject.FindGameObjectsWithTag("Powerup").Length;
    }

    private Vector3 GenerateRandomLocation()
    {
        int x = Random.Range(-xRange, xRange);
        int z = Random.Range(-zRange, zRange);

        return new Vector3(x, 1, z);
    }
}
