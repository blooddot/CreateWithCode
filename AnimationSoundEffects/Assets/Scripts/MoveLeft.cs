using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerController;
    public float speed;
    public float leftBound;
    // Start is called before the first frame update
    void Start()
    {
        // playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
