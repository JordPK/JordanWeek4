using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        }
    }
}
