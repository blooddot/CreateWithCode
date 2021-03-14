using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange;
    public GameObject pizzaPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * axis * speed * Time.deltaTime);
        Vector3 position = transform.position;
        if (position.x < -xRange)
        {
            position.x = -xRange;
            transform.position = position;
        }
        else if (position.x > xRange)
        {
            position.x = xRange;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefab, transform.position, pizzaPrefab.transform.rotation);
        }
    }
}
