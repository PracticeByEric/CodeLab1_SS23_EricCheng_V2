using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float playerSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
