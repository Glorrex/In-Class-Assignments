﻿using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRespawnPoint;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    
    private LayerMask enemyLayerMask;
    public float moveSpeed;
    public float walkingSpeed = 1f;
    public float jumpForce;
    public float runMultiplier = 2f;
    
    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        Move();
        //yPositionPitFallDeath();
    }

    // Physics Movements
    void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
        
    }

    // Process Keyboard Inputs
    void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        // Use Fire1 Button to Run
        if (Input.GetButtonDown("Fire1"))
        {
            moveSpeed *= runMultiplier;
        }
            // Release Fire1 to stop running
        if (Input.GetButtonUp("Fire1"))
        {
            moveSpeed = walkingSpeed;
        }
    }

    private bool IsGrounded()
    {

        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Check tto see if player is touching an Enemy
        if (collider.CompareTag("Enemy"))
            Die();
        {
            {
                Debug.Log("The player is touching" + collider.tag + "tag!");
            }
            {
            }
        }
        if (collider.CompareTag("DeathZone"))
        {
            Debug.Log("The Player Hit The DeathZone");
            Die();
        }
        void Die()
        {
            this.transform.position = playerRespawnPoint.transform.position;
            gameManager.removeLife();
        }
       
            
    }
    void yPositionPitFallDeath()
    {
        if(gameObject.transform.position.y < -25)
        {
            this.transform.position = playerRespawnPoint.transform.position;
            gameManager.removeLife();
        }
    }
}
