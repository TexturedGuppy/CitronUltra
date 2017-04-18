using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //Public Variables
    public LayerMask mask; //Filters out different physics layers
    public float speed = 3; //Speed of player
    public float vJump = 8f; //Strength of jump
    public GameObject feet; //Specifies feet of player

    private Rigidbody2D rb; //Rigib body of player
    private Animator animator; //animator of player
    private bool isGrounded = false; //Checks to see if player is grounded
    PlayerHP playerHP; //Player HP script
    turretBullet turretBullet; //Turret Bullet Script

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mask = 1 << LayerMask.NameToLayer("Platform"); //This line of code attaches a value to the layer mask that filters out all layers except the specified named one. 
                                                       //I personally don't exactly understand what is going on with the angle brackets specifically, i do know however 
                                                       //the other way i was assigning the value was only filter the specified one instead of everything else
                                                       //Do know that << is a bitshift operator, I do not know as to why shifting the bit of the 1 causes the inverse effect for layer masks.
    }

    // Update is called once per frame
    void Update () {

        movement();
        

    }

    /// <summary>
    /// Handles all the movement, and jumping of the player
    /// Also handles the collider for the jump checker
    /// </summary>
    void movement()
    {

        if (animator.GetBool("isGrounded") && Input.GetKey(KeyCode.Space))
        {
            //rb.AddForce(new Vector2(0, jump));
            rb.velocity = new Vector2(rb.velocity.x, vJump);
            animator.SetBool("isGrounded", false);
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Vector3 vec = new Vector3(5, 0, 0);
            vec.Normalize();
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isWalking", true);
            Debug.Log("Hitting D!");
        }
        //If else if isn't used can't move to the right with D?
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Hitting A!");
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isWalking", true);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isWalking", false);
        }

        animator.SetBool("isGrounded", false);

        //Script that checks to see if character is in fact grounded and allows him to jump
        //The mask filters out everything except the specified filter, in this case, is the layer called platform.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .2f, mask);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                animator.SetBool("isGrounded", true);
            }
        }


        


    }

    
}
