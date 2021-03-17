using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float deadY;
    private Rigidbody rb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadY)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 playerDir = (player.transform.position - transform.position).normalized;
        rb.AddForce(playerDir * speed);
    }
}
