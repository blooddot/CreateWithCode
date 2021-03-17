using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRage;
    public int enemyCount;
    private int waveNumber = 1;
    public GameObject powerUpPrefab;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            spawnEnemy(waveNumber);
            waveNumber++;
            Instantiate(powerUpPrefab, randomPos(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 randomPos()
    {
        float spawnPosX = Random.Range(-spawnRage, spawnRage);
        float spawnPosZ = Random.Range(-spawnRage, spawnRage);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    void spawnEnemy(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemyPrefab, randomPos(), Quaternion.identity);
        }
    }
}
