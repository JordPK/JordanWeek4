using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoveScript : MonoBehaviour
{
    public float scrollSpeed;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(Time.deltaTime * scrollSpeed, 0);

        if (gm.health <= 0)
        {
            scrollSpeed = 0;
        }
    }
}
