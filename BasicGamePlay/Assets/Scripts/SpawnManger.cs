using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xRange;
    public float startZ;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spawnAnimal), 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnAnimal()
    {
        float posX = Random.Range(-xRange, xRange);
        Vector3 position = new Vector3(posX, 0, startZ);
        int index = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[index], position, animalPrefabs[index].transform.rotation);
    }
}
