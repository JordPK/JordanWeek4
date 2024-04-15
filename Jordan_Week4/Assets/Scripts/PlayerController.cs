using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    
    
    public float jumpForce;
    public float gravityMultiplier;
    public float doubleJumpHeight = 10f;

    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "double jump")
        {
            rb.AddForce(Vector3.up * doubleJumpHeight, ForceMode.Impulse);
        }
    }
}
