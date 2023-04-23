using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Singleton player
    public static PlayerControl _PlayerControl;
    
    private Rigidbody2D _rd2D;

    // set applied force amount
    [SerializeField] private int forceAmount = 2;

    // Singleton control
    private void Awake()
    {
        if (_PlayerControl == null)
        {
            DontDestroyOnLoad(gameObject);
            _PlayerControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // get RigidBody2D component from gameObject
        _rd2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD control
        if (Input.GetKey(KeyCode.W))
        {
            _rd2D.AddForce(Vector2.up * forceAmount);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rd2D.AddForce(Vector2.down * forceAmount);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rd2D.AddForce(Vector2.left * forceAmount);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rd2D.AddForce(Vector2.right * forceAmount);
        }
        
        // slow done object speed by time
        _rd2D.velocity *= 0.99f;

    }
        
}
