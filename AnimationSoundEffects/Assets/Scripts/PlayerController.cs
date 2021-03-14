using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public ParticleSystem dirtParticle;
    public ParticleSystem explotionParticle;
    private AudioSource audioSource;
    public AudioClip crashClip, jumpClip;

    public float gravityModifier;
    public float jumpForce;
    public bool isGround;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground") && !isGameOver)
        {
            isGround = true;
            dirtParticle.Play();
        }

        if (other.gameObject.CompareTag("obstacle") && !isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over!");

            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);

            explotionParticle.Play();
            dirtParticle.Stop();

            audioSource.PlayOneShot(crashClip);
        }
    }
}
