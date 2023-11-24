using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPoolManager : MonoBehaviour
{
    public static ShellPoolManager Instance;
    public GameObject shellPrefab;
    public int poolSize = 10;

    private List<GameObject> shellPool;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        shellPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++) 
        {
            GameObject shell = Instantiate(shellPrefab);
            shell.SetActive(false);
            shellPool.Add(shell);
        }
    }

    public GameObject GetShell(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < shellPool.Count; i++) 
        {
            if (!shellPool[i].activeInHierarchy)
            {
                shellPool[i].transform.position = position;
                shellPool[i].transform.rotation = rotation;
                shellPool[i].SetActive(true);
                return shellPool[i];
            }
        }

            // If no inactive bullet is found, create a new one
            GameObject newShell = Instantiate(shellPrefab, position, rotation);
            shellPool.Add(newShell);
            return newShell;
    }
}
