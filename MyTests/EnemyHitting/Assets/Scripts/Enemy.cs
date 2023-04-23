using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3f;
    [SerializeField ]private float currentHealth;

    // set up for enemy chasing player
    private Rigidbody2D enemy;
    private Transform targetPlayer;
    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed = 0.5f;
    // chasing distance
    [SerializeField] private float minDis = 5f;
    

    // get rigid body of enemy gameObject
    private void Awake()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        tagretRange();
    }

    // enemy life damage on collision with bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Debug.Log("Ouch");
            currentHealth--;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                // Debug.Log("I die");
            }
        }
    }

    // constantly checking player in range
    void tagretRange()
    {
        // locate target position
        targetPlayer = GameObject.Find("Player").transform;

        float disX = enemy.transform.position.x - targetPlayer.position.x;
        float disY = enemy.transform.position.y - targetPlayer.position.y;
        float disTarget = Mathf.Sqrt((disX + disY) * (disX + disY));
        
        // Debug.Log("Distance is" + disTarget);

        // compare distance
        if (disTarget < minDis)
        {
            // Debug.Log("Target locked");
            // start chasing
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            moveDirection = direction;

            // enemy moving
            enemy.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
