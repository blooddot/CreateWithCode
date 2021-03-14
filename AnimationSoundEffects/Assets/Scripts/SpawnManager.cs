using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject obsaclePrefab;
    public Vector3 spawnPos = new Vector3(20, 0, 0);
    public float startDelay, repeatRete;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        InvokeRepeating(nameof(spawnObSacle), startDelay, repeatRete);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnObSacle()
    {
        if (playerController.isGameOver)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(obsaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
