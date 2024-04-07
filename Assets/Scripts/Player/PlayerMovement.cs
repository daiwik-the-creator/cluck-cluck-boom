
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Unity.VisualScripting;


public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private bool isFacingRight = true;
    private bool canJump = true;
    public bool isStealthing = false;
    private Animator _animator;
    
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private GameObject camObj;
    [SerializeField] private float camFlipSpeed;
    [SerializeField] private Rigidbody2D myRb;

    [SerializeField]
    public LayerMask[] GroundLayers;
    
    public AudioManager am;
    private AudioSource walkSource;
    private AudioSource glideSource;

    private void Start()
    {
        // get the player's rigidbody
        myRb = GetComponent<Rigidbody2D>();
        walkSource = am.getSource("Walk");
        glideSource = am.getSource("Glide");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Stealth();
        if (isStealthing == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            myRb.velocity = new Vector2(horizontal * playerSpeed, myRb.velocity.y);
            Jump();
            Flip();

            if (IsGrounded() && horizontal != 0)
            {
                if (!walkSource.isPlaying)
                {
                    am.PlaySound("Walk");
                }
            }

            _animator.SetBool(name: "IsInAir", value: !IsGrounded());
            _animator.SetBool(name: "IsWalking", value: horizontal != 0);

        } else
        {
            _animator.SetBool(name: "IsWalking", value: false);
            _animator.SetBool(name: "IsInAir", value: !IsGrounded());
            glideSource.Stop();

        }

        CineCam();
 
        if (IsGrounded())
        {
            //Debug.Log("I am grounded!!!!!");
            canJump = true;
            _animator.SetBool(name: "Shooting", value: false); // temp shoot anim break
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }

        /*Debug.Log(IsGrounded());*/
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, myRb.transform.localScale.y - 0.2f, layer);
            if (hit.collider!=null) return true;
            //Debug.Log("hit: "+hit.collider.name);
        }
        return false;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            //Debug.Log("I am grounded!!!!!");
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            am.PlaySound("Jump");
            myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
            
        }
        // Double Jump
        else if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            am.PlaySound("DoubleJump");
            myRb.velocity = new Vector2(myRb.velocity.x, 16f);
            canJump = false;
        }

        // Glide
        if (Input.GetKey(KeyCode.Space) && !IsGrounded() && myRb.velocity.y < 0f)
        {
            //Debug.Log("Trying to play glide");
            glideSource.Play();
            myRb.gravityScale = 0.5f;
        }
        else
        {
            if(glideSource != null) 
                glideSource.Stop();
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

    public void Stealth()
    {
        if (Input.GetKey(KeyCode.X) && IsGrounded())
        {
            isStealthing = true;
            _animator.SetBool(name: "IsStealthing", value: isStealthing);
            SetOpacity(.5f);
        }
        else
        {
            isStealthing = false;
            _animator.SetBool(name: "IsStealthing", value: isStealthing);
            SetOpacity(1f);
        }
    }

    public void SetOpacity(float opacity)
    {
        opacity = Mathf.Clamp01(opacity);
        Color spriteColor = myRb.GetComponent<SpriteRenderer>().color;
        spriteColor.a = opacity;
        myRb.GetComponent<SpriteRenderer>().color = spriteColor;
    }

}