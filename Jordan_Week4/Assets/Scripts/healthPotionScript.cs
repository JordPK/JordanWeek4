using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotionScript : MonoBehaviour
{
    GameManager gm;
    public float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

        if (gm.health <= 0)
        {
            moveSpeed = 0f;
        }
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().extraAudio.PlayOneShot(other.GetComponent<PlayerController>().potionSfx, .5f);
            gm.health++;
            Destroy(gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        }

        if (other.tag == "Potion")
        {
            transform.position = new Vector3(transform.position.x + 4, transform.position.y , transform.position.z);
        }
    }
}
