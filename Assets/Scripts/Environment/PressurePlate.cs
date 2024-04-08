
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField]
    GameObject platform;
    [SerializeField]
    GameObject disabledPlatform;

    [SerializeField] bool isReversed = false;
    [SerializeField] bool isPressed = false;

    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource unclickSound;
    [SerializeField] AudioSource activateSound;
    [SerializeField] AudioSource deactivateSound;

    private void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)   // Turn on Pressure plate 
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Peckable") 
        {
            clickSound.Play();
            isPressed = true;
            buttonAction(isPressed);
        } 

    }

    private void OnCollisionExit2D(Collision2D collision)  // Turn Pressure plate off
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Peckable")
        {
            unclickSound.Play();
            isPressed = false;
            buttonAction(isPressed);
        }

    }

    void buttonAction(bool action)
    {
        if (action) {
           
            transform.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;

            if (isReversed)
            {
                deactivateSound.Play();
                platform.GetComponent<BoxCollider2D>().enabled = false;
                platform.GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                activateSound.Play();
                platform.GetComponent<BoxCollider2D>().enabled = true;
                platform.GetComponent<SpriteRenderer>().enabled = true;
            }
            
            disabledPlatform.GetComponent<SpriteRenderer>().enabled = false;

        } else
        {
            
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetComponent<SpriteRenderer>().enabled = true;

            if (isReversed)
            {
                ///activateSound.Play();
                Debug.Log("trying to enabe wall.");
                platform.GetComponent<BoxCollider2D>().enabled = true;
                platform.GetComponent<SpriteRenderer>().enabled = true;
            } else
            
                deactivateSound.Play() ;
                platform.GetComponent<BoxCollider2D>().enabled = false;
                platform.GetComponent<SpriteRenderer>().enabled = false;
            }
            
            disabledPlatform.GetComponent<SpriteRenderer>().enabled = true;

        }
    }


    // This makes platform appear
    /*void toggleEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // greenButton.GetComponent<SpriteRenderer>().enabled = true;
        platform.GetComponent<BoxCollider2D>().enabled = true;
        platform.GetComponent<SpriteRenderer>().enabled = true;
        disabledPlatform.GetComponent<SpriteRenderer>().enabled = false;
    }

    // This makes platform dissapear
    void toggleDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //greenButton.GetComponent<SpriteRenderer>().enabled = false;
        platform.GetComponent<BoxCollider2D>().enabled = false;
        platform.GetComponent<SpriteRenderer>().enabled = false;
        disabledPlatform.GetComponent<SpriteRenderer>().enabled = true;
    }

    //  make the platform dissapear when activated. 
    void toggleReverseEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //greenButton.GetComponent<SpriteRenderer>().enabled = true;
        platform.GetComponent<BoxCollider2D>().enabled = false;
        platform.GetComponent<SpriteRenderer>().enabled = false;
        disabledPlatform.GetComponent<SpriteRenderer>().enabled = true;
    }

    // make platform enabled when pressure plate is disabled. 
    void toggleReverseDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //greenButton.GetComponent<SpriteRenderer>().enabled = false;
        platform.GetComponent<BoxCollider2D>().enabled = true;
        platform.GetComponent<SpriteRenderer>().enabled = true;
        disabledPlatform.GetComponent<SpriteRenderer>().enabled = false;
    }*/

