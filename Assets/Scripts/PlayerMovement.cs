using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    Vector2 jump;
    Rigidbody2D myRb;
    public float playerSpeed = 2.0f;
    public float JumpForce = 3.0f;


    private void Start()
    {
        // get the player's rigidbody
        myRb = GetComponent<Rigidbody2D>();
        jump.y = JumpForce;
    }
   
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        myRb.MovePosition(myRb.position + movement * playerSpeed * Time.deltaTime);

<<<<<<< Updated upstream
        if (Input.GetButtonDown("Jump"))
=======
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, myRb.transform.localScale.y + 0.1f, groundLayer);

        return hit.collider != null;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
>>>>>>> Stashed changes
        {
            myRb.AddForce(jump, ForceMode2D.Impulse);
        }
    }
}
