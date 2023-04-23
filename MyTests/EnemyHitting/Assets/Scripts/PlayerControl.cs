using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // components
    private Rigidbody2D player;
    
    public float playerSpeed = 10f;

    private float speedLimiter = 0.7f;

    private float inputHorizontal;
    private float inputVertical;
    
    // Animation and states
    private Animator _animator;
    private string currentAnimationState;
    
    private const string PLAYER_IDLE = "Player_Idle";
    private const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    private const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    private const string PLAYER_WALK_UP = "Player_Walk_Up";
    private const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();

        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            player.velocity = new Vector2(inputHorizontal * playerSpeed, inputVertical * playerSpeed);
            
            // change animation by player motion status
            // if walking right
            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
        else
        {
            player.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    // animation state changer
    void ChangeAnimationState(string newState)
    {
        // stop animation from interrupting itself
        if (currentAnimationState == newState)
        {
            return;
        }
        // play new animation
        else
        {
            _animator.Play(newState);
        }

        currentAnimationState = newState;
    }
}
