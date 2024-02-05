using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float playerSpeed = 8f;
    private float jumpForce = 16f;
    private bool isFacingRight = true;
    private bool canJump = false;

    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    


    private void Start()
    {
        // get the player's rigidbody
        myRb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, 16f);
            canJump = false;
        }

        if (IsGrounded())
        {
            canJump = true;
        }

        Flip();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }

    }

    private void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void FixedUpdate()
    {
        myRb.velocity = new Vector2(horizontal * playerSpeed, myRb.velocity.y);

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, myRb.transform.localScale.y + 0.1f, groundLayer);

        return hit.collider != null;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= - 1f;
            transform.localScale = localScale;
        }
    }

}
