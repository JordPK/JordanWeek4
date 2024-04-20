using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEditor.XR;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public GameManager gameManager;
    public ParticleSystem dust;
    public ParticleSystem runningParticle;
    float horizontal;
    Vector3 movement;

    [Header("Player Audio")]

    public AudioClip jumpSfx;
    public AudioClip[] dmgSfx;
    public AudioClip coinSfx;
    public AudioClip potionSfx;

    public AudioSource playerAudio;
    public AudioSource extraAudio;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public float gravityMultiplier;
    public float doubleJumpHeight = 10f;
    
    [Header("Player Boundaries")]
    public float xRange = -2f;
    public float positiveXRange = 20f;

    [Header("Jump")]
    int currentJump;
    public int maxJumps = 2;

    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
        
        // Jump & Double Jump

        if (Input.GetKeyDown(KeyCode.Space) && maxJumps > 0 && gameManager.health > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            maxJumps--;
            anim.SetTrigger("jump_trig");
            runningParticle.Stop();
            playerAudio.PlayOneShot(jumpSfx, 1);
        }

        // Transform Boundaries

        if (transform.position.x < xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > positiveXRange)
        {
            transform.position = new Vector3(positiveXRange, transform.position.y, transform.position.z);
        }

        // if health is 0 play death animation
        if (gameManager.health <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag == "double jump")
        {
            rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
            maxJumps = 0;
        }

        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
            maxJumps = 2;
            runningParticle.Play();
        }

        if (collision.transform.tag == "Obstacle")
        {
            randomDmgSound();
            //playerAudio.PlayOneShot(crashSfx, 1f);
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            gameManager.health--;
            Debug.Log("gameManager.health");
        }
        if (collision.transform.tag == "Coin")
        {
            gameManager.score += 1;

        }
        // If health is 0 then play dust animation
        if (collision.transform.tag == "Obstacle" && gameManager.health == 0)
        {
            dust.Play();
        }
        
        void randomDmgSound()
        {
            // Plays random damage sound from array
            int dmgSfxIndex = UnityEngine.Random.Range(0, dmgSfx.Length);
            playerAudio.PlayOneShot(dmgSfx[dmgSfxIndex], 1f);
        }
       
    }
}
