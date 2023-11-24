using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;
    [SerializeField] public GameObject[] enemyPrefabs;
    public int poolSize = 15;

    private List<GameObject> enemyPool;

    void Awake() {
        Instance = this;
    }

    void Start() {
        InitializePool();
    }

    private void InitializePool() {
        enemyPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++) {
            GameObject enemy = Instantiate(enemyPrefabs[i % 3]);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetEnemy(Vector3 position, Quaternion rotation) {
        for(int i = 0; i < enemyPool.Count; i++) {
            if(!enemyPool[i].activeInHierarchy) {
                enemyPool[i].transform.position = position;
                enemyPool[i].transform.rotation = rotation;
                enemyPool[i].SetActive(true);
                return enemyPool[i];
            }
        }
        GameObject newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], position, rotation);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
}
