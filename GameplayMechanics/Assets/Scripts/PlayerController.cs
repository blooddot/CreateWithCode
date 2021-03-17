using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject focusPoint;
    public GameObject ringSign;
    public float speed;
    public bool isPowerUp;
    public float powerStrength;
    private float waitTime = 7;
    public float deadY;
    private SpawnManager spawnMgr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnMgr = FindObjectOfType<SpawnManager>();
        focusPoint = GameObject.Find("FocusPoint");
        setIsPowerUp(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnMgr.isGameOver) return;

        if (transform.position.y < deadY)
        {
            spawnMgr.isGameOver = true;
            return;
        }

        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focusPoint.transform.forward * speed * forwardInput);
        if (isPowerUp)
        {
            ringSign.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            setIsPowerUp(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(waitTime);
        setIsPowerUp(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && isPowerUp)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dirFromPlayer = other.transform.position - transform.position;
            enemyRb.AddForce(dirFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }

    private void setIsPowerUp(bool value)
    {
        isPowerUp = value;
        ringSign.SetActive(isPowerUp);
    }
}
