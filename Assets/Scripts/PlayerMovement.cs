using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UIElements;
using static PlayerMovement;
using System.Reflection;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private bool isFacingRight = true;
    private bool canJump = false;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private GameObject camObj;
    [SerializeField] private float camFlipSpeed;
    [SerializeField] private Rigidbody2D myRb;

    [SerializeField]
    public LayerMask[] GroundLayers;
    //public AudioManager am;

    private void Start()
    {
        // get the player's rigidbody
        myRb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        audioManager.PlaySound("Walk");
        myRb.velocity = new Vector2(horizontal * playerSpeed, myRb.velocity.y);

        Jump();
        Flip();
        CineCam();

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

    public bool IsGrounded()
    {
        return RayCastGroundLayers();
    }

    bool RayCastGroundLayers()
    {
        foreach (var layer in GroundLayers)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, myRb.transform.localScale.y + 0.1f, layer);
            if (hit.collider!=null) return true;
        }
        return false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
        }
        // Double Jump
        else if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            audioManager.PlaySound("Jump");
            myRb.velocity = new Vector2(myRb.velocity.x, 16f);
            canJump = false;
        }

        // Glide
        if (Input.GetKey(KeyCode.Space) && !IsGrounded() && myRb.velocity.y < 0f)
        {
            myRb.gravityScale = 0.5f;
        }
        else
        {
            myRb.gravityScale = 4f;
        }
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

    private void CineCam()
    {
        // Accessing the Transposer https://stackoverflow.com/questions/68615384/how-to-access-the-tracked-object-offset-in-the-body-of-cinemachinevirtualcamera
        CinemachineFramingTransposer transposer = gameObject.GetComponent<RoomManager>().currentCamera().GetComponentInChildren<CinemachineFramingTransposer>();

        // Flipping Camera based on faced direction.
        if (isFacingRight && transposer.m_TrackedObjectOffset.x <= 1)
        {
            transposer.m_TrackedObjectOffset.x += camFlipSpeed;

        }
        else if (!isFacingRight && transposer.m_TrackedObjectOffset.x >= -1f)
        {
            transposer.m_TrackedObjectOffset.x += -(camFlipSpeed);
        }

        // Falling Y-axis camera movement.
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