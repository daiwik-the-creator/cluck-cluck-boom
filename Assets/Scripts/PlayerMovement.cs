using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float playerSpeed = 8f;
    private float jumpForce = 16f;
    private bool isFacingRight = true;
    private bool canJump = false;

    [SerializeField] private GameObject camObj;
    [SerializeField] private float camFlipSpeed;
    [SerializeField] private Rigidbody2D myRb;
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
        Flip();
        CineCam();
    }

    public bool IsGrounded()
    {
        // Raycasting example taken from GAME 290 -Unity Tutorial #1
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

            // Accessing the Transposer https://stackoverflow.com/questions/68615384/how-to-access-the-tracked-object-offset-in-the-body-of-cinemachinevirtualcamera

            

            transform.localScale = localScale;
        }
    }

    private void CineCam()
    {
        CinemachineFramingTransposer transposer = camObj.GetComponentInChildren<CinemachineFramingTransposer>();
        
        if (isFacingRight && transposer.m_TrackedObjectOffset.x <= 1)
        {
            transposer.m_TrackedObjectOffset.x += camFlipSpeed;

        }
        else if (!isFacingRight && transposer.m_TrackedObjectOffset.x >= -1f)
        {
            transposer.m_TrackedObjectOffset.x += -(camFlipSpeed);
        }

        if (IsGrounded() && transposer.m_YDamping <= 2)
        {
            transposer.m_YDamping += 1f;
        }
        else if (!IsGrounded() && transposer.m_YDamping >= .5)
        {
            transposer.m_YDamping -= 0.1f;
        }

    }

}