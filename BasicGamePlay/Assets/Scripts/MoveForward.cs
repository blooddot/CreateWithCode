using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float posZ = transform.position.z;
        if (posZ > 30f || posZ < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
